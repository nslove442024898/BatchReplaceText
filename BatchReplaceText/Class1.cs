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
using Microsoft.Win32;
using Registry = Autodesk.AutoCAD.Runtime.Registry;
using RegistryKey = Autodesk.AutoCAD.Runtime.RegistryKey;

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

        [CommandMethod("SetUpAutoLoadWithAcad")]
        public void 设置随cad程序自启动()
        {
            // Get the AutoCAD/GstarCAD Applications key
            var sProdKey = HostApplicationServices.Current.UserRegistryProductRootKey;
            var sAppName = Assembly.GetExecutingAssembly().GetTypes()[0].Namespace;
            var regAcadProdKey = Registry.CurrentUser.CreateSubKey(sProdKey);
            var regAcadAppKey = regAcadProdKey.CreateSubKey("Applications");
            // Check to see if the "MyApp" key exists
            var subKeys = regAcadAppKey.GetSubKeyNames();
            foreach (var subKey in subKeys)
            {
                // If the application is already registered, exit
                if (!subKey.Equals(sAppName)) continue;
                regAcadAppKey.Close();
                return;
            }
            // Get the location of this module
            var sAssemblyPath = Assembly.GetExecutingAssembly().Location;

            // Register the application
            var regAppAddInKey = regAcadAppKey.CreateSubKey(sAppName);
            regAppAddInKey.SetValue("DESCRIPTION", sAppName, RegistryValueKind.String);
            regAppAddInKey.SetValue("LOADCTRLS", 14, RegistryValueKind.DWord);
            regAppAddInKey.SetValue("LOADER", sAssemblyPath, RegistryValueKind.String);
            regAppAddInKey.SetValue("MANAGED", 1, RegistryValueKind.DWord);
            regAcadAppKey.Close();
            Autodesk.AutoCAD.ApplicationServices.Core.Application.ShowAlertDialog(@"自动加载到自启动，如需取消自启动，请输入""UnregisterMyApp"" 命令");
        }

        [CommandMethod("CancelAutoLoadWithAcad")]
        public static void 取消随cad程序自启动()
        {
            // Get the AutoCAD/GstarCAD Applications key

            var sProdKey = HostApplicationServices.Current.UserRegistryProductRootKey;
            var sAppName = Assembly.GetExecutingAssembly().GetTypes()[0].Namespace;

            var regAcadProdKey = Registry.CurrentUser.OpenSubKey(sProdKey);
            var regAcadAppKey = regAcadProdKey.OpenSubKey("Applications", true);

            var subKeys = regAcadAppKey.GetSubKeyNames();
            foreach (var subKey in subKeys)
            {
                // If the application is already registered, exit
                if (!subKey.Equals(sAppName)) continue;
                regAcadAppKey.DeleteSubKeyTree(sAppName);
                regAcadAppKey.Close();
                Autodesk.AutoCAD.ApplicationServices.Core.Application.ShowAlertDialog("卸载成功，重启cad应用！！！！");
                return;
            }

            // Delete the key for the application

        }
    }
}
