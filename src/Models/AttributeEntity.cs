using System.Text.Json.Serialization;

namespace Models;

public class AttributeEntity : Entity
{
	[JsonPropertyName("level_bonus")]
	public IDictionary<int, Bonus> LevelBonus { get; set; }
}
