using Components.ViewModels;
using Models;

namespace Components.Extensions;

public static class CharacterManifestExtensions
{
	public static IList<OptionModel> GetLevelBonusOptions(this CharacterManifest manifest)
	{
		var labels = manifest.GetLabels();
		var rootBonusesOptions = manifest.LevelBonus
			.Where(p => p.Value.Options is {Count: > 0 })
			.Select(p => new OptionModel
			{
				Key = $"level_option_{p.Key}",
				Description = $"Уровень {p.Key}",
				Options = p.Value.Options.Select(q => string.Join(", ", q.Select(t => $"{(labels.TryGetValue(t.Key, out var label) ? label : t.Key)}: {t.Value}"))).ToArray()
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
				Description = $"Уровень {p.Level} - {p.Entity.Title}",
				Options = p.Value.Options.Select(q => string.Join(", ", q.Select(t => $"{(labels.TryGetValue(t.Key, out var label) ? label : t.Key)}: {t.Value}"))).ToArray()
			}).ToArray();

		return rootBonusesOptions
			.Concat(featureBonusesOptions)
			.ToArray();
	}
}
