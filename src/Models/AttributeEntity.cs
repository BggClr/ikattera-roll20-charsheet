namespace Models;

public class AttributeEntity : Entity
{
	public IDictionary<int, IDictionary<string, int>> LevelBonus { get; set; }
}
