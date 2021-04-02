using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;

namespace WpfDesignerHelper
{
    public static class Designer
    {
        public static bool Active
        {
            get
            {
                try
                {
                    return (bool)DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue;
                }
                catch(Exception ex)
                {
                    var errorMessage = $"{typeof(Designer).FullName} ran into a problem while trying to detect if the design was Active:\r\n" +
                            $"    {ex}";

                    if(Debugger.IsAttached)
                    {
                        Debug.WriteLine(errorMessage);
                    }
                    else
                    {
                        Console.WriteLine(errorMessage);
                    }
                }

                return false;
            }
        }
    }
}