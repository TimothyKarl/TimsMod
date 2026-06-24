using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TimsMod.Common.Systems
{
    public class ExplosivePlayer : ModPlayer
    {
        public override void PostUpdate()
        {
            if (IsFishingBobberSpawned())
            {
                ExplosiveItems.ExplodePlayer(Player, "Beat the game dude, whyre you tryna fish.");
            }

            if (Main.InReforgeMenu && Main.reforgeItem.type != ItemID.None)
            {
                if (Main.mouseLeft && Main.mouseLeftRelease)
                {
                    ExplosiveItems.ExplodePlayer(Player, "Bro is like, 'what happened?' ");
                }
            }
        }

        private bool IsFishingBobberSpawned()
        {
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile p = Main.projectile[i];
                // Fixed: Replaced '61' with 'ProjAIStyleID.Bobber' as recommended in image_ced9d4.png
                if (p.active && p.owner == Player.whoAmI && p.aiStyle == ProjAIStyleID.Bobber)
                {
                    return true;
                }
            }
            return false;
        }
    }
}