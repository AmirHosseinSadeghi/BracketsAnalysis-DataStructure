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
using System.Windows.Shapes;

namespace BracketsAnalysis
{
    /// <summary>
    /// Interaction logic for StackWithLinkList.xaml
    /// </summary>
    public partial class StackWithLinkList : Window
    {
        Analysis analysis;
        StackLinkList stack;
        public StackWithLinkList()
        {
            InitializeComponent();
            stack = new StackLinkList();
            analysis = new Analysis(null,stack);
            analysis.State += analysis_State;

            lblWarning.Content = "It can fix this : -256 + -36 * 12 - 1.5 / 2 - -12569";
            //-256 + -36 * 12 - 1.5 / 2 - -12569
            //(((-256 + (-36 * 12)) - (1.5 / 2))--12569)
        }
        private void analysis_State(object sender, string e)
        {
            lblWarning.Content = e;
        }
        private void btnArray_Click(object sender, RoutedEventArgs e)
        {
            MainWindow stackWithLinkList = new MainWindow();
            this.Visibility = Visibility.Hidden;
            stackWithLinkList.Visibility = Visibility.Visible;
        }

        private void btnstart_Click(object sender, RoutedEventArgs e)
        {
            string str = txtinput.Text;
            str = str.Replace(" ", String.Empty);
            lblWarning.Content = "";
            txtoutput.Text = analysis.InFix(analysis.PostFix(str));
            //txtoutput.Text = analysis.PostFix(str);
        }

    }
}
