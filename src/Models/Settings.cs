using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace Models;

public static class Settings
{
	public static JsonSerializerOptions JsonSerializerOptions => new()
	{
		PropertyNameCaseInsensitive = true,
		Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
	};
}
