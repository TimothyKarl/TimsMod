using Terraria;
using Terraria.ModLoader;

namespace TimsMod.Common.Systems
{
    public class DontKillFriends : ModSystem
    {
        public override void PostUpdatePlayers()
        {
            foreach (Player player in Main.player)
            {
                if (player.active)
                {
                    player.hostile = true;
                }
            }
        }
    }
}