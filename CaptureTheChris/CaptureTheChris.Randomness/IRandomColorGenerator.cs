using System;

namespace CaptureTheChris.Randomness
{
    public interface IRandomColorGenerator
    {
        TColor GetRandomColor<TColor>() where TColor : Enum;
    }
}