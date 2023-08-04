namespace Models;

public class CharacterClass : AttributeEntity
{
	public IList<CharacterSubclass> Subclasses { get; set; }
}
