using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TimsMod.Content.Projectiles;

namespace TimsMod.Content.Items.Weapons
{
    public class Timothy : ModItem
    {
        public override void SetDefaults()
        {
            // These default values aside from Item.shoot match the Sunfury values, feel free to tweak them.
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.useAnimation = 45; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useTime = 45; // The item's use time in ticks (60 ticks == 1 second.)
            Item.knockBack = 6.75f; // The knockback of your flail, this is dynamically adjusted in the projectile code.
            Item.width = 30; // Hitbox width of the item.
            Item.height = 10; // Hitbox height of the item.
            Item.damage = 32; // The damage of your flail, this is dynamically adjusted in the projectile code.
            Item.crit = 7; // Critical damage chance %
            Item.scale = 1.1f;
            Item.noUseGraphic = true; // This makes sure the item does not get shown when the player swings his hand
            Item.shoot = ModContent.ProjectileType<TimothyProjectile>(); // The flail projectile
            Item.shootSpeed = 12f; // The speed of the projectile measured in pixels per frame.
            Item.UseSound = SoundID.Item1; // The sound that this item makes when used
            Item.rare = ItemRarityID.Orange; // The color of the name of your item
            Item.value = Item.sellPrice(gold: 2, silver: 50); // Sells for 2 gold 50 silver
            Item.DamageType = DamageClass.MeleeNoSpeed; // Deals melee damage
            Item.channel = true;
            Item.noMelee = true; // This makes sure the item does not deal damage from the swinging animation
        }

        public override Color? GetAlpha(Color lightColor)
        {
            // Aside from SetDefaults, when making a copy of a vanilla weapon you may have to hunt down other bits of code. This code makes the item draw in full brightness when dropped.
            return Color.White;
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
            recipe.AddIngredient(ItemID.StoneBlock, 100);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
