using Hgk.Zero.Options;
using System;
using System.Linq;
using Xunit;

namespace Hgk.Zero.Tests
{
    public class FixedOptTests
    {
        [Fact]
        public void EmptyOptOfIntIsEmpty()
        {
            var opt = Opt.Empty<int>();
            AssertEmpty(opt);
        }

        [Fact]
        public void EmptyOptOfObjectIsEmpty()
        {
            var opt = Opt.Empty<object>();
            AssertEmpty(opt);
        }

        [Fact]
        public void FullOptOfIntIsFull()
        {
            var value = 12345;
            var opt = Opt.Full(value);
            AssertContainsValue(opt, 12345);
        }

        [Fact]
        public void FullOptOfObjectIsFull()
        {
            var value = new object();
            var opt = Opt.Full(value);
            AssertContainsObject(opt, value);
        }

        [Fact]
        public void CreateOptOfNullIntIsEmpty()
        {
            int? value = null;
            var opt = Opt.Create(value);
            AssertEmpty(opt);
        }

        [Fact]
        public void CreateOptOfNonNullNullableIntIsFull()
        {
            int? value = 12345;
            var opt = Opt.Create(value);
            AssertContainsValue(opt, value.Value);
        }

        [Fact]
        public void CreateOptOfNullObjectIsEmpty()
        {
            object value = null;
            var opt = Opt.Create(value);
            AssertEmpty(opt);
        }

        [Fact]
        public void CreateOptOfNonNullObjectIsFull()
        {
            object value = new object();
            var opt = Opt.Create(value);
            AssertContainsObject(opt, value);
        }

        private static void AssertContainsObject<T>(Opt<T> opt, T value) where T : class
        {
            Assert.True(opt.HasValue);
            Assert.Same(value, opt.Value);
            Assert.True(opt.TryGetValue(out T retrievedValue));
            Assert.Same(value, retrievedValue);
            Assert.Equal(new T[] { value }, opt);
        }

        private static void AssertContainsValue<T>(Opt<T> opt, T value) where T : struct
        {
            Assert.True(opt.HasValue);
            Assert.Equal(value, opt.Value);
            Assert.True(opt.TryGetValue(out T retrievedValue));
            Assert.Equal(value, retrievedValue);
            Assert.Equal(new T[] { value }, opt);
        }

        private static void AssertEmpty<T>(Opt<T> opt)
        {
            Assert.False(opt.HasValue);
            Assert.Throws<InvalidOperationException>(() => opt.Value);
            Assert.False(opt.TryGetValue(out T retrievedValue));
            Assert.Equal(Enumerable.Empty<T>(), opt);
        }
    }
}