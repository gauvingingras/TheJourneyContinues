using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace TheJourneyContinues
{
    public class TheJourneyContinuesPlayer : ModPlayer
    {
        private const string ARCANE_FRUITS = "arcaneFruits";

        public int arcaneFruits;

        public override void ResetEffects()
        {
            player.statManaMax2 += arcaneFruits * 5;
        }

        public override void Load(TagCompound tag)
        {
            arcaneFruits = tag.GetInt(ARCANE_FRUITS);
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                { ARCANE_FRUITS, arcaneFruits }
            };
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();
            packet.Write(arcaneFruits);
        }
    }
}
