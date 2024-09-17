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
using System.Speech.Recognition;

namespace WPFreconocevoz1{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window{
        SpeechRecognitionEngine rec1 = new SpeechRecognitionEngine();
        public MainWindow(){
            InitializeComponent();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e){
            Choices comando = new Choices();
            comando.Add(new string[] {
                "Que tal", "pon mi nombre","pon bloc de notas","pon danza","pon documento","pon imagen",
                "pon navegador","pon consola","pon calculadora","firma","Salir"
            });
            GrammarBuilder gcrea = new GrammarBuilder();
            gcrea.Append(comando);
            Grammar grama1 = new Grammar(gcrea);
            rec1.LoadGrammarAsync(grama1);
            rec1.SetInputToDefaultAudioDevice();
            rec1.SpeechRecognized += rec1_SpeechRecognized;
            lB1.Items.Add("Que tal\n"+ "pon mi nombre\n"+ "pon bloc de notas\n"+ "pon danza\n"+ "pon documento\n"+
                "pon imagen\n"+"pon navegador\n"+"pon consola\n"+"pon calculadora\n"+"firma\n"+"Salir");
        }
        private void btnactivar_Click(object sender, RoutedEventArgs e){
            rec1.RecognizeAsync(RecognizeMode.Multiple);
            btndesactivar.IsEnabled = true;
        }
        void rec1_SpeechRecognized(object sender, SpeechRecognizedEventArgs e){
            switch (e.Result.Text){
                case "Que tal":
                    MessageBox.Show("hola como estas");
                    break;
                case "pon mi nombre":
                    richtB1.AppendText("\n Fernando");
                    break;
                case "pon bloc de notas":
                    System.Diagnostics.Process.Start(@"c:windows\notepad.exe");
                    break;
                case "pon danza":
                    System.Diagnostics.Process.Start("lobos.mp3");
                    break;
                case "pon documento":
                    System.Diagnostics.Process.Start("pnp.pdf");
                    break;
                case "pon imagen":
                    System.Diagnostics.Process.Start("8.jpg");
                    break;
                case "pon navegador":
                    System.Diagnostics.Process.Start((@"c:windows\explorer.exe"));
                    break;
                case "pon alculadora":
                    System.Diagnostics.Process.Start((@"c:windows\System32\calc.exe"));
                    break;
                case "pon consola":
                    System.Diagnostics.Process.Start((@"c:windows\System32\cmd.exe"));
                    break;
                case "firma":
                    System.Diagnostics.Process.Start(("Firma_2.exe"));
                    break;
                case "Salir":
                    Close();                   
                    break;
            }
        }
        private void btndesactivar_Click(object sender, RoutedEventArgs e){
            rec1.RecognizeAsyncStop();
            btndesactivar.IsEnabled = false;
        }
    }
}
