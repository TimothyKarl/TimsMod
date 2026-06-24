using Terraria.ModLoader;

namespace TimsMod.Common.Systems
{
    public class CustomMenu : ModMenu
    {
        // 1. Point this to the asset path of your custom menu track
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/isntshelovely");

        // 2. Control what name displays at the bottom of the menu when selected
        public override string DisplayName => "Tim's Mod Menu";

        // 3. Optional: You can also change the main menu logo!
        // To use a custom logo, uncomment the lines below and place a 'MenuLogo.png' in your Assets folder
        /*
        public override Microsoft.Xna.Framework.Graphics.Texture2D Logo => 
            ModContent.Request<Microsoft.Xna.Framework.Graphics.Texture2D>("TimsMod/Assets/MenuLogo").Value;
        */
    }
}