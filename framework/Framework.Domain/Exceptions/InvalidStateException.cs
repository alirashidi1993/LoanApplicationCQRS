namespace Framework.Domain.Exceptions
{
    public class InvalidStateException : Exception
    {
        public InvalidStateException(string state, string operation):base($"Cannot '{operation}' in '{state}' State")
        {
            State = state;
            Operation = operation;
        }

        public InvalidStateException(object state, string operation) : this(state.GetType().Name,operation)
        {
            
        }

        public string State { get; private set; }
        public string Operation { get; private set; }
    }
}
