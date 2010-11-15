namespace TheCodeJunkie.Tests.Reflection
{
    using System;
    using TheCodeJunkie.Reflection;
    using Xunit;

    public class MemberTests
    {
        private readonly FakeEntity instance;

        public MemberTests()
        {
            this.instance = new FakeEntity();
        }

        [Fact]
        public void Of_should_return_result_containing_member_info_for_void_method_without_arguments_when_called_with_type()
        {
            var expectedMemberInfo =
                typeof(FakeEntity).GetMethod("VoidMethodWithoutArguments", new Type[] {});

            var result =
                Member.Of<FakeEntity>(x => x.VoidMethodWithoutArguments());

            result.Member.ShouldBeSameAs(expectedMemberInfo);
        }

        [Fact]
        public void Of_should_return_result_containing_member_info_for_void_method_with_arguments_when_called_with_type()
        {
            var expectedMemberInfo =
                typeof(FakeEntity).GetMethod("VoidMethodWithArguments", new[] { typeof(int) });

            var result =
                Member.Of<FakeEntity>(x => x.VoidMethodWithArguments(1));

            result.Member.ShouldBeSameAs(expectedMemberInfo);
        }

        [Fact]
        public void Of_should_return_result_containing_member_info_for_non_void_method_without_arguments_when_called_with_type()
        {
            var expectedMemberInfo =
                typeof(FakeEntity).GetMethod("NonVoidMethodWithoutArguments", new Type[] { });

            var result =
                Member.Of<FakeEntity>(x => x.NonVoidMethodWithoutArguments());

            result.Member.ShouldBeSameAs(expectedMemberInfo);
        }

        [Fact]
        public void Of_should_return_result_containing_member_info_for_non_void_method_with_arguments_when_called_with_type()
        {
            var expectedMemberInfo =
                typeof(FakeEntity).GetMethod("NonVoidMethodWithArguments", new[] { typeof(int) });

            var result =
                Member.Of<FakeEntity>(x => x.NonVoidMethodWithArguments(1));

            result.Member.ShouldBeSameAs(expectedMemberInfo);
        }

        [Fact]
        public void Of_should_return_result_containing_member_info_for_property_when_called_with_type()
        {
            var expectedMemberInfo =
                typeof(FakeEntity).GetProperty("Property");

            var result =
                Member.Of<FakeEntity>(x => x.Property);

            result.Member.ShouldBeSameAs(expectedMemberInfo);
        }

        [Fact]
        public void Of_should_return_result_containing_member_info_for_field_when_called_with_type()
        {
            var expectedMemberInfo =
                typeof(FakeEntity).GetField("Field");

            var result =
                Member.Of<FakeEntity>(x => x.Field);

            result.Member.ShouldBeSameAs(expectedMemberInfo);
        }

        [Fact]
        public void Of_should_return_result_containing_member_info_for_type_when_called_with_type()
        {
            var expectedMemberInfo =
                typeof(FakeEntity);

            var result =
                Member.Of<FakeEntity>(x => x);

            result.Member.ShouldBeSameAs(expectedMemberInfo);
        }

        [Fact]
        public void Of_should_return_result_containing_member_info_for_void_method_without_arguments_when_called_with_instance()
        {
            var expectedMemberInfo =
                typeof(FakeEntity).GetMethod("VoidMethodWithoutArguments", new Type[] { });

            var result =
                Member.Of(() => this.instance.VoidMethodWithoutArguments());

            result.Member.ShouldBeSameAs(expectedMemberInfo);
        }

        [Fact]
        public void Of_should_return_result_containing_member_info_for_void_method_with_arguments_when_called_with_instance()
        {
            var expectedMemberInfo =
                typeof(FakeEntity).GetMethod("VoidMethodWithArguments", new[] { typeof(int) });

            var result =
                Member.Of(() => this.instance.VoidMethodWithArguments(1));

            result.Member.ShouldBeSameAs(expectedMemberInfo);
        }

        [Fact]
        public void Of_should_return_result_containing_member_info_for_non_void_method_without_arguments_when_called_with_instance()
        {
            var expectedMemberInfo =
                typeof(FakeEntity).GetMethod("NonVoidMethodWithoutArguments", new Type[] { });

            var result =
                Member.Of(() => this.instance.NonVoidMethodWithoutArguments());

            result.Member.ShouldBeSameAs(expectedMemberInfo);
        }

        [Fact]
        public void Of_should_return_result_containing_member_info_for_non_void_method_with_arguments_when_called_with_instance()
        {
            var expectedMemberInfo =
                typeof(FakeEntity).GetMethod("NonVoidMethodWithArguments", new[] { typeof(int) });

            var result =
                Member.Of(() => this.instance.NonVoidMethodWithArguments(1));

            result.Member.ShouldBeSameAs(expectedMemberInfo);
        }

        [Fact]
        public void Of_should_return_result_containing_member_info_for_property_when_called_with_instance()
        {
            var expectedMemberInfo =
                typeof(FakeEntity).GetProperty("Property");

            var result =
                Member.Of(() => this.instance.Property);

            result.Member.ShouldBeSameAs(expectedMemberInfo);
        }

        [Fact]
        public void Of_should_return_result_containing_member_info_for_field_when_called_with_instance()
        {
            var expectedMemberInfo =
                typeof(FakeEntity).GetField("Field");

            var result =
                Member.Of(() => this.instance.Field);

            result.Member.ShouldBeSameAs(expectedMemberInfo);
        }

        [Fact]
        public void Of_should_return_result_containing_member_info_for_type_when_called_with_instance()
        {
            var expectedMemberInfo =
                typeof(FakeEntity);

            var result =
                Member.Of(() => this.instance);

            result.Member.ShouldBeSameAs(expectedMemberInfo);
        }

        [Fact]
        public void Of_should_return_result_containing_member_info_for_constructor_without_arguments_when_called_with_instance()
        {
            var expectedMemberInfo =
                typeof(FakeEntity).GetConstructor(new Type[] { });

            var result =
                Member.Of(() => new FakeEntity());

            result.Member.ShouldBeSameAs(expectedMemberInfo);
        }

        [Fact]
        public void Of_should_return_result_containing_member_info_for_constructor_with_arguments_when_called_with_instance()
        {
            var expectedMemberInfo =
                typeof(FakeEntity).GetConstructor(new[] { typeof(int) });

            var result =
                Member.Of(() => new FakeEntity(1));

            result.Member.ShouldBeSameAs(expectedMemberInfo);
        }
    }
}