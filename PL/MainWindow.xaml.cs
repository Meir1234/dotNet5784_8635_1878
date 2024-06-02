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
using System.ComponentModel;
using System.Windows.Threading;
namespace PL;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IBl _bl = Factory.Get();

    private DispatcherTimer _timer;

    DateTime _lastUpdate;

    public MainWindow()
    {
        InitializeComponent();
        StartClock();
    }

    private void StartClock()
    {
        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromSeconds(1); // הגדרת המרווח לעדכון כל שנייה
        _timer.Tick += Timer_Tick;
        _timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        ClockLabel.Content = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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

    private void ChangeDate(object sender, RoutedEventArgs e)
    {
        e.Handled = true;
        try
        {
            Button button = (Button)sender;

            switch (button.Content.ToString())
            {
                case "Add Hour":
                    _timer.
                    ClockLabel.Content;
                    AddHours(1);
                    break;
                case "Add Day":
                    Clock.AddDays(1);
                    break;
                case "Add Month":
                    Clock.AddMonths(1);
                    break;
                case "Add Year":
                    Clock.AddYears(1);
                    break;
                case "Reset Clock":
                    Clock = DateTime.Now;
                    break;
            }
            ClockLabel.Content = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        catch { }
    }
}