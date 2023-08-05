using System.Text.Json.Serialization;

namespace Models;

public class CharacterManifest
{
	public IList<Race> Races { get; set; }
	public IList<CharacterClass> Classes { get; set; }
	public IList<CharacterAttribute> Attributes { get; set; }
	public IList<Skill> Skills { get; set; }
	public IList<Weapon> Weapons { get; set; }
}
