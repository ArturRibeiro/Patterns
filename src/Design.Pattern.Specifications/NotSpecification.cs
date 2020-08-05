using System;
using System.Linq.Expressions;
using Design.Pattern.Specifications.Expressions;

namespace Design.Pattern.Specifications
{
    internal sealed class NotSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _specification;
        public NotSpecification(Specification<T> specification)
            => _specification = specification;

        public override Expression<Func<T, bool>> ToExpression()
            => NotSpecificationExpression.GetExpression(_specification);
    }
}