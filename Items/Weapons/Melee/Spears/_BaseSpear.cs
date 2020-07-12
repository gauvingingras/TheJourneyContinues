using Terraria;
using Terraria.ID;

namespace TheJourneyContinues.Items.Weapons.Melee.Spears
{
    public abstract class _BaseSpear : _BaseItem
    {
        protected abstract int Damage { get; }
        protected abstract int UseTime { get; }
        protected abstract float ShootSpeed { get; }
        protected abstract float Knockback { get; }
        protected abstract int Projectile { get; }

        protected override void SetItemDefaults()
        {
            item.damage = Damage;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = UseTime;
            item.useTime = UseTime;
            item.shootSpeed = ShootSpeed;
            item.knockBack = Knockback;
            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.shoot = Projectile;

            SetSpearDefaults();
        }

        protected virtual void SetSpearDefaults() { }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
    }
}
