using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Raiz.WindowsApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            
            this.InitializeComponent();
        }


        private void OkButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            AchaRaiz ar = new AchaRaiz(new FuncaoTexto(ExpressionTextBox.Text));

            double epsilon = 1e-5;
            string saida = "" +
            $"Bissecão:\n\t {ar.Bisseccao(-3, -1, epsilon)}";
        }
    }
}
