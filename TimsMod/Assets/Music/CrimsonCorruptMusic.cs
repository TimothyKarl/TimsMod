using Terraria;
using Terraria.ModLoader;

namespace TimsMod.Common.Systems
{
    public class CrimsonCorruptMusic : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/lilium");

        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override bool IsSceneEffectActive(Terraria.Player player)
        {
            return !player.ZoneUnderworldHeight
                && !player.ZoneDungeon
                && !player.ZoneJungle
                && !player.ZoneSnow
                && !player.ZoneDesert
                && !player.ZoneForest
                && !player.ZoneBeach
                && !player.ZoneHallow
                && player.ZoneOverworldHeight;
        }
    }
}