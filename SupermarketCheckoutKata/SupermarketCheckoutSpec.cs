using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SupermarketCheckoutKata
{
    [TestClass]
    public class SupermarketCheckoutSpec
    {
        [TestMethod]
        public void ScanA_Returns50()
        {
            Assert.AreEqual(50, Checkout.Scan("A"));
        }

        [TestMethod]
        public void ScanB_Retuns30()
        {
            Assert.AreEqual(30, Checkout.Scan("B"));
        }

        [TestMethod]
        public void ScanningThreeAs_Returns130()
        {
            var total = Checkout.GetTotal();

            total += Checkout.Scan("A");
            total += Checkout.Scan("A");
            total += Checkout.Scan("A");
            total -= Checkout.GetDiscount("A");

            Assert.AreEqual(130, total);
        }

        [TestMethod]
        public void ScanningTwoBs_Returns45()
        {
            var total = Checkout.GetTotal();

            total += Checkout.Scan("B");
            total += Checkout.Scan("B");
            total -= Checkout.GetDiscount("B");

            Assert.AreEqual(45, total);
        }

        public class Checkout
        {
            private static int _total = 0;

            public static int GetDiscount(string s)
            {
                if (s == "A")
                {
                    _total -= 20;
                    return 20;
                }

                _total -= 15;
                return 15;
            }

            public static int Scan(string s)
            {
                if (s == "A")
                {
                    _total += 50;
                    return 50;
                }

                _total += 30;
                return 30;
            }

            public static int GetTotal()
            {
                var total = 0;
                return total;
            }
        }
    }
}
