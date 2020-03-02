using GameCore;

namespace NineThreeNineInfection
{
    public static class Config
    {

        public static bool EnableByDefault;
        public static int InfectedHP;

        public static void ReloadConfig()
        {
            EnableByDefault = ConfigFile.ServerConfig.GetBool("NTNI_enable", false);
            InfectedHP = ConfigFile.ServerConfig.GetInt("NTNI_infectedhp", 800);
        }
    }
}
