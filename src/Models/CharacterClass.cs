using System.ComponentModel;

namespace Models;

[DisplayName("Class")]
public class CharacterClass : AttributeEntity
{
	public IList<CharacterSubclass> Subclasses { get; set; }
}
