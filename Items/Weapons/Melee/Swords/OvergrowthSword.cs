using Terraria;
using Terraria.ID;

namespace TheJourneyContinues.Items.Weapons.Melee.Swords
{
    public class OvergrowthSword : _BaseSword
    {
        protected override int Rare => ItemRarityID.Orange;
        protected override int Value => Item.sellPrice(silver: 50);
        protected override int Damage => 25;
        protected override int UseTime => 30;
        protected override float Knockback => 8f;
    }
}
