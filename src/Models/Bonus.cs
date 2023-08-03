using System.Text.Json.Serialization;

namespace Models;

public class Bonus
{
	public int AttributesFree { get; set; }
	public int SkillsFree { get; set; }
	[JsonPropertyName("hp")]
	public int Health { get; set; }
	public int Stamina { get; set; }
	public IDictionary<string, int> Attributes { get; set; }
	public IDictionary<string, int> Skills { get; set; }
	public IDictionary<string, int> Weapon { get; set; }
}
