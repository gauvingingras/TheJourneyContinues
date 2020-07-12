using Terraria;
using Terraria.ID;

namespace TheJourneyContinues.Items.Weapons.Melee.Swords
{
    public class PossessedSword : _BaseSword
    {
        protected override int Rare => ItemRarityID.LightRed;
        protected override int Value => Item.sellPrice(gold: 1);
        protected override int Damage => 40;
        protected override int UseTime => 23;
        protected override float Knockback => 4f;
    }
}
