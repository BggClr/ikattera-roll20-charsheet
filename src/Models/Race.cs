namespace Models;

public class Race : AttributeEntity
{
	public IList<Kind> Kinds { get; set; }
}
