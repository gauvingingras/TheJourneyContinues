using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace TheJourneyContinues.Projectiles
{
    public abstract class _BaseProjectile : ModProjectile
    {
        public sealed override void SetDefaults()
        {
            if (!Main.dedServ)
            {
                Texture2D texture = ModContent.GetTexture(Texture);

                projectile.width = texture.Width;
                projectile.height = texture.Height;
            }

            SetProjectileDefaults();
        }

        protected virtual void SetProjectileDefaults() { }
    }
}
