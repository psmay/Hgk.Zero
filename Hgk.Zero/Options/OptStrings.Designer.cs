﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hgk.Zero.Options {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class OptStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal OptStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Hgk.Zero.Options.OptStrings", typeof(OptStrings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
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
        ///   Looks up a localized string similar to more than one element.
        /// </summary>
        internal static string ElementsMoreThanOne {
            get {
                return ResourceManager.GetString("ElementsMoreThanOne", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to one element.
        /// </summary>
        internal static string ElementsOne {
            get {
                return ResourceManager.GetString("ElementsOne", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to no elements.
        /// </summary>
        internal static string ElementsZero {
            get {
                return ResourceManager.GetString("ElementsZero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to more than one match.
        /// </summary>
        internal static string MatchesMoreThanOne {
            get {
                return ResourceManager.GetString("MatchesMoreThanOne", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to one match.
        /// </summary>
        internal static string MatchesOne {
            get {
                return ResourceManager.GetString("MatchesOne", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to no matches.
        /// </summary>
        internal static string MatchesZero {
            get {
                return ResourceManager.GetString("MatchesZero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [single result: {0}].
        /// </summary>
        internal static string SingleResultOptWithoutValue {
            get {
                return ResourceManager.GetString("SingleResultOptWithoutValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [single result: {0} ({1})].
        /// </summary>
        internal static string SingleResultOptWithValue {
            get {
                return ResourceManager.GetString("SingleResultOptWithValue", resourceCulture);
            }
        }
    }
}
