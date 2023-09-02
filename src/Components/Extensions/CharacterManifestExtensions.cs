using System.ComponentModel;
using System.Reflection;
using Components.ViewModels;
using Models;

namespace Components.Extensions;

public static class CharacterManifestExtensions
{
	public static IList<OptionModel> GetLevelBonusOptions(this CharacterManifest manifest)
	{
		var xxx = manifest.LevelBonus
			.Where(p => p.Value.Options is { Count: > 0 })
			.ToArray();
		var xxx2 = manifest.Races
			.Concat(manifest.Races.SelectMany(p => p.Kinds?.OfType<AttributeEntity>().ToArray() ?? Array.Empty<AttributeEntity>()))
			.Concat(manifest.Classes)
			.Concat(manifest.Classes.SelectMany(p => p.Subclasses?.OfType<AttributeEntity>().ToArray() ?? Array.Empty<AttributeEntity>()))
			.Where(p => p.LevelBonus != null)
			.SelectMany(p => p.LevelBonus.Select(q => new {Entity = p, Level = q.Key, q.Value}))
			.Where(p => p.Value.Options is {Count: > 0 });

		var rootBonusesOptions = manifest.LevelBonus
			.Where(p => p.Value.Options is {Count: > 0 })
			.Select(p => new OptionModel
			{
				Key = $"level_option_{p.Key}",
				Label = new List<OptionLabelModel>
				{
					new() {Value = "level", IsTranslated = true},
					new() {Value = p.Key.ToString(), IsTranslated = false, Divider = "&nbsp;"},
				}
			}).ToArray();
		var featureBonusesOptions = manifest.Races
			.Concat(manifest.Races.SelectMany(p => p.Kinds?.OfType<AttributeEntity>().ToArray() ?? Array.Empty<AttributeEntity>()))
			.Concat(manifest.Classes)
			.Concat(manifest.Classes.SelectMany(p => p.Subclasses?.OfType<AttributeEntity>().ToArray() ?? Array.Empty<AttributeEntity>()))
			.Where(p => p.LevelBonus != null)
			.SelectMany(p => p.LevelBonus.Select(q => new {Entity = p, Level = q.Key, q.Value}))
			.Where(p => p.Value.Options is {Count: > 0 })
			.Select(p => new OptionModel
			{
				Key = $"level_option_{p.Entity.Name}_{p.Level}",
				Label = new List<OptionLabelModel>
				{
					new() {Value = "level", IsTranslated = true},
					new() {Value = p.Level.ToString(), IsTranslated = false, Divider = "&nbsp;"},
					new() {Value =  $"{p.Entity.GetEntityPrefix()}_{p.Entity.Name}", IsTranslated = true, Divider = "&nbsp;-&nbsp;"},
				}
			}).ToArray();

		return rootBonusesOptions
			.Concat(featureBonusesOptions)
			.ToArray();
	}

}
