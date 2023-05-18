namespace RocketPluginHelper.Reflecting;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static class Reflector
{
    public static string ReflectObject(Type type, object instance, string name)
    {
        var builder = new StringBuilder()
            .AppendLine($"#{name ?? "_"}: {type.Name} = {instance ?? "NULL"}");

        if (type != null && instance != null)
        {
            var members = type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(m => m.MemberType == MemberTypes.Field || m.MemberType == MemberTypes.Property);

            foreach (var member in members)
            {
                if (member is PropertyInfo property && property.CanRead)
                {
                    object? value;
                    try
                    {
                        value = property.GetValue(instance);
                    }
                    catch
                    {
                        value = "ERROR ON GETTING VALUE";
                    }

                    var outputValue = value?.ToString() ?? "NULL";
                    switch (value)
                    {
                        case string:
                        {
                            outputValue = $"\"{value}\"";
                            break;
                        }
                        case IEnumerable enumerable:
                        {
                            outputValue = $"{value.GetType()}";

                            var count = 0;
                            var items = "";
                            IEnumerator? enumerator = null;
                            try
                            {
                                enumerator = enumerable.GetEnumerator();
                            }
                            catch
                            {
                                // ignored
                            }
                            if (enumerator != null)
                            {
                                try
                                {
                                    while (enumerator.MoveNext())
                                    {
                                        items += enumerator.Current?.ToString() ?? "NULL" + ", ";
                                        count++;
                                    }
                                }
                                catch
                                {
                                    // ignored
                                }
                            }

                            outputValue += $"({count}) [{items.Trim(' ').Trim(',')}]";
                            break;
                        }
                    }

                    builder.AppendLine($"- {property.Name ?? "_"}: \t{property.PropertyType.Name} \t = {outputValue}");
                }
                else if (member is FieldInfo field)
                {
                    object? value;
                    try
                    {
                        value = field.GetValue(instance);
                    }
                    catch
                    {
                        value = "ERROR ON GETTING VALUE";
                    }

                    var outputValue = value?.ToString() ?? "NULL";
                    if (value is string)
                    {
                        outputValue = $"\"{value}\"";
                    }
                    else if (value is IEnumerable enumerable)
                    {
                        outputValue = $"{value.GetType()}";

                        var count = 0;
                        var items = "";
                        IEnumerator? enumerator = null;
                        try
                        {
                            enumerator = enumerable.GetEnumerator();
                        }
                        catch
                        {
                            // ignored
                        }
                        if (enumerator != null)
                        {
                            try
                            {
                                while (enumerator.MoveNext())
                                {
                                    items += enumerator.Current?.ToString() ?? "NULL" + ", ";
                                    count++;
                                }
                            }
                            catch
                            {
                                // ignored
                            }
                        }

                        outputValue += $"({count}) [{items.Trim(' ').Trim(',')}]";
                    }

                    builder.AppendLine($"- {field.Name ?? "_"}: \t{field.FieldType.Name} \t = {outputValue}");
                }
            }
        }

        return builder.ToString();
    }
    public static string CompareObjects(Type type, object left, object right, string name)
    {
        var builder = new StringBuilder()
            .AppendLine($"#{name ?? "_"}: ({type.Name}) {left ?? "NULL"} == {right ?? "NULL"} = {(left == right).ToString().ToUpper()}");

        if (type != null && (left != null || right != null))
        {
            var members = type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(m => m.MemberType == MemberTypes.Field || m.MemberType == MemberTypes.Property);

            foreach (var member in members)
            {
                if (member is PropertyInfo property && property.CanRead)
                {
                    object? leftValue = null;
                    try
                    {
                        leftValue = property.GetValue(left);
                    }
                    catch
                    {
                        leftValue = "ERROR ON GETTING LEFT VALUE";
                    }

                    object? rightValue = null;
                    try
                    {
                        rightValue = property.GetValue(right);
                    }
                    catch
                    {
                        rightValue = "ERROR ON GETTING RIGHT VALUE";
                    }

                    var leftOutput = leftValue?.ToString() ?? "NULL";
                    if (leftValue is string)
                    {
                        leftOutput = $"\"{leftValue}\"";
                    }
                    else if (leftValue is IEnumerable enumerable)
                    {
                        leftOutput = $"{leftValue.GetType()}";

                        var count = 0;
                        var items = "";
                        IEnumerator? enumerator = null;
                        try
                        {
                            enumerator = enumerable.GetEnumerator();
                        }
                        catch
                        {
                            // ignored
                        }

                        if (enumerator != null)
                        {
                            try
                            {
                                while (enumerator.MoveNext())
                                {
                                    items += enumerator.Current?.ToString() ?? "NULL" + ", ";
                                    count++;
                                }
                            }
                            catch
                            {
                                // ignored
                            }
                        }

                        leftOutput += $"({count}) [{items.Trim(' ').Trim(',')}]";
                    }

                    var rightOutput = rightValue?.ToString() ?? "NULL";
                    if (rightValue is string)
                    {
                        rightOutput = $"\"{rightValue}\"";
                    }
                    else if (rightValue is IEnumerable enumerable)
                    {
                        rightOutput = $"{rightValue.GetType()}";

                        var count = 0;
                        var items = "";
                        IEnumerator? enumerator = null;
                        try
                        {
                            enumerator = enumerable.GetEnumerator();
                        }
                        catch
                        {
                            // ignored
                        }

                        if (enumerator != null)
                        {
                            try
                            {
                                while (enumerator.MoveNext())
                                {
                                    items += enumerator.Current?.ToString() ?? "NULL" + ", ";
                                    count++;
                                }
                            }
                            catch
                            {
                                // ignored
                            }
                        }

                        rightOutput += $"({count}) [{items.Trim(' ').Trim(',')}]";
                    }

                    builder.AppendLine($"- {property.Name ?? "_"}: \t({property.PropertyType.Name}) \t {leftOutput} == {rightOutput} = {(leftValue == rightValue).ToString().ToUpper()}");
                }
                else if (member is FieldInfo field)
                {
                    object? leftValue;
                    try
                    {
                        leftValue = field.GetValue(left);
                    }
                    catch
                    {
                        leftValue = "ERROR ON GETTING LEFT VALUE";
                    }

                    object? rightValue;
                    try
                    {
                        rightValue = field.GetValue(right);
                    }
                    catch
                    {
                        rightValue = "ERROR ON GETTING RIGHT VALUE";
                    }

                    var leftOutput = leftValue?.ToString() ?? "NULL";
                    if (leftValue is string)
                    {
                        leftOutput = $"\"{leftValue}\"";
                    }
                    else if (leftValue is IEnumerable enumerable)
                    {
                        leftOutput = $"{leftValue.GetType()}";

                        var count = 0;
                        var items = "";
                        IEnumerator? enumerator = null;
                        try
                        {
                            enumerator = enumerable.GetEnumerator();
                        }
                        catch
                        {
                            // ignored
                        }

                        if (enumerator != null)
                        {
                            try
                            {
                                while (enumerator.MoveNext())
                                {
                                    items += enumerator.Current?.ToString() ?? "NULL" + ", ";
                                    count++;
                                }
                            }
                            catch
                            {
                                // ignored
                            }
                        }

                        leftOutput += $"({count}) [{items.Trim(' ').Trim(',')}]";
                    }

                    var rightOutput = rightValue?.ToString() ?? "NULL";
                    if (rightValue is string)
                    {
                        rightOutput = $"\"{rightValue}\"";
                    }
                    else if (rightValue is IEnumerable enumerable)
                    {
                        rightOutput = $"{rightValue.GetType()}";

                        var count = 0;
                        var items = "";
                        IEnumerator? enumerator = null;
                        try
                        {
                            enumerator = enumerable.GetEnumerator();
                        }
                        catch
                        {
                            // ignored
                        }

                        if (enumerator != null)
                        {
                            try
                            {
                                while (enumerator.MoveNext())
                                {
                                    items += enumerator.Current?.ToString() ?? "NULL" + ", ";
                                    count++;
                                }
                            }
                            catch
                            {
                                // ignored
                            }
                        }

                        rightOutput += $"({count}) [{items.Trim(' ').Trim(',')}]";
                    }

                    builder.AppendLine($"- {field.Name ?? "_"}: \t({field.FieldType.Name}) \t {leftOutput} == {rightOutput} = {(leftValue == rightValue).ToString().ToUpper()}");
                }
            }
        }
        return builder.ToString();
    }
}