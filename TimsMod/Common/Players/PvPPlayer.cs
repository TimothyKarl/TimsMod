using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TimsMod.Common.Players
{
    public class PvPPlayer : ModPlayer
    {
        public override void OnHitByProjectile(Projectile proj, Player.HurtInfo hurtInfo)
        {
            if (proj.friendly && proj.owner != Player.whoAmI)
            {
                Player.Hurt(Terraria.DataStructures.PlayerDeathReason.ByCustomReason(
                    Terraria.Localization.NetworkText.FromLiteral($"{Player.name} got blown up")),
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