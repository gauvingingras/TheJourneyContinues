using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace TheJourneyContinues.Items.Weapons.Melee.Swords
{
    public class TruffledZombieArm : BaseSword
    {
        protected override int Rare => ItemRarityID.Orange;
        protected override int Value => Item.sellPrice(gold: 1);
        protected override int Damage => 18;
        protected override int UseTime => 23;
        protected override float Knockback => 5f;

        protected override void SetSwordDefaults()
        {
            item.shoot = ProjectileID.TruffleSpore;
            item.shootSpeed = 8f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int proj = Projectile.NewProjectile(position.X + player.direction * (player.width + (item.width * item.scale)), position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 0f);
            Main.projectile[proj].melee = true;

            return false;
        }
    }
}
