using boo.Repos;

namespace boo.Stabil
{
    public  interface IBit
    {
        IAuthorRepo Authors { get; }
        IBookRepo Books { get; }
        void Complete();
    }
}
