using System;
using System.Text;
using NUnit.Framework;
using MyLibrary;

namespace Tests
{
    [TestFixture]
    class QueueTests
    {
        [TestCase]
        public void Test1()
        {
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < 4; i++)
            {
                queue.Add(i);
            }
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(queue.Get(),i);
            }
        }

        [TestCase]
        public void Test2()
        {
            TestDelegate testDelegate = () => {
                Queue<int> queue = new Queue<int>();
                for (int i = 0; i < 20; i++)
                {
                    queue.Add(i);
                    queue.Get();
                }
            };
            //Queue<int> queue = new Queue<int>();
            //for (int i = 0; i < 20; i++)
            //{
            //    queue.Add(i);
            //    queue.Get();
            //}

            Assert.DoesNotThrow(testDelegate);
        }
    }
}
