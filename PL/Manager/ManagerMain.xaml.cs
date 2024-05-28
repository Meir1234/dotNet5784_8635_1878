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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for ManagerMain.xaml
    /// </summary>
    public partial class ManagerMain : Window
    {

        //private readonly IBl _bl = Factory.Get();
        static readonly IBl _bl = BlApi.Factory.Get();
        public ManagerMain()
        {
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

        private void Gant_btn(object sender, RoutedEventArgs e)
        {
            try
            {
                new Gantt().Show();
            }
            catch { MessageBox.Show("The tasks is not schedule yet\n"); }

        }


    }
}
