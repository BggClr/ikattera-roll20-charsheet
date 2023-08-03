using System.Text.Json.Serialization;

namespace Models;

public abstract class CharacterFeature
{
	public string Name { get; set; }
	public string Title { get; set; }
	public int Value { get; set; }

	[JsonIgnore]
	public abstract string FeatureType { get; }
}
