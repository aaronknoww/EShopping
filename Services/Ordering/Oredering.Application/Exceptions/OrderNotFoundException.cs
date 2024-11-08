using System;

namespace Ordering.Application.Extensions;

public class OrderNotFoundException : ApplicationException
{
    public OrderNotFoundException(string name, Object key) : base($"Entity {name} - {key} is not found.")
    {
        
    }

}
