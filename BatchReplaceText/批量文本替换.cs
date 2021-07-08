using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Internal;
using Autodesk.AutoCAD.StatusBar;
using Autodesk.AutoCAD.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = Autodesk.AutoCAD.ApplicationServices.Core.Application;

// ReSharper disable CoVariantArrayConversion

namespace BatchReplaceText
{
    public partial class 批量文本替换 : Form
    {
        public List<string> WorkFiles = new List<string>();

        public Database AcDb = HostApplicationServices.WorkingDatabase;

        public 批量文本替换()
        {
            InitializeComponent();
        }
        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            var ofd = new Autodesk.AutoCAD.Windows.OpenFileDialog("选择需要替换文字的图形", null, "dwg;dxf", null, Autodesk.AutoCAD.Windows.OpenFileDialog.OpenFileDialogFlags.AllowMultiple | Autodesk.AutoCAD.Windows.OpenFileDialog.OpenFileDialogFlags.AllowAnyExtension);
            if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            var addFiles = ofd.GetFilenames().Where(c => MyTools.FileInUse(c) == false && !this.WorkFiles.Contains(c))
                .ToArray();
            if (addFiles.Length > 0)
            {
                this.Text = @"成功选择到了文件";
                this.WorkFiles.AddRange(addFiles);
                this.checkedListBox1.Items.AddRange(items: addFiles);
            }
            else this.Text = @"文件无法添加到列表";
            this.Refresh();
        }

        private void btnCancelSelect_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox1.Items.Count > 0)
            {
                if (this.checkedListBox1.CheckedItems.Count > 0)
                {
                    for (var i = this.checkedListBox1.CheckedItems.Count - 1; i >= 0; i--)
                    {
                        var itemChecked = this.checkedListBox1.CheckedItems[i];
                        this.checkedListBox1.Items.Remove(itemChecked);
                        this.WorkFiles.Remove(itemChecked.ToString());
                        this.Text = $@"移除文件 ""{itemChecked}"" 成功";
                    }
                }
                else this.Text = @"未选中任何文件名称无法操作";
            }
            else this.Text = @"文件列表中没有任何文件无法操作";
            this.Refresh();
        }

        private void btnCancelAll_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox1.Items.Count > 0)
            {
                for (var i = this.checkedListBox1.Items.Count - 1; i >= 0; i--)
                {
                    var item = this.checkedListBox1.Items[i];
                    this.checkedListBox1.Items.Remove(item);
                    this.WorkFiles.Remove(item.ToString());
                    this.Text = $@"移除文件 ""{item}"" 成功";
                }
            }
            else this.Text = @"文件列表中没有任何文件无法操作";
            this.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //静默替换
            var progressIcount = 0;
            string fn;
            string bakFn;
            var icount = 0;
            foreach (var item in this.checkedListBox1.Items)
            {
                progressIcount++;
                fn = item.ToString();
                bakFn = fn.Replace(fn.EndsWith(".dxf") ? ".dxf" : ".dwg", "-" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".bak");
                Database curDb = null;
                File.Copy(fn, bakFn, true);
                this.Text = $@"已经完成 {progressIcount - 1} 张图纸 的替换,正在替换 {Path.GetFileNameWithoutExtension(fn.ToString())} ,剩余{this.checkedListBox1.Items.Count - progressIcount}张图纸需要替换";
                if (this.radioButton1.Checked)//开图替换
                {
                    var curDoc = Application.DocumentManager.Open(fn, false);
                    curDb = curDoc.Database;
                    using (var docLock = curDoc.LockDocument())
                    {
                        using (var trans = curDb.TransactionManager.StartTransaction())
                        {
                            icount = OpenFnMethod(icount, bakFn, curDb, trans);
                            if (icount > 0) trans.Commit(); else trans.Abort();
                        }
                    }
                    if (icount > 0) curDoc.CloseAndSave(fn); else curDoc.CloseAndDiscard();
                }
                if (this.radioButton2.Checked)//静默替换
                {
                    using (curDb = new Database(false, true))
                    using (var trans = curDb.TransactionManager.StartTransaction())
                    {
                        if (fn.EndsWith(".dxf")) curDb.DxfIn(fn, null); else curDb.ReadDwgFile(fn, System.IO.FileShare.ReadWrite, true, null);
                        icount = OpenFnMethod(icount, bakFn, curDb, trans);
                        if (icount > 0)
                        {
                            trans.Commit();
                            if (fn.EndsWith(".dxf")) curDb.DxfOut(fn, 8, DwgVersion.Current); else curDb.SaveAs(fn, DwgVersion.Current);
                            curDb.CloseInput(true);
                        }
                        else trans.Abort();
                    }
                }
                this.Text = @"批量文本替换";

                if (icount > 0)
                {
                    this.Text += $@",图纸 {Path.GetFileNameWithoutExtension(item.ToString())} 中已经从{this.txtBox_oldString.Text} 替换为{this.txtBox_NewString.Text},一共替换了 {icount} 个文字 
";
                }
                else
                {
                    this.Text += $@",图纸 {Path.GetFileNameWithoutExtension(item.ToString())} 中不含有{this.txtBox_oldString.Text} 无法替换为{this.txtBox_NewString.Text}
";
                    File.Delete(bakFn);
                }
                this.Refresh();
            }

            //Utils.RestoreApplicationStatusBar();

            //显示为通知气泡

            var trayItem = new Autodesk.AutoCAD.Windows.TrayItem();//新建一个托盘项目

            Autodesk.AutoCAD.ApplicationServices.Application.StatusBar.TrayItems.Add(trayItem); //将托盘项目添加到AutoCAD的状态栏区域
            var wn = new TrayItemBubbleWindow()
            {
                Title = "文本替换通知",
                Text = "替换完成!",
                IconType = IconType.Information
            };  //新建一个气泡通知窗口

            trayItem.ShowBubbleWindow(wn);//在托盘上显示气泡窗口

            Autodesk.AutoCAD.ApplicationServices.Application.StatusBar.Update();//更新状态栏

            this.ResetText();
            //}
        }



        private int OpenFnMethod(int icount, string bakfn, Database curDb, Transaction trans)
        {
            if (bakfn == null) throw new ArgumentNullException(nameof(bakfn));
            var bt = trans.GetObject(curDb.BlockTableId, OpenMode.ForRead) as BlockTable;
            if (bt == null) return icount;
            foreach (var btrOid in bt)
            {
                var btr = trans.GetObject(btrOid, OpenMode.ForRead) as BlockTableRecord;
                if (btr != null && !btr.IsFromExternalReference)
                {
                    if (this.checkBox_替换块内文字.CheckState == CheckState.Checked)
                    {
                        icount = UpdateTxt(icount, trans, btr);
                    }
                    else
                    {
                        if (btr.IsLayout) icount = UpdateTxt(icount, trans, btr);
                    }
                }
                else continue;

                //}
            }

            return icount;
        }

        private int UpdateTxt(int icount, Transaction trans, BlockTableRecord btr)
        {
            foreach (var item in btr)
            {
                var ent = trans.GetObject(item, OpenMode.ForRead) as Entity;

                if (this.checkBox_指定图层.CheckState == CheckState.Checked)
                {
                    if (ent != null && ent.Layer != this.txtBox_Layer.Text) continue;
                }

                var dbtxt = ent as DBText;
                if (dbtxt != null)
                {
                    if (this.checkBox_完全匹配.CheckState != CheckState.Unchecked)
                    {
                        if (this.checkBox_完全匹配.CheckState == CheckState.Checked)
                        {
                            if (dbtxt.TextString != this.txtBox_oldString.Text) continue;
                            dbtxt.UpgradeOpen();
                            dbtxt.TextString = this.txtBox_NewString.Text;
                            dbtxt.Height = this.textBox_Height.Text != string.Empty
                                ? double.Parse(this.textBox_Height.Text)
                                : dbtxt.Height;
                            icount++;
                            dbtxt.DowngradeOpen();
                        }
                    }
                    else
                    {
                        if (!dbtxt.TextString.Contains(this.txtBox_oldString.Text)) continue;
                        dbtxt.UpgradeOpen();
                        dbtxt.TextString =
                            dbtxt.TextString.Replace(this.txtBox_oldString.Text, this.txtBox_NewString.Text);
                        dbtxt.Height = this.textBox_Height.Text != string.Empty
                            ? double.Parse(this.textBox_Height.Text)
                            : dbtxt.Height;
                        icount++;
                        dbtxt.DowngradeOpen();
                    }
                }
                else
                {
                    var mtxt = ent as MText;
                    if (mtxt != null)
                    {
                        if (this.checkBox_完全匹配.CheckState != CheckState.Unchecked)
                        {
                            if (this.checkBox_完全匹配.CheckState == CheckState.Checked)
                            {
                                if (mtxt.Contents != this.txtBox_oldString.Text) continue;
                                mtxt.UpgradeOpen();
                                mtxt.Contents = this.txtBox_NewString.Text;
                                icount++;
                                mtxt.DowngradeOpen();
                            }
                        }
                        else
                        {
                            if (!mtxt.Contents.Contains(this.txtBox_oldString.Text)) continue;
                            mtxt.UpgradeOpen();
                            mtxt.Contents = mtxt.Text.Replace(this.txtBox_oldString.Text,
                                this.txtBox_NewString.Text);
                            icount++;
                            mtxt.DowngradeOpen();
                        }
                    }
                }
            }

            return icount;
        }


        //private void radioButton1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (this.radioButton2.Checked == true) this.radioButton2.Checked = false;
        //}

        //private void radioButton2_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (this.radioButton1.Checked == true) this.radioButton1.Checked = false;
        //}

        private void 批量文本替换_Load(object sender, EventArgs e)
        {
            this.radioButton2.Checked = true;
            this.radioButton1.Checked = false;
            this.txtBox_Layer.Enabled = false;
            this.textBox_Height.Enabled = false;
        }

        private void checkBox_指定图层_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_指定图层.Checked)
            {
                this.txtBox_Layer.Enabled = true;
            }
            else
            {
                this.txtBox_Layer.Enabled = false;
                this.txtBox_Layer.Text = string.Empty;
            }
        }

        private void checkBox_修改文本高度_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_修改文本高度.Checked)
            {
                this.textBox_Height.Enabled = true;
            }
            else
            {
                this.textBox_Height.Enabled = false;
                this.textBox_Height.Text = string.Empty;
            }
        }

        private void btnSaveFileList_Click(object sender, EventArgs e)
        {
            //https://docs.microsoft.com/zh-cn/windows/win32/shell/knownfolderid

            string tempfilename = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MyBatchReplaceFileList.dat";

            if (this.checkedListBox1.Items.Count > 0)
            {
                using (var sw = File.CreateText(tempfilename))
                {
                    sw.Flush();
                    foreach (var item in this.checkedListBox1.Items) sw.WriteLine(item.ToString());
                }
                Application.ShowAlertDialog("文件列表保存成功!");
            }
            else Application.ShowAlertDialog("文件列表为空,无法保存!");
        }

        private void btnReadFileList_Click(object sender, EventArgs e)
        {
            string tempfilename = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MyBatchReplaceFileList.dat";
            if (!File.Exists(tempfilename))
            {
                Application.ShowAlertDialog("保存的文件列表为空,无法读取");
                return;
            }
            else
            {
                var txts = File.ReadAllLines(tempfilename).ToList();
                txts.ForEach(c =>
                {
                    if (!this.WorkFiles.Contains(c) && !MyTools.FileInUse(c))
                    {
                        this.checkedListBox1.Items.Add(c);
                        this.WorkFiles.Add(c);
                    }
                });
                Application.ShowAlertDialog("文件列表读取成功!");
            }
        }
    }
    public static class MyTools
    {
        public static bool FileInUse(string filename)
        {
            var use = true;
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
                use = false;
            }
            catch (Exception)
            {
                // ignored
            }
            finally
            {
                fs?.Close();
            }
            return use;
        }
    }
}
