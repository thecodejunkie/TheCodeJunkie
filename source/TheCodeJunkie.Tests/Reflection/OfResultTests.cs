namespace TheCodeJunkie.Tests.Reflection
{
    using System.Linq;
    using System.Reflection;
    using TheCodeJunkie.Reflection;
    using Xunit;

    public class OfResultTests
    {
        private readonly MemberInfo member;
        private readonly OfResult result;

        public OfResultTests()
        {
            this.member =
                typeof(FakeEntity).GetMember("Property").First();

            this.result = 
                new OfResult(this.member);
        }

        [Fact]
        public void Ctor_should_persist_member_parameter_to_member_property()
        {
            this.result.Member.ShouldBeSameAs(this.member);
        }

        [Fact]
        public void Implicit_cast_to_member_info_should_not_throw_invalidcastexception()
        {
            MemberInfo castResult = null;

            var exception =
                Catch.Exception(() => castResult = this.result);

            exception.ShouldBeNull();
        }

        [Fact]
        public void Implicit_cast_to_member_info_should_return_member_stored_in_result()
        {
            MemberInfo castResult = 
                this.result;

            castResult.ShouldBeSameAs(this.result.Member);
        }

        [Fact]
        public void Implicit_cast_to_string_should_should_not_throw_invalidcastexception()
        {
            string castResult;

            var exception =
                Catch.Exception(() => castResult = this.result);

            exception.ShouldBeNull();
        }

        [Fact]
        public void Implicit_cast_to_string_should_should_return_string_name_of_result_member()
        {
            string castResult =
                this.result;

            castResult.ShouldEqual(this.result.Member.ToString());
        }
    }
}