using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace ITUniversell.Helper
{
    public class HelperTextBox : TextBox
    {
        
        public HelperTextBox(bool isReadOnly)
        {

            //Template = GetRoundedTextBoxTemplate();
            IsReadOnly = isReadOnly;
            if (IsReadOnly) IsEnabled = false;
            TextWrapping = System.Windows.TextWrapping.Wrap;
            AcceptsReturn = true;
         
            Width = 230;
            Height = 35;
           
            
        }
        //public static ControlTemplate GetRoundedTextBoxTemplate()
        //{

        //    //ControlTemplate template = new ControlTemplate(typeof(TextBoxBase));
        //    //FrameworkElementFactory elemFactory = new FrameworkElementFactory(typeof(Border));
        //    //elemFactory.Name = "Border";
        //    //elemFactory.SetValue(Border.CornerRadiusProperty, new CornerRadius(10));
        //    //elemFactory.SetValue(Border.BorderBrushProperty, new SolidColorBrush(Colors.Black));
        //    //elemFactory.SetValue(Border.BackgroundProperty, new TemplateBindingExtension(TextBox.BackgroundProperty));
        //    //elemFactory.SetValue(Border.BorderThicknessProperty, new TemplateBindingExtension(TextBox.BorderThicknessProperty));
        //    //elemFactory.SetValue(Border.SnapsToDevicePixelsProperty, true);
        //    //template.VisualTree = elemFactory;


        //    //FrameworkElementFactory scrollViewerElementFactory = new FrameworkElementFactory(typeof(ScrollViewer));
        //    //scrollViewerElementFactory.Name = "PART_ContentHost";
        //    //elemFactory.AppendChild(scrollViewerElementFactory);


        //    //Trigger isEnabledTrigger = new Trigger();
        //    //isEnabledTrigger.Property = TextBox.IsEnabledProperty;
        //    //isEnabledTrigger.Value = false;

        //    //Setter backgroundSetter = new Setter();
        //    //backgroundSetter.TargetName = "Border";
        //    //backgroundSetter.Property = TextBox.BackgroundProperty;
        //    //backgroundSetter.Value = SystemColors.ControlBrush;

        //    //Setter foregroundSetter = new Setter();
        //    //foregroundSetter.Property = TextBox.ForegroundProperty;
        //    //foregroundSetter.Value = SystemColors.GrayTextBrush;

        //    //isEnabledTrigger.Setters.Add(backgroundSetter);
        //    //isEnabledTrigger.Setters.Add(foregroundSetter);


        //    //template.Triggers.Add(isEnabledTrigger);

        //    //return template;
        //}
    }
}
