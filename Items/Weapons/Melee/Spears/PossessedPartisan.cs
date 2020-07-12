using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheJourneyContinues.Projectiles.Weapons.Melee.Spears;

namespace TheJourneyContinues.Items.Weapons.Melee.Spears
{
    public class PossessedPartisan : _BaseSpear
    {
        protected override int Rare => ItemRarityID.LightRed;
        protected override int Value => Item.sellPrice(gold: 1);
        protected override int Damage => 40;
        protected override int UseTime => 25;
        protected override float ShootSpeed => 4f;
        protected override float Knockback => 6f;
        protected override int Projectile => ModContent.ProjectileType<PossessedPartisanProjectile>();
    }
}
