using System.Text.Json.Serialization;

namespace Models;

public class Bonus
{
	public IList<IDictionary<string, int>> Options { get; set; }
	public IDictionary<string, int> Default { get; set; }
}
