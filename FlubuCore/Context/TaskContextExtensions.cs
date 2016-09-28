﻿using System.Collections.Generic;

namespace FlubuCore.Context
{
    public static class TaskContextExtensions
    {
        public static string ListToString<T>(this IList<T> list)
        {
            return string.Join(",", list);
        }
    }
}