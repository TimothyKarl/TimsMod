using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TimsMod.Common.Players
{
    public class DontKillFriends : ModPlayer
    {
        public override void OnHitByProjectile(Projectile proj, Player.HurtInfo hurtInfo)
        {
            if (proj.friendly && proj.owner != Player.whoAmI)
            {
                Player.Hurt(Terraria.DataStructures.PlayerDeathReason.ByCustomReason(
                    Terraria.Localization.NetworkText.FromLiteral($"{Player.name} dont hurt your friends stupidass")),
                    99999, 0);
                Projectile.NewProjectile(
                    Player.GetSource_FromThis(),
                    Player.position,
                    Main.rand.NextVector2Circular(5f, 5f),
                    ProjectileID.Explosives,
                    0, 0,
                    Player.whoAmI
                );
            }
        }
        
    }
}