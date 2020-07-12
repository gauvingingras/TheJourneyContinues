using Terraria.Audio;
using Terraria.ID;

namespace TheJourneyContinues.Items.Weapons.Melee.Swords
{
    public abstract class _BaseSword : _BaseItem
    {
        protected abstract int Damage { get; }
        protected abstract int UseTime { get; }
        protected abstract float Knockback { get; }
        protected virtual LegacySoundStyle UseSound => SoundID.Item1;

        protected sealed override void SetItemDefaults()
        {
            item.damage = Damage;
            item.melee = true;
            item.useTime = UseTime;
            item.useAnimation = UseTime;
            item.knockBack = Knockback;
            item.UseSound = UseSound;
            item.useStyle = ItemUseStyleID.SwingThrow;

            SetSwordDefaults();
        }

        protected virtual void SetSwordDefaults() { }
    }
}
