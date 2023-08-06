using System.Text.Json.Serialization;

namespace Models;

public class CharacterManifest
{
	public IList<Race> Races { get; set; }
	public IList<AttributeEntity> Origins { get; set; }
	public IList<CharacterClass> Classes { get; set; }
	public IList<CharacterAttribute> Attributes { get; set; }
	public IList<Skill> Skills { get; set; }
	public IList<Weapon> Weapons { get; set; }
	[JsonPropertyName("damage_types")]
	public IList<Entity> DamageTypes { get; set; }
	[JsonPropertyName("level_bonus")]
	public IDictionary<int, Bonus> LevelBonus { get; set; }

	public IDictionary<string, string> GetLabels()
	{
		return new[]
		{
			new KeyValuePair<string, string>("skills_free", "Очки навыков"),
			new KeyValuePair<string, string>("attributes_free", "Очки характеристик"),
			new KeyValuePair<string, string>("weapons_free", "Очки вооружения"),
			new KeyValuePair<string, string>("hp_base", "Здоровье"),
			new KeyValuePair<string, string>("stamina_base", "Выносливость"),
			new KeyValuePair<string, string>("potion_mod", "Элексиры"),
		}
			.Union(Attributes.Select(p => new KeyValuePair<string, string>(p.Name, p.Title)))
			.Union(Skills.Select(p => new KeyValuePair<string, string>(p.Name, p.Title)))
			.Union(Weapons.Select(p => new KeyValuePair<string, string>(p.Name, p.Title)))
			.ToDictionary(p => p.Key, p => p.Value);
	}
}
