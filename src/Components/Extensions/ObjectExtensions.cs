using System.ComponentModel;
using System.Reflection;
using Models;

namespace Components.Extensions;

public static class ObjectExtensions
{
	public static string GetEntityPrefix(this object obj)
	{
		var type = obj.GetType();
		var prefix = type.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? type.Name;

		return prefix.ToLowerInvariant();
	}
}
