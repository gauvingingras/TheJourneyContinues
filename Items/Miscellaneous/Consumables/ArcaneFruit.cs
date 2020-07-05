using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheJourneyContinues.Items.Miscellaneous.Consumables
{
    public class ArcaneFruit : BaseItem
    {
        protected override int Rare => ItemRarityID.Lime;
        protected override int Value => Item.sellPrice(gold: 2);

        protected override void SetItemDefaults()
        {
            item.maxStack = 99;
            item.useAnimation = 30;
            item.useTime = 30;
            item.value = Item.sellPrice(0, 2);
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item4;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statManaMax >= 200 && player.GetModPlayer<TheJourneyContinuesPlayer>().arcaneFruits < 10;
        }

        public override bool UseItem(Player player)
        {
            if (player.itemAnimation > 0 && player.statManaMax >= 200 && player.itemTime == 0)
            {
                player.itemTime = PlayerHooks.TotalUseTime(item.useTime, player, item);
                player.statManaMax2 += 5;
                player.GetModPlayer<TheJourneyContinuesPlayer>().arcaneFruits++;
                player.statMana += 5;

                if (Main.myPlayer == player.whoAmI)
                {
                    player.ManaEffect(5);
                }

                AchievementsHelper.HandleSpecialEvent(player, AchievementHelperID.Special.ConsumeStar);
            }

            return false;
        }
    }
}
