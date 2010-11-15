namespace TheCodeJunkie.Tests
{
    using System;

    public class FakeEntity
    {
        public FakeEntity()
        {
        }

        public FakeEntity(int a)
        {
        }

        public int Field;

        public int Property { get; set; }

        public int NonVoidMethodWithoutArguments()
        {
            throw new NotImplementedException();
        }

        public int NonVoidMethodWithArguments(int a)
        {
            throw new NotImplementedException();
        }

        public void VoidMethodWithoutArguments()
        {
        }

        public void VoidMethodWithArguments(int a)
        {
        }
    }
}