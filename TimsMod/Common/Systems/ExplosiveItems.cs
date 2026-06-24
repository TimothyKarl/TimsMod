using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace TimsMod.Common.Systems
{
    public class ExplosiveItems : GlobalItem
    {
        public override bool? UseItem(Item item, Player player)
        {
            // 1. Explode if it's a healing item (checks if it restores health)
            if (item.healLife > 0)
            {
                ExplodePlayer(player, "was allergic to medicine.");
                return true;
            }

            // 2. Explode if it's a food item (checks if it grants any tier of the Well Fed buff)
            if (item.buffType == BuffID.WellFed || item.buffType == BuffID.WellFed2 || item.buffType == BuffID.WellFed3)
            {
                ExplodePlayer(player, "bit into a spicy meatball (it was a pipe bomb).");
                return true;
            }

            // 3. 50/50 chance to explode if using a Life Crystal
            if (item.type == ItemID.LifeCrystal)
            {
                if (Main.rand.NextBool(2))
                {
                    ExplodePlayer(player, "had a literal heartbreak.");
                }
                else
                {
                    Main.NewText("Lucky! You survived the Heart Crystal.");
                }
            }

            return null;
        }

        public static void ExplodePlayer(Player player, string deathMessage)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item14, player.position);

                Projectile.NewProjectile(
                    player.GetSource_FromThis(),
                    player.Center,
                    Vector2.Zero,
                    ProjectileID.ExplosiveBunny,
                    1000,
                    10f,
                    player.whoAmI
                );

                player.KillMe(
                    Terraria.DataStructures.PlayerDeathReason.ByCustomReason(NetworkText.FromLiteral($"{player.name} {deathMessage}")),
                    9999,
                    0
                );
            }
        }
    }
}