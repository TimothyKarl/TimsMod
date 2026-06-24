using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.GameContent.Bestiary.BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions;

namespace TimsMod.Content.Items.Weapons
{
    public class NotNyzToday:ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToRangedWeapon(ProjectileID.MoonlordBullet, AmmoID.Bullet, 5, 16f, true);
            Item.SetWeaponValues(40, 5f);

            Item.width = 55;
            Item.height = 102;
            Item.rare = ItemRarityID.Purple;
            Item.UseSound = SoundID.Item11;
        }

            public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SandBlock, 100);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
        // The following method gives this gun a 38% chance to not consume ammo
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.50f;
        }
        // The following method allows this gun to shoot when having no ammo, as long as the player has at least 10 example items in their inventory.
        // The gun will then shoot as if the default ammo for it, in this case the musket ball, is being used.
       

        // The following method makes the gun slightly inaccurate
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));
        }

        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6f, -2f);
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
    }
    }

