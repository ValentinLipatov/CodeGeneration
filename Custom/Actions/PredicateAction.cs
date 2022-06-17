using CodeGeneration.BusinessObjects;

namespace CodeGeneration
{
    public class PredicateAction : Action
    {
        public PredicateAction(IBusinessObject businessObject, string name, string caption, System.Action predicate) : base (businessObject, name, caption)
        {
            Predicate = predicate;
        }

        public System.Action Predicate { get; set; }

        public override void Execute()
        {
            Predicate?.Invoke();
        }
    }
}