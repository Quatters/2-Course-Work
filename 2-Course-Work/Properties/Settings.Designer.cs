﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _2_Course_Work.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.7.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool FindFormByYears_checkBox_Checked {
            get {
                return ((bool)(this["FindFormByYears_checkBox_Checked"]));
            }
            set {
                this["FindFormByYears_checkBox_Checked"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool FindFormByPublisher_checkBox_Checked {
            get {
                return ((bool)(this["FindFormByPublisher_checkBox_Checked"]));
            }
            set {
                this["FindFormByPublisher_checkBox_Checked"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal FindFormFromYear_numeric_Value {
            get {
                return ((decimal)(this["FindFormFromYear_numeric_Value"]));
            }
            set {
                this["FindFormFromYear_numeric_Value"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2000")]
        public decimal FindFormToYear_numeric_Value {
            get {
                return ((decimal)(this["FindFormToYear_numeric_Value"]));
            }
            set {
                this["FindFormToYear_numeric_Value"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string FindFormPublisher_textBox_Text {
            get {
                return ((string)(this["FindFormPublisher_textBox_Text"]));
            }
            set {
                this["FindFormPublisher_textBox_Text"] = value;
            }
        }
    }
}
