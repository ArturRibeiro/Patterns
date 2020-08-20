namespace Design.Pattern.Applying.Functionals
{
    public struct Option<T>
    {
        private readonly T _value;
        
        public bool IsNone => _value == null || _value.Equals(default(T));

        public bool IsSome => !IsNone;

        public string Message { get; }

        public T Value => _value;

        internal Option(T value, string message = null)
        {
            _value = value;
            this.Message = message;
        }
        
        public static implicit operator Option<T>(T value) => Some(value);
        public static Option<T> Some(T value) => new Option<T>(value);
        
        public static Option<T> None(string message) => new Option<T>(default(T), message);
    }
}