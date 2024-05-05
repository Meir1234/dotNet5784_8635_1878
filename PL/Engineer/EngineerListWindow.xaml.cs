using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using BlApi;
using BO;

namespace PL.Engineer;

/// <summary>
/// Interaction logic for EngineerListWindow.xaml
/// </summary>
public partial class EngineerListWindow : Window
{
    private readonly IBl _bl = Factory.Get();



    public ObservableCollection<BO.Engineer> Engineers

    {
        get { return (ObservableCollection<BO.Engineer>)GetValue(EngineersProp); }
        set { SetValue(EngineersProp, value); }
    }

    // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty EngineersProp =
        DependencyProperty.Register(nameof(Engineers), typeof(ObservableCollection<BO.Engineer>), typeof(EngineerListWindow));

    public EngineerListWindow(bool isManager)
    {
        Engineers = new(_bl.Engineer.ReadAll());
        InitializeComponent();
    }

    private void SelectGroup(object sender, SelectionChangedEventArgs e)
    {
        e.Handled = true;
        try
        {
            ComboBox combo = sender as ComboBox;
            Level selected = (Level)combo.SelectedItem;

            if (selected == Level.All)
                Engineers = new(_bl.Engineer.ReadAll());
            else
                Engineers = new(_bl.Engineer.ReadAll(eng => eng.level == selected));
        }
        catch { }
    }

    private void AddEngineer_btn(object sender, RoutedEventArgs e) => new EngineerWindow(true).Show();
}
