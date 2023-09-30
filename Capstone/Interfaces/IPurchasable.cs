using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Interfaces
{
    public interface IPurchasable
    {
        string Name { get; }
        decimal Price { get; }
        string Coordinates { get; }
        string Message { get; }
    }   
}
