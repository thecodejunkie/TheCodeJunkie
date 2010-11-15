namespace TheCodeJunkie.Reflection
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// Contains helper methods for providing a strongly-typed reflection experience.
    /// </summary>
    public static class Member
    {
        /// <summary>
        /// Retrieves the member that is being invoked on an instance of an object.
        /// </summary>
        /// <param name="expression">A <see cref="Expression{TDelegate}"/> instance that the member should be retrieved from.</param>
        /// <returns>An <see cref="OfResult"/> instance for the retrieved member.</returns>
        /// <remarks>This method will be called for expressions that targets members that has no return value.</remarks>
        public static OfResult Of(Expression<Action> expression)
        {
            return GetResult(expression);
        }

        /// <summary>
        /// Retrieves the member that is being invoked on an instance of an object.
        /// </summary>
        /// <param name="expression">A <see cref="Expression{TDelegate}"/> instance that the member should be retrieved from.</param>
        /// <returns>An <see cref="OfResult"/> instance for the retrieved member.</returns>
        /// <remarks>This method will be called for expressions that targets members that has a return value.</remarks>
        public static OfResult Of(Expression<Func<object>> expression)
        {
            return GetResult(expression);
        }

        /// <summary>
        /// Retrieves member that is being identified using a strongly typed expression.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> used in the expression.</typeparam>
        /// <param name="expression">The strongly typed <see cref="Expression{TDelegate}"/> instance that the member should be retrieved for.</param>
        /// <returns>An <see cref="OfResult"/> instance for the retrieved member.</returns>
        /// <remarks>This method will be called for strongly-typed expressions with members that has no return value.</remarks>
        public static OfResult Of<T>(Expression<Action<T>> expression)
        {
            return GetResult(expression);
        }

        /// <summary>
        /// Retrieves member that is being identified using a strongly typed expression.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> used in the expression.</typeparam>
        /// <param name="expression">The strongly typed <see cref="Expression{TDelegate}"/> instance that the member should be retrieved for.</param>
        /// <returns>An <see cref="OfResult"/> instance for the retrieved member.</returns>
        /// <remarks>This method will be called for strongly-typed expressions with members that has a return value.</remarks>
        public static OfResult Of<T>(Expression<Func<T, object>> expression)
        {
            return GetResult(expression);
        }

        /// <summary>
        /// Gets the <see cref="MemberInfo"/> instance for <see cref="MemberExpression"/> expression.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> that the <see cref="MemberInfo"/> instance should be retrieved for.</param>
        /// <returns>A <see cref="MemberInfo"/> that was retrieved from the provided <see cref="MemberExpression"/> object.</returns>
        private static MemberInfo GetMemberAccessReturnValue(MemberExpression expression)
        {
            return expression.Member.Name.Equals("instance") ? expression.Type : expression.Member;
        }

        /// <summary>
        /// Creates a <see cref="OfResult"/> instance for the member that was identified by the provided <see cref="Expression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> that the member should be identified for.</param>
        /// <returns>A <see cref="OfResult"/> instance for the member that was identified in the expression provided by the <paramref name="expression"/> parameter.</returns>
        private static OfResult GetResult(Expression expression)
        {
            var member =
                GetTargetMemberInfo(expression);

            return new OfResult(member);
        }

        /// <summary>
        /// Retrieves the member that an expression is defined for.
        /// </summary>
        /// <param name="expression">The expression to retrieve the member from.</param>
        /// <returns>A <see cref="MemberInfo"/> instance if the member could be found; otherwise <see langword="null"/>.</returns>
        private static MemberInfo GetTargetMemberInfo(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.Convert:
                    return GetTargetMemberInfo(((UnaryExpression)expression).Operand);
                case ExpressionType.Lambda:
                    return GetTargetMemberInfo(((LambdaExpression)expression).Body);
                case ExpressionType.Call:
                    return ((MethodCallExpression)expression).Method;
                case ExpressionType.MemberAccess:
                    return GetMemberAccessReturnValue((MemberExpression)expression);
                case ExpressionType.New:
                    return ((NewExpression)expression).Constructor;
                case ExpressionType.Parameter:
                    return expression.Type;
                default:
                    return null;
            }
        }
    }
}