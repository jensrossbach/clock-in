﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.269
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClockIn.Properties {
    using System;
    
    
    /// <summary>
    ///   Eine stark typisierte Ressourcenklasse zum Suchen von lokalisierten Zeichenfolgen usw.
    /// </summary>
    // Diese Klasse wurde von der StronglyTypedResourceBuilder automatisch generiert
    // -Klasse über ein Tool wie ResGen oder Visual Studio automatisch generiert.
    // Um einen Member hinzuzufügen oder zu entfernen, bearbeiten Sie die .ResX-Datei und führen dann ResGen
    // mit der /str-Option erneut aus, oder Sie erstellen Ihr VS-Projekt neu.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Gibt die zwischengespeicherte ResourceManager-Instanz zurück, die von dieser Klasse verwendet wird.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ClockIn.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Überschreibt die CurrentUICulture-Eigenschaft des aktuellen Threads für alle
        ///   Ressourcenzuordnungen, die diese stark typisierte Ressourcenklasse verwenden.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die About ähnelt.
        /// </summary>
        internal static string AboutCaption {
            get {
                return ResourceManager.GetString("AboutCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die ClockIn
        ///Version {0}
        ///Working time notification tool
        ///
        ///written 2012 by Jens Rossbach
        ///
        ///Application icon by: FastIcon.com
        ///http://www.fasticon.com
        ///
        ///Smilies Copyright © 2002 wbchug.net :: Yazoo
        ///http://icons.wbchug.net ähnelt.
        /// </summary>
        internal static string AboutText {
            get {
                return ResourceManager.GetString("AboutText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Continue previously started session? ähnelt.
        /// </summary>
        internal static string AskSessionOnStartup {
            get {
                return ResourceManager.GetString("AskSessionOnStartup", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Break must not be longer than regular or maximum working time! ähnelt.
        /// </summary>
        internal static string BreakGreaterRegularMaxTime {
            get {
                return ResourceManager.GetString("BreakGreaterRegularMaxTime", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die The end of the breaks period must be after the beginning! ähnelt.
        /// </summary>
        internal static string BreaksBeginAfterBreaksEnd {
            get {
                return ResourceManager.GetString("BreaksBeginAfterBreaksEnd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die You have reached your maximum daily working time! ähnelt.
        /// </summary>
        internal static string MaxmimumTimeLimitReached {
            get {
                return ResourceManager.GetString("MaxmimumTimeLimitReached", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die ClockIn ähnelt.
        /// </summary>
        internal static string MessageBoxCaption {
            get {
                return ResourceManager.GetString("MessageBoxCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Regular working time must not be greater than maximum working time! ähnelt.
        /// </summary>
        internal static string RegularTimeGreaterMaxTime {
            get {
                return ResourceManager.GetString("RegularTimeGreaterMaxTime", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die You have reached your regular daily working time. ähnelt.
        /// </summary>
        internal static string RegularTimeLimitReached {
            get {
                return ResourceManager.GetString("RegularTimeLimitReached", resourceCulture);
            }
        }
    }
}
