using BlApi;
using PL.Engineer;
using PL.Manager;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for ManagerMain.xaml
    /// </summary>
    public partial class ManagerMain : Window
    {

        private readonly IBl _bl = Factory.Get();

        public DateTime Clock
        {
            get { return (DateTime)GetValue(ClockProperty); }
            set { SetValue(ClockProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Clock.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClockProperty =
            DependencyProperty.Register("Clock", typeof(DateTime), typeof(ManagerMain));



        public ManagerMain()
        {
            Clock = DateTime.Now;
            InitializeComponent();
        }

        private void InitData_btn(object sender, RoutedEventArgs e) => DalTest.Initialization.Do();


        private void EmployeeList_btn(object sender, RoutedEventArgs e) => new EngineerListWindow(true).Show();

        private void AutoSchedule_btn(object sender, RoutedEventArgs e)
        {
            try
            {
                _bl.Task.ScheduleTasks(DateTime.Now);
                MessageBox.Show("The tasks are scheduale now");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Taskslist_btn(object sender, RoutedEventArgs e) => new TasksListWindows().Show();

        private void Gant_btn(object sender, RoutedEventArgs e) => new Gantt().Show();

        private void ChangeDate(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            try
            {
                Button button = (Button)sender;

                switch (button.Content.ToString())
                {
                    case "Add Hour":
                        Clock = Clock.AddHours(1);
                        break;
                    case "Add Day":
                        Clock = Clock.AddDays(1);
                        break;
                    case "Add Month":
                        Clock = Clock.AddMonths(1);
                        break;
                    case "Add Year":
                        Clock = Clock.AddYears(1);
                        break;
                    case "Reset Clock":
                        Clock = DateTime.Now;
                        break;
                }
            }
            catch { }
        }
    }
}
