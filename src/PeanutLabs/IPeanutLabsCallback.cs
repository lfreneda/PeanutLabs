namespace PeanutLabs
{
    public interface IPeanutLabsCallback
    {
        void Process(IRequestCallback requestCallback);
        bool ValidateRequest(IRequestCallback requestCallback);
    }
}