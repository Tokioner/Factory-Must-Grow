using System;
using System.Collections.Generic;
using UnityEngine;

public static class ActionBus
{
    private static readonly Dictionary<string, Action<object>> events = new Dictionary<string, Action<object>>();

    public static void Subscribe(string eventName, Action<object> listener)
    {
        if (!events.ContainsKey(eventName))
        {
            events[eventName] = null;
        }
        events[eventName] += listener;
    }

    public static void Unsubscribe(string eventName, Action<object> listener)
    {
        if (events.ContainsKey(eventName))
        {
            events[eventName] -= listener;
        }
    }

    public static void TriggerEvent(string eventName, object parameter = null)
    {
        if (events.ContainsKey(eventName))
        {
            events[eventName]?.Invoke(parameter);
        }
    }
}
