using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MessageSigner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignButtonHandler(object sender, RoutedEventArgs e)
        {
            string inputText = InputField.Text;
            var keyPair = Cryptography.CryptographyService.GenerateKeyPair();
            OutputSignature.Text = Cryptography.CryptographyService.Sign(inputText, keyPair.PrivateKey);
            OutputPublicKey.Text = keyPair.PublicKey;
        }

        private void CopyOutputSignatureToClipBoard(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(OutputSignature.Text);
        }

        private void CopyOutputPublicKeyToClipBoard(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(OutputPublicKey.Text);
        }
    }
}
