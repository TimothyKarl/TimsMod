using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TimsMod.Content.Projectiles;
namespace TimsMod.Content.Items.Weapons
{
    public class GrayAsAZell : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 100;
            Item.height = 100;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 27;
            Item.knockBack = 10;
            Item.crit = 6;

            Item.value = Item.buyPrice(gold: 5, silver: 50);
            Item.rare = ItemRarityID.Purple;
            Item.UseSound = SoundID.Item1;

            Item.shoot = ModContent.ProjectileType<GrayAsAZellProjectile>();
            Item.shootSpeed = 10;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool? UseItem(Player player) // Method that gets called when the item is used. for effects and stuff.
        {
            if (player.altFunctionUse == 2)
            {
                if (player.itemTime == 0)
                {
                    player.itemTime = 150;

                    if (Main.rand.NextBool())
                    {
                        // Lucky - full heal
                        player.statLife = player.statLifeMax2;
                        player.HealEffect(player.statLifeMax2);
                    }
                    else
                    {
                        // Unlucky - explode the player
                        player.Hurt(Terraria.DataStructures.PlayerDeathReason.ByCustomReason(Terraria.Localization.NetworkText.FromLiteral($"{player.name} dumbass got unlucky lmao")), 9999, 0);
                    }
                }
            }
            return null;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            // Inflict the OnFire debuff for 1 second onto any NPC/Monster that this hits.
            // 60 frames = 1 second
            target.AddBuff(BuffID.OnFire, 360);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 100);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse != 2)
            {
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
    }
}
