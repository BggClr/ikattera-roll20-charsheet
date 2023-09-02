using System.ComponentModel;

namespace Models;

[DisplayName("Attribute")]
public class CharacterAttribute : CharacterFeature
{
	public override string FeatureType => "attribute";
}
