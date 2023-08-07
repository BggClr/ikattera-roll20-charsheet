using System.Text.Json.Serialization;

namespace Models;

public class Skill : CharacterFeature
{
	[JsonPropertyName("depends_on")]
	public IList<string> DependsOn { get; set; }
	[JsonPropertyName("custom_type")]
	public IList<string> CustomType { get; set; }
	public override string FeatureType => "skill";
}
