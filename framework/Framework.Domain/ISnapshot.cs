namespace Framework.Domain
{
    public interface ISnapshot
    {
        long Version { get; set; }
    }
}
