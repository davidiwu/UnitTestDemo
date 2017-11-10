namespace FeatureProject
{
    public class Bar
    {
        public virtual Baz Baz { get; set; }

        public virtual bool Submit()
        {
            return false;
        }
    }
}
