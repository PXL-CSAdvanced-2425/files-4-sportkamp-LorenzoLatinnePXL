using ClassLib;
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

namespace WpfAppSportkamp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _fileName = "../../../../LedenSportkamp.txt";

        public MainWindow()
        {
            InitializeComponent();
            Member memberList = new Member();

            List<Member> Members = memberList.ReadMembers(_fileName);

            detailsTextBox.Text = "Details van alle leden.\n\n";
            detailsTextBox.Text += memberList.ShowMembers(Members);

            weekOverviewTextBox.Text = "Overzicht per week.\n\n";

            sportOverviewTextBox.Text = "Overzicht per Sporttak.\n\n";
        }
    }
}
