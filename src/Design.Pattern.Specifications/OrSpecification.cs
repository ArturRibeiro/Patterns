using System;
using System.Linq.Expressions;
using Design.Pattern.Specifications.Expressions;

namespace Design.Pattern.Specifications
{
    internal sealed class OrSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;

        public OrSpecification(Specification<T> left, Specification<T> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
            => OrSpecificationExpression.GetExpression(_left, _right);
    }
}