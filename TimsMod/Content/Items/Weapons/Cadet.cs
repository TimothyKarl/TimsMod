using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TimsMod.Content.Items.Weapons
{
    public class Cadet : ModItem
    {
        public override bool PreDrawInWorld(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Color lightColor, Microsoft.Xna.Framework.Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Lighting.AddLight(Item.position, 0f, 1f, 0f);
            return true;
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Magic;
            Item.damage = 45;
            Item.knockBack = 5;
            Item.mana = 5;

            Item.shoot = ProjectileID.ZapinatorLaser;
            Item.shootSpeed = 16f;

            Item.UseSound = SoundID.Item20;
            Item.rare = ItemRarityID.Purple;
            Item.value = Item.buyPrice(gold: 5);
        }
       
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 100);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
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