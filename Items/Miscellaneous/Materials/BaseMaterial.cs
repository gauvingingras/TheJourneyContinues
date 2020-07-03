namespace TheJourneyContinues.Items.Miscellaneous.Materials
{
    public abstract class BaseMaterial : BaseItem
    {
        protected override void SetItemDefaults()
        {
            item.maxStack = 999;
        }
    }
}
