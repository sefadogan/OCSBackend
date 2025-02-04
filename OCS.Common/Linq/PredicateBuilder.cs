using System.Linq.Expressions;

namespace OCS.Common.Linq
{
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> True<T>() => f => true;
        public static Expression<Func<T, bool>> False<T>() => f => false;

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> firstExpression, Expression<Func<T, bool>> secondExpression)
            => Expression.Lambda<Func<T, bool>>(Expression.Or(firstExpression.Body, Invoke(firstExpression, secondExpression)), firstExpression.Parameters);

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> firstExpression, Expression<Func<T, bool>> secondExpression)
            => Expression.Lambda<Func<T, bool>>(Expression.And(firstExpression.Body, Invoke(firstExpression, secondExpression)), firstExpression.Parameters);

        private static InvocationExpression Invoke<T>(Expression<Func<T, bool>> firstExpression, Expression<Func<T, bool>> secondExpression)
            => Expression.Invoke(secondExpression, firstExpression.Parameters.Cast<Expression>());
    }
}
