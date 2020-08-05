using System;
using System.Linq.Expressions;

namespace Design.Pattern.Specifications
{
    public abstract class Specification<T>
    {
        public static readonly Specification<T> All = new IdentitySpecification<T>();
        public abstract Expression<Func<T, bool>> ToExpression();
        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpression().Compile();
            return predicate(entity);
        }

        
        public Specification<T> And(Specification<T> specification) => new AndSpecification<T>(this, specification);

        public Specification<T> Or(Specification<T> specification) => new OrSpecification<T>(this, specification);
        
        public Specification<T> Not() => new NotSpecification<T>(this);
    }
}