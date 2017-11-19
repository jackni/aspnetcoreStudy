namespace NetCoreWebApi.Services
{
    public interface ICalcuator
    {
        float Add(float x, float y);
        float Divide(float x, float y);
        float Multiply(float x, float y);
        float Subtract(float x, float y);
    }
}