using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheJourneyContinues
{
    public class TheJourneyContinues : Mod
    {
        public static string GithubUserName => "gauvingingras";
        public static string GithubProjectName => "TheJourneyContinues";

        private static readonly int UI_ScreenAnchorX = Main.screenWidth - 800;
        private static float UIDisplay_ManaPerStar;

        public override void Load()
        {
            On.Terraria.Main.DrawInterface_Resources_Mana += Main_DrawInterface_Resources_Mana;
        }

        public override void Unload()
        {
            On.Terraria.Main.DrawInterface_Resources_Mana -= Main_DrawInterface_Resources_Mana;
        }

        private void Main_DrawInterface_Resources_Mana(On.Terraria.Main.orig_DrawInterface_Resources_Mana orig)
        {
            // Code borrowed and adapted from SteviesMod because I wanted it in a mod but did not like all the other contents it included (check it out: https://github.com/Steviegt6/SteviesMod/)
            if (Main.player[Main.myPlayer].statManaMax2 / 10 >= 20)
            {
                UIDisplay_ManaPerStar = Main.player[Main.myPlayer].statManaMax2 / 10;
            }
            else
            {
                UIDisplay_ManaPerStar = 20;
            }

            if (Main.LocalPlayer.ghost || Main.player[Main.myPlayer].statManaMax2 <= 0)
            {
                return;
            }

            _ = Main.player[Main.myPlayer].statManaMax / 20;
            int num17 = Main.player[Main.myPlayer].GetModPlayer<TheJourneyContinuesPlayer>().arcaneFruits;
            if (num17 < 0)
            {
                num17 = 0;
            }

            if (num17 > 0)
            {
                _ = Main.player[Main.myPlayer].statManaMax / (20 + num17 / 4);
            }

            _ = Main.player[Main.myPlayer].statManaMax2 / 20;
            Vector2 vector = Main.fontMouseText.MeasureString(Language.GetTextValue("LegacyInterface.2"));
            int num8 = 50;
            if (vector.X >= 45f)
            {
                num8 = (int)vector.X + 5;
            }

            DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, Main.fontMouseText, Language.GetTextValue("LegacyInterface.2"), new Vector2(800 - num8 + UI_ScreenAnchorX, 6f), new Color(Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor), 0f, default, 1f, SpriteEffects.None, 0f);
            if (UIDisplay_ManaPerStar <= 20)
            {
                for (int i = 1; i < Main.player[Main.myPlayer].statManaMax2 / UIDisplay_ManaPerStar + 1; i++)
                {
                    bool flag = false;
                    float num6 = 1f;
                    int num7;
                    if (Main.player[Main.myPlayer].statMana >= i * UIDisplay_ManaPerStar)
                    {
                        num7 = 255;
                        if (Main.player[Main.myPlayer].statMana == i * UIDisplay_ManaPerStar)
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        float num4 = (Main.player[Main.myPlayer].statMana - (i - 1) * UIDisplay_ManaPerStar) / UIDisplay_ManaPerStar;
                        num7 = (int)(30f + 225f * num4);
                        if (num7 < 30)
                        {
                            num7 = 30;
                        }
                        num6 = num4 / 4f + 0.75f;
                        if (num6 < 0.75)
                        {
                            num6 = 0.75f;
                        }
                        if (num4 > 0f)
                        {
                            flag = true;
                        }
                    }

                    if (flag)
                    {
                        num6 += Main.cursorScale - 1f;
                    }

                    int a = (int)((float)num7 * 0.9);
                    if (!Main.player[Main.myPlayer].ghost)
                    {
                        if (num17 > 0)
                        {
                            num17--;
                            Main.spriteBatch.Draw(GetTexture("Items/Miscellaneous/Consumables/ArcaneFruit_Overlay"), new Vector2(775 + UI_ScreenAnchorX, 30 + Main.manaTexture.Height / 2 + (Main.manaTexture.Height - Main.manaTexture.Height * num6) / 2f + 28 * (i - 1)), new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height), new Color(num7, num7, num7, a), 0f, new Vector2(Main.manaTexture.Width / 2, Main.manaTexture.Height / 2), num6, SpriteEffects.None, 0f);
                        }
                        else
                        {
                            Main.spriteBatch.Draw(Main.manaTexture, new Vector2(775 + UI_ScreenAnchorX, 30 + Main.manaTexture.Height / 2 + (Main.manaTexture.Height - Main.manaTexture.Height * num6) / 2f + 28 * (i - 1)), new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height), new Color(num7, num7, num7, a), 0f, new Vector2(Main.manaTexture.Width / 2, Main.manaTexture.Height / 2), num6, SpriteEffects.None, 0f);
                        }
                    }
                }
            }
            else if (UIDisplay_ManaPerStar > 20)
            {
                for (int i = 1; i < Main.player[Main.myPlayer].statManaMax2 / UIDisplay_ManaPerStar + 1; i++)
                {
                    bool flag = false;
                    float num6 = 1f;
                    int num7;
                    if (Main.player[Main.myPlayer].statMana >= i * UIDisplay_ManaPerStar)
                    {
                        num7 = 255;
                        if (Main.player[Main.myPlayer].statMana == i * UIDisplay_ManaPerStar)
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        float num4 = (Main.player[Main.myPlayer].statMana - (i - 1) * UIDisplay_ManaPerStar) / UIDisplay_ManaPerStar;
                        num7 = (int)(30f + 225f * num4);
                        if (num7 < 30)
                        {
                            num7 = 30;
                        }

                        num6 = num4 / 4f + 0.75f;
                        if (num6 < 0.75)
                        {
                            num6 = 0.75f;
                        }

                        if (num4 > 0f)
                        {
                            flag = true;
                        }
                    }

                    if (flag)
                    {
                        num6 += Main.cursorScale - 1f;
                    }

                    int a = (int)((float)num7 * 0.9);
                    if (!Main.player[Main.myPlayer].ghost)
                    {
                        if (num17 > 0)
                        {
                            num17--;
                            Main.spriteBatch.Draw(GetTexture("Items/Miscellaneous/Consumables/ArcaneFruit_Overlay"), new Vector2(775 + UI_ScreenAnchorX, 30 + Main.manaTexture.Height / 2 + (Main.manaTexture.Height - Main.manaTexture.Height * num6) / 2f + 28 * (i - 1)), new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height), new Color(num7, num7, num7, a), 0f, new Vector2(Main.manaTexture.Width / 2, Main.manaTexture.Height / 2), num6, SpriteEffects.None, 0f);
                        }
                        else
                        {
                            Main.spriteBatch.Draw(Main.manaTexture, new Vector2(775 + UI_ScreenAnchorX, 30 + Main.manaTexture.Height / 2 + (Main.manaTexture.Height - Main.manaTexture.Height * num6) / 2f + 28 * (i - 1)), new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height), new Color(num7, num7, num7, a), 0f, new Vector2(Main.manaTexture.Width / 2, Main.manaTexture.Height / 2), num6, SpriteEffects.None, 0f);
                        }
                    }
                }
            }
        }
    }
}