namespace TheCodeJunkie.Reflection
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Defines extension methods for the <see cref="OfResult"/> class.
    /// </summary>
    public static class OfResultExtensions
    {
        /// <summary>
        /// Casts the <see cref="OfResult.Member"/> property to a <see cref="ConstructorInfo"/> object.
        /// </summary>
        /// <param name="result">The <see cref="OfResult"/> instance to cast the member of.</param>
        /// <returns>A <see cref="ConstructorInfo"/> object.</returns>
        public static ConstructorInfo AsConstructor(this OfResult result)
        {
            return (ConstructorInfo)result.Member;
        }

        /// <summary>
        /// Casts the <see cref="OfResult.Member"/> property to a <see cref="FieldInfo"/> object.
        /// </summary>
        /// <param name="result">The <see cref="OfResult"/> instance to cast the member of.</param>
        /// <returns>A <see cref="FieldInfo"/> object.</returns>
        public static FieldInfo AsField(this OfResult result)
        {
            return (FieldInfo)result.Member;
        }

        /// <summary>
        /// Casts the <see cref="OfResult.Member"/> property to a <see cref="MethodInfo"/> object.
        /// </summary>
        /// <param name="result">The <see cref="OfResult"/> instance to cast the member of.</param>
        /// <returns>A <see cref="MethodInfo"/> object.</returns>
        public static MethodInfo AsMethod(this OfResult result)
        {
            return (MethodInfo)result.Member;
        }

        /// <summary>
        /// Casts the <see cref="OfResult.Member"/> property to a <see cref="PropertyInfo"/> object.
        /// </summary>
        /// <param name="result">The <see cref="OfResult"/> instance to cast the member of.</param>
        /// <returns>A <see cref="PropertyInfo"/> object.</returns>
        public static PropertyInfo AsProperty(this OfResult result)
        {
            return (PropertyInfo)result.Member;
        }

        /// <summary>
        /// Casts the <see cref="OfResult.Member"/> property to a <see cref="Type"/> object.
        /// </summary>
        /// <param name="result">The <see cref="OfResult"/> instance to cast the member of.</param>
        /// <returns>A <see cref="Type"/> object.</returns>
        public static Type AsType(this OfResult result)
        {
            return (Type)result.Member;
        }
    }
}