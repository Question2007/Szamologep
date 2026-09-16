using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Szamologep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GombokElhelyezese();
        }

        private void GombokElhelyezese()
        {
            for (int i = 0; i < 4; i++) {
                ButtonGrid.RowDefinitions.Add(new RowDefinition());
                ButtonGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            string[,] feliratok =
            {
                {"7", "8", "9", "/"},
                {"4", "5", "6", "*"},
                {"1", "2", "3", "-"},
                {"C", "0", "=", "+"}
            };

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    string label = feliratok[i, j];
                    Button btn = new Button
                    {
                        Content = label,
                        FontSize = 20,
                        FontWeight = FontWeights.Bold,
                        Margin = new Thickness(3)
                    };
                    if (char.IsDigit(label[0]))
                    {
                        btn.Background = Brushes.WhiteSmoke;
                    }
                    else if(label == "C")
                    {
                        btn.Background= Brushes.IndianRed;
                        btn.Foreground = Brushes.White;
                    }
                    else
                    {
                        btn.Background = Brushes.DodgerBlue;
                        btn.Foreground = Brushes.White;
                    }

                    btn.Click += Buttom_Click;

                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);

                    ButtonGrid.Children.Add(btn);
                }
            }
        }

        private int vegeredmeny = 0;
        private void Buttom_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string felirat = button.Content.ToString();

            if (tb_kijelzo.Text == "0")
            {
                tb_kijelzo.Text = felirat;

            }
            else if (felirat == "C")
            {
                tb_kijelzo.Text = "0";
            }
            else if (char.IsDigit(felirat[0])) {
                tb_kijelzo.Text += felirat;
            }
            else if (felirat == "+")
            {
                tb_kijelzo.Text += "+";
            }
            else if (felirat == "-")
            {
                tb_kijelzo.Text += "-";
            }
            else if (felirat == "*")
            {
                tb_kijelzo.Text += "*";
            }
            else if (felirat == "/")
            {
                tb_kijelzo.Text += "/";
            }
            else if (felirat == "=")
            {
                if (tb_kijelzo.Text.Contains("+"))
                {
                    string[] szamok = tb_kijelzo.Text.Split("+");
                    int szam1 = int.Parse(szamok[0]);
                    int szam2 = int.Parse(szamok[1]);
                    vegeredmeny = szam1 + szam2;
                    tb_kijelzo.Text = vegeredmeny.ToString();
                }
                else if (tb_kijelzo.Text.Contains("-"))
                {
                    string[] szamok = tb_kijelzo.Text.Split("-");
                    int szam1 = int.Parse(szamok[0]);
                    int szam2 = int.Parse(szamok[1]);
                    vegeredmeny = szam1 - szam2;
                    tb_kijelzo.Text = vegeredmeny.ToString();
                }
                else if (tb_kijelzo.Text.Contains("*"))
                {
                    string[] szamok = tb_kijelzo.Text.Split("*");
                    int szam1 = int.Parse(szamok[0]);
                    int szam2 = int.Parse(szamok[1]);
                    vegeredmeny = szam1 * szam2;
                    tb_kijelzo.Text = vegeredmeny.ToString();
                }
                if (tb_kijelzo.Text.Contains("/"))
                {
                    string[] szamok = tb_kijelzo.Text.Split("/");
                    int szam1 = int.Parse(szamok[0]);
                    int szam2 = int.Parse(szamok[1]);
                    if (szam1 == 0 || szam2 == 0)
                    {
                        tb_kijelzo.Text = "Hiba";
                        return;
                    }
                    if (szam1 % szam2 != 0)
                    {
                        float eredmeny = (float)szam1 / szam2;
                        tb_kijelzo.Text = eredmeny.ToString();
                        return;
                    }
                    vegeredmeny = szam1 / szam2;
                    tb_kijelzo.Text = vegeredmeny.ToString();
                }
            }
        }
    }
}