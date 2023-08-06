using System.Text.Json.Serialization;

namespace Models;

public class Skill : CharacterFeature
{
	[JsonPropertyName("depends_on")]
	public IList<string> DependsOn { get; set; }
	public override string FeatureType => "skill";
}
