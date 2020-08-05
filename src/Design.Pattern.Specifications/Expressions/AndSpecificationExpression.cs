using System;
using System.Linq.Expressions;

namespace Design.Pattern.Specifications.Expressions
{
    internal static class AndSpecificationExpression
    {
        public static Expression<Func<T, bool>> GetExpression<T>(Specification<T> left, Specification<T> right)
        {
            try
            {
                Expression<Func<T, bool>> leftExpression = left.ToExpression();
                Expression<Func<T, bool>> rightExpression = right.ToExpression();
                var invokedExpression = Expression.Invoke(rightExpression, leftExpression.Parameters);
                return (Expression<Func<T, Boolean>>)Expression.Lambda(Expression.AndAlso(leftExpression.Body, invokedExpression), leftExpression.Parameters);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}