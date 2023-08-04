namespace Models;

public class AttributeEntity
{
	public string Title { get; set; }
	public string Name { get; set; }
	public IDictionary<int, IDictionary<string, int>> LevelBonus { get; set; }
}
