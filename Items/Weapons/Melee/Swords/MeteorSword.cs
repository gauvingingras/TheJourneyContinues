using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;

namespace TheJourneyContinues.Items.Weapons.Melee.Swords
{
    public class MeteorSword : BaseSword
    {
        protected override int Rare => ItemRarityID.Pink;
        protected override int Damage => 50;
        protected override int UseTime => 15;
        protected override float Knockback => 5f;

        protected override void SetSwordDefaults()
        {
            item.shoot = ProjectileID.Meteor1;
            item.shootSpeed = 8f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            // Random between 3 existing meteor types
            type = Main.rand.Next(new short[] { ProjectileID.Meteor1, ProjectileID.Meteor2, ProjectileID.Meteor3 });

            // Copied and adapted from Meteor Staff's source code
            int num101 = 1;
            for (int num102 = 0; num102 < num101; num102++)
            {
                position = new Vector2(player.position.X + player.width * 0.5f + Main.rand.Next(201) * -player.direction + (Main.mouseX + Main.screenPosition.X - player.position.X), player.MountedCenter.Y - 600f);
                position.X = (position.X + player.Center.X) / 2f + Main.rand.Next(-200, 201);
                position.Y -= 100 * num102;
                var num70 = Main.mouseX + Main.screenPosition.X - position.X + Main.rand.Next(-40, 41) * 0.03f;
                var num71 = Main.mouseY + Main.screenPosition.Y - position.Y;
                if (num71 < 0f)
                {
                    num71 *= -1f;
                }
                if (num71 < 20f)
                {
                    num71 = 20f;
                }
                var num72 = (float)Math.Sqrt(num70 * num70 + num71 * num71);
                num72 = item.shootSpeed / num72;
                num70 *= num72;
                num71 *= num72;
                float num103 = num70;
                float num104 = num71 + Main.rand.Next(-40, 41) * 0.02f;
                int proj = Projectile.NewProjectile(position.X, position.Y, num103 * 0.75f, num104 * 0.75f, type, damage * 2, knockBack, player.whoAmI, 0f, 0.5f + (float)Main.rand.NextDouble() * 0.3f);

                // Since this is an existing projectile, we want to convert damage type from magic (original) to melee
                Main.projectile[proj].magic = false;
                Main.projectile[proj].melee = true;
            }

            return false;
        }
    }
}
