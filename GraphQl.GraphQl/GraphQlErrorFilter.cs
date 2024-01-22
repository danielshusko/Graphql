namespace GraphQl.GraphQl;

public class GraphQlErrorFilter : IErrorFilter
{
    public IError OnError(IError error)
    {
        return error;
    }
}