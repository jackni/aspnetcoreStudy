namespace NetCoreWebApi.Services
{
    public interface IMathService
    {
        string Add(float x, float y);
        string Divide(float x, float y);
        string Multiply(float x, float y);
        string Substract(float x, float y);
    }
}