﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LicenseSwitcher.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4.1")]
        public string Version {
            get {
                return ((string)(this["Version"]));
            }
            set {
                this["Version"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\dev\\workspace\\eyeq-4.1.x")]
        public string v41_target {
            get {
                return ((string)(this["v41_target"]));
            }
            set {
                this["v41_target"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\dev\\eyeq-license")]
        public string v41_lic_folder {
            get {
                return ((string)(this["v41_lic_folder"]));
            }
            set {
                this["v41_lic_folder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("toga.lic.oracle")]
        public string v41_oracle {
            get {
                return ((string)(this["v41_oracle"]));
            }
            set {
                this["v41_oracle"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("toga.lic.derby")]
        public string v41_derby {
            get {
                return ((string)(this["v41_derby"]));
            }
            set {
                this["v41_derby"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("toga.lic.mssql")]
        public string v41_mssql {
            get {
                return ((string)(this["v41_mssql"]));
            }
            set {
                this["v41_mssql"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("toga.lic.mysql")]
        public string v41_mysql {
            get {
                return ((string)(this["v41_mysql"]));
            }
            set {
                this["v41_mysql"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\dev\\workspace\\eyeq-trunk")]
        public string trunk_target {
            get {
                return ((string)(this["trunk_target"]));
            }
            set {
                this["trunk_target"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\dev\\eyeq-license")]
        public string trunk_lic_folder {
            get {
                return ((string)(this["trunk_lic_folder"]));
            }
            set {
                this["trunk_lic_folder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("toga.lic.oracle")]
        public string trunk_oracle {
            get {
                return ((string)(this["trunk_oracle"]));
            }
            set {
                this["trunk_oracle"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("toga.lic.derby")]
        public string trunk_derby {
            get {
                return ((string)(this["trunk_derby"]));
            }
            set {
                this["trunk_derby"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("toga.lic.mssql")]
        public string trunk_mssql {
            get {
                return ((string)(this["trunk_mssql"]));
            }
            set {
                this["trunk_mssql"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("toga.lic.mysql")]
        public string trunk_mysql {
            get {
                return ((string)(this["trunk_mysql"]));
            }
            set {
                this["trunk_mysql"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" +
            "tring>trunk</string>\r\n  <string>v41</string>\r\n</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection Version_List {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["Version_List"]));
            }
            set {
                this["Version_List"] = value;
            }
        }
    }
}
