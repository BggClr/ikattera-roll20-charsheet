namespace Models;

public class AttributeEntity
{
	public string Title { get; set; }
	public string Name { get; set; }
	public IDictionary<int, Bonus> LevelBonus { get; set; }
}
