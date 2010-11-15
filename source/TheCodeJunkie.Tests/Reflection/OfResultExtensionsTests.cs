namespace TheCodeJunkie.Tests.Reflection
{
    using System;
    using System.Reflection;
    using TheCodeJunkie.Reflection;
    using Xunit;

    public class OfResultExtensionsTests
    {
        [Fact]
        public void AsConstructor_should_cast_result_member_to_constructor_info()
        {
            var result =
                Member.Of(() => new FakeEntity());

            result.AsConstructor().ShouldBeAssignableFrom<ConstructorInfo>();
        }

        [Fact]
        public void AsField_should_cast_result_member_to_field_info()
        {
            var result =
                Member.Of<FakeEntity>(x => x.Field);

            result.AsField().ShouldBeAssignableFrom<FieldInfo>();
        }

        [Fact]
        public void AsMethod_should_cast_result_member_to_method_info()
        {
            var result =
                Member.Of<FakeEntity>(x => x.VoidMethodWithoutArguments());

            result.AsMethod().ShouldBeAssignableFrom<MethodInfo>();
        }

        [Fact]
        public void AsProperty_should_cast_result_member_to_property_info()
        {
            var result =
                Member.Of<FakeEntity>(x => x.Property);

            result.AsProperty().ShouldBeAssignableFrom<PropertyInfo>();
        }

        [Fact]
        public void AsType_should_cast_result_member_to_type()
        {
            var result =
                Member.Of<FakeEntity>(x => x);

            result.AsType().ShouldBeAssignableFrom<Type>();
        }
    }
}