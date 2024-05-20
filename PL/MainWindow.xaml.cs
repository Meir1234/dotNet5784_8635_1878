using BlApi;
using PL.Engineer;
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
using BlApi;
namespace PL;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IBl _bl = Factory.Get();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void EngineerHandler_btn(object sender, RoutedEventArgs e)
    {

        try
        {
            int userInput = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("Please enter your Id:", "Enter Id", "111111111"));

            if (_bl.Engineer.Read(userInput) is null)
                return;

            Button? btn = sender as Button;

            if (btn.Content.ToString() == "Engineer")
                new EngineerWindow(false, userInput).Show();

            if (btn.Content.ToString() == "Manager")
                new ManagerMain().Show();
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void ManagerHandler_btn(object sender, RoutedEventArgs e) => new ManagerMain().Show();

    private void Reset_btn(object sender, RoutedEventArgs e)
    {
        DalTest.Initialization.Do();
        MessageBox.Show("init Data");
    }
}