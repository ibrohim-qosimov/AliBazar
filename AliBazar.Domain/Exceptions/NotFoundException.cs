namespace AliBazar.Domain.Exceptions;
public class NotFoundException : Exception
{
    public NotFoundException(string message = "Object not found")
        : base(message)
    {

    }
}