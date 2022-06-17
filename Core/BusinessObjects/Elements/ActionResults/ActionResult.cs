using System;

namespace CodeGeneration.BusinessObjects
{
    public class ActionResult : IActionResult
    {
        public ActionResult(IField field, string description, ActionResultType type)
        {
            Field = field;
            Description = description;
            Type = type;
        }

        public IField Field { get; protected set; }

        public string Description { get; protected set; }

        public ActionResultType Type { get; protected set; }
    }
}