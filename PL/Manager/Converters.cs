using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System;
using BO;
using System.Collections.Generic;
using System.Linq;

namespace PL;

public class DepToColorConvert : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            TaskInList taskInList = (TaskInList)values[0];
            IEnumerable<TaskInList> depList = (IEnumerable<TaskInList>)values[1];
            if (taskInList is null || depList is null)
                return Brushes.Transparent;

            if (depList.Any(x => x.Id == taskInList.Id))
                return Brushes.Green;
        }
        catch { }
        return Brushes.Transparent;

    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class CalcStatusColor : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            Status status = (Status)value;
            switch (status)
            {
                case Status.Unscheduled:
                    return Brushes.Black;

                case Status.Scheduled:
                    return Brushes.Blue;

                case Status.OnTrack:
                    return Brushes.Yellow;

                case Status.Done:
                    return Brushes.Green;

                default:
                    return Brushes.Black;
            }
        }
        catch { return Brushes.Black; }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

class ConvertStatusToColor : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            if (value is BO.Status status)
            {
                switch (status)
                {
                    case BO.Status.Unscheduled:
                        return Brushes.LightGray;
                    case BO.Status.Scheduled:
                        return Brushes.LightGoldenrodYellow;
                    case BO.Status.OnTrack:
                        return Brushes.Yellow;
                    case BO.Status.Done:
                        return Brushes.Orange;
                    default: return Brushes.Black;
                }
            }
        }
        catch { }

        return Brushes.Black;

    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}