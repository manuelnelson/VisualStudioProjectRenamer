namespace VSPRInterfaces
{
    public interface IRenamerFactory
    {
        IRenamer GetInstance(bool isUnderVersionControl);
    }
}