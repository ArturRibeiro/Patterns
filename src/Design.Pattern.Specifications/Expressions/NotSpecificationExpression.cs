using System;
using System.Linq;
using System.Linq.Expressions;

namespace Design.Pattern.Specifications.Expressions
{
    internal static class NotSpecificationExpression
    {
        public static Expression<Func<T, bool>> GetExpression<T>(Specification<T> specification)
        {
            Expression<Func<T, bool>> expression = specification.ToExpression();
            UnaryExpression notExpression = Expression.Not(expression.Body);
            return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters.Single());
        }
    }
}