namespace TheJourneyContinues.Items.Miscellaneous.Materials
{
    public abstract class _BaseMaterial : _BaseItem
    {
        protected override void SetItemDefaults()
        {
            item.maxStack = 999;
        }
    }
}
