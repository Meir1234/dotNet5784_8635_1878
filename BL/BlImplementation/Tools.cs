﻿using BO;
using System.Collections;
using System.Reflection;

namespace BlImplementation;

internal static class Tools
{
    internal static Status GetStatus(DO.Task task)
    {
        return task.ScheduledDate is null ? Status.Unscheduled :
            task.StartDate is null ? Status.Scheduled :
            task.CompleteDate is null ? Status.OnTrack : Status.Done;
    }

    public static string ToStringProperty<T>(this T t, string str = " ")
    {
        IEnumerable<PropertyInfo> propertyInfos = t!.GetType().GetProperties();

        foreach (PropertyInfo item in propertyInfos)
        {
            object value = item.GetValue(t, null)!;

            if (value is not null)
            {
                if (value is IEnumerable objects and not string)
                {
                    str += "\n" + "items " + ":\n";
                    foreach (var obj in objects)
                        return obj.ToStringProperty(str);
                }
                else
                    str += "\n" + item.Name + ": " + value;

            }
        }
        return str;
    }
}
