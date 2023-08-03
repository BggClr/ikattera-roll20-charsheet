using System.Text.Json;
using System.Text.Unicode;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Razor.Templating.Core;

var services = new ServiceCollection();
services.AddWebEncoders(o => {
	o.TextEncoderSettings = new System.Text.Encodings.Web.TextEncoderSettings(UnicodeRanges.All);
});
services.AddRazorTemplating();

var jsonContent = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ikattera.json"));

var data = JsonSerializer.Deserialize<CharacterManifest>(jsonContent, Settings.JsonSerializerOptions);

var viewDataOrViewBag = new Dictionary<string, object>
{
	{
		"ModelJson", JsonSerializer.Serialize(JsonDocument.Parse(jsonContent), Settings.JsonSerializerOptions)
	}
};
var html = await RazorTemplateEngine.RenderAsync("/Views/Charsheet.cshtml", data, viewDataOrViewBag);
await File.WriteAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "result.html"), html);
