using Terraria.Audio;
using Terraria.ID;

namespace TheJourneyContinues.Items.Weapons.Melee.Swords
{
    public class BloodyZombieArm : _BaseSword
    {
        protected override int Rare => ItemRarityID.Green;
        protected override int Damage => 20;
        protected override int UseTime => 23;
        protected override float Knockback => 6f;
        protected override LegacySoundStyle UseSound => SoundID.NPCHit18;
    }
}
