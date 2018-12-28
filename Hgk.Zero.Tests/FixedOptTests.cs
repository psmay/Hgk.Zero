using Hgk.Zero.Options;
using System;
using System.Linq;
using Xunit;

namespace Hgk.Zero.Tests
{
    public class FixedOptTests
    {
        [Fact]
        public void EmptyOptIsEmpty()
        {
            var opt = Opt.Empty<string>();
            Assert.False(opt.HasValue);
            Assert.Throws<InvalidOperationException>(() => opt.Value);
            Assert.False(opt.TryGetValue(out string retrievedValue));
            Assert.Equal(Enumerable.Empty<string>(), opt);
        }

        [Fact]
        public void FullOptIsFull()
        {
            var value = "hello";
            var opt = Opt.Full(value);
            Assert.True(opt.HasValue);
            Assert.Same(value, opt.Value);
            Assert.True(opt.TryGetValue(out string retrievedValue));
            Assert.Same(value, retrievedValue);
            Assert.Equal(new[] { value }, opt);
        }
    }
}