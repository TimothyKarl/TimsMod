using Terraria;
using Terraria.ModLoader;

namespace TimsMod.Common.Systems
{
    public class SnowMusic : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/AngPaskoAySumapit");

        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override bool IsSceneEffectActive(Terraria.Player player)
        {
            return !player.ZoneUnderworldHeight
                && !player.ZoneDungeon
                && !player.ZoneForest
                && !player.ZoneJungle
                && !player.ZoneDesert
                && !player.ZoneBeach
                && !player.ZoneCorrupt
                && !player.ZoneCrimson
                && !player.ZoneHallow
                && player.ZoneOverworldHeight
                
                && Main.dayTime;
        }
    }
}