using System.Text.Json.Serialization;

namespace Models;

public class CharacterManifest
{
	public IList<Race> Races { get; set; }
	public IList<CharacterAttribute> Attributes { get; set; }
	public IList<Skill> Skills { get; set; }
}