namespace Components.ViewModels;

public class OptionModel
{
	public string Key { get; set; }
	public IList<OptionLabelModel> Label { get; set; }
}

public class OptionLabelModel
{
	public string Value { get; set; }
	public string Divider { get; set; }
	public bool IsTranslated { get; set; }
}
