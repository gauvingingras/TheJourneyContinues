using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheJourneyContinues.Items
{
    public abstract class _BaseItem : ModItem
    {
        protected virtual int Rare => ItemRarityID.White;
        protected virtual int Value => 0;

        public sealed override void SetDefaults()
        {
            if (!Main.dedServ) {
                Texture2D texture = ModContent.GetTexture(Texture);

                item.width = texture.Width;
                item.height = texture.Height;
            }
            
            item.value = Value;
            item.rare = Rare;

            SetItemDefaults();
        }

        protected virtual void SetItemDefaults() { }
    }
}
