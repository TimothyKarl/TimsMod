using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TimsMod.Content.Projectiles
{
    internal class GrayAsAZellProjectile:ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 100;
            Projectile.height = 73;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 10;
            Projectile.timeLeft = 720;
            Projectile.light = 0.5f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }
        public override void AI()
        {
            // Rotate the projectile to face its direction
            Projectile.rotation = Projectile.velocity.ToRotation();
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            // Bounce off tiles
            if (Projectile.velocity.X != oldVelocity.X)
                Projectile.velocity.X = -oldVelocity.X;
            if (Projectile.velocity.Y != oldVelocity.Y)
                Projectile.velocity.Y = -oldVelocity.Y;

            return false; // false = don't destroy projectile on tile hit
        }

    }
}
