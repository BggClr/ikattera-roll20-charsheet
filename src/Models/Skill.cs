namespace Models;

public class Skill : CharacterFeature
{
	public IList<string> DependsOn { get; set; }
	public override string FeatureType => "skill";
}
