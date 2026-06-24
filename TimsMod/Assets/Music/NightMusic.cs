using Terraria;
using Terraria.ModLoader;

namespace TimsMod.Common.Systems
{
    public class NightMusic : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/RosalinaInTheObservatory");

        // Fixed: Event sits exactly above Environment to beat your biome files
        public override SceneEffectPriority Priority => SceneEffectPriority.Event;

        public override bool IsSceneEffectActive(Player player)
        {
            // Only active at night, and stays quiet during actual events/bosses
            return !Main.dayTime
                && !Main.bloodMoon
                && !Main.eclipse;
        }
    }
}