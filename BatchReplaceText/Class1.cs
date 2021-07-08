using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using System.Reflection;

[assembly: ExtensionApplication(typeof(BatchReplaceText.MyCmd))]

[assembly: CommandClass(typeof(BatchReplaceText.MyCmd))]

namespace BatchReplaceText
{
    public class MyCmd:IExtensionApplication        
    {
        public 批量文本替换 Frm { get; set; }

        public  Database AcDb = HostApplicationServices.WorkingDatabase;
        private readonly Editor _acEd = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument.Editor;

        public void Initialize()
        {
            _acEd.WriteMessage("欢迎使用本程序,如果有任何问题请联系作者,微信ns442024898,QQ:442024898,电话:17607170146\n");
            //反射出命令

            var ass = Assembly.GetExecutingAssembly();

            var mycmdStr = (from item in ass.GetTypes().Where(c => c.IsClass && c.IsPublic) from mi in item.GetMethods().Where(c => c.IsPublic && c.GetCustomAttributes(true).Length > 0).ToList() from att in mi.GetCustomAttributes(true) where att.GetType().Name == typeof(CommandMethodAttribute).Name let cadAtt = att as CommandMethodAttribute select new string[] {mi.Name, cadAtt.GlobalName}).ToList();
            mycmdStr.ForEach(cmd =>
                _acEd.WriteMessage(message: $"要运行 {cmd[0]} ,请在cad命令行输入 \"{cmd[1]}\" 命令\n"));
        }

        public void Terminate()
        {
            _acEd.WriteMessage("感谢您使用本程序,如果有任何问题请联系作者,微信ns442024898,QQ:442024898,电话:17607170146");
        }

        [CommandMethod("MyBatchReplaceText")]
        public void 批量文本替换主程序()
        {
            if (this.Frm == null) this.Frm = new 批量文本替换();
            this.Frm.FormClosing += Frm_FormClosing;
            Application.ShowModelessDialog(Frm);
        }

        private void Frm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            this.Frm = null;
        }

    }
}
