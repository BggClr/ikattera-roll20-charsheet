using Models;

namespace Components.ViewModels;

public class CombatWeapon
{
	public int Index { get; set; }
	public CharacterManifest Manifest { get; set; }

	public bool Last { get; set; }
}
