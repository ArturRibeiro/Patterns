using System;
using System.Linq.Expressions;

namespace Design.Pattern.Specifications
{
    internal sealed class IdentitySpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            return x => true;
        }
    }
}