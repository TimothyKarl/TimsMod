using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TimsMod.Content.Projectiles
{
    public class YoJohannProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Type] = 10f; // how long it stays out
            ProjectileID.Sets.YoyosMaximumRange[Type] = 300f; // max range
            ProjectileID.Sets.YoyosTopSpeed[Type] = 14f; // movement speed
        }

        public override void SetDefaults()
        {
            Projectile.width = 50;
            Projectile.height = 50;
            Projectile.aiStyle = ProjAIStyleID.Yoyo;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.penetrate = -1;
        }
    }
}