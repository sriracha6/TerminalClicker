using System;

namespace TerminalClicker
{
	public static class Player
	{
		[InSave] public static long Money;
        [InSave] public static long EgoPoints;
        [InSave] public static long SkillLevel;
        [InSave] public static long SkillLevelXP;
	}
}
