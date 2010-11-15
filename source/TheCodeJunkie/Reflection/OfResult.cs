namespace TheCodeJunkie.Reflection
{
    using System.Reflection;

    /// <summary>
    /// Provides the ability to implicitly cast a <see cref="MemberInfo"/> instance into various types.
    /// </summary>
    public class OfResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OfResult"/> class.
        /// </summary>
        /// <param name="member">The <see cref="MemberInfo"/> instance to wrap.</param>
        public OfResult(MemberInfo member)
        {
            this.Member = member;
        }

        /// <summary>
        /// Gets the <see cref="MemberInfo"/> instance that the result wraps.
        /// </summary>
        /// <value>The <see cref="MemberInfo"/> instance that the result wraps.</value>
        public MemberInfo Member { get; private set; }

        /// <summary>
        /// Performs an implicit conversion from <see cref="OfResult"/> to <see cref="MemberInfo"/>.
        /// </summary>
        /// <param name="result">The <see cref="OfResult"/> instance to cast.</param>
        /// <returns>The <see cref="MemberInfo"/> that the <see cref="OfResult"/> instance wraps.</returns>
        public static implicit operator MemberInfo(OfResult result)
        {
            return result.Member;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="OfResult"/> to <see cref="System.String"/>.
        /// </summary>
        /// <param name="result">The <see cref="OfResult"/> instance to cast.</param>
        /// <returns>The string name of the <see cref="MemberInfo"/> that the <see cref="OfResult"/> instance wraps.</returns>
        public static implicit operator string(OfResult result)
        {
            return result.Member.ToString();
        }
    }
}