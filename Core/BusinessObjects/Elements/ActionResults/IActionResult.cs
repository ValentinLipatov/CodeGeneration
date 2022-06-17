using System;

namespace CodeGeneration.BusinessObjects
{
    public interface IActionResult
    {
        IField Field { get; }

        string Description { get; }

        ActionResultType Type { get; }
    }
}