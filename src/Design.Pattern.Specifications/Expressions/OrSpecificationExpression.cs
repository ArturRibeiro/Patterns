using System;
using System.Linq.Expressions;

namespace Design.Pattern.Specifications.Expressions
{
    internal static class OrSpecificationExpression
    {
        public static Expression<Func<T, bool>> GetExpression<T>(Specification<T> left, Specification<T> right)
        {
            Expression<Func<T, bool>> leftExpression = left.ToExpression();
            Expression<Func<T, bool>> rightExpression = right.ToExpression();
            var invokedExpression = Expression.Invoke(rightExpression, leftExpression.Parameters);
            return (Expression<Func<T, Boolean>>)Expression.Lambda(Expression.OrElse(leftExpression.Body, invokedExpression), leftExpression.Parameters);
        }
    }
}