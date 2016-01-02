using System;
using Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Model.Interfaces;
using System.Collections.Generic;

namespace Rules.Test
{
    public class FakeProduct : IProduct, ICloneable
    {
        public IDictionary<string, dynamic> Properties { get; set; }
        public FakeProduct()
        {
            Properties = new Dictionary<string, dynamic>();
        }

        public object Clone()
        {
            return new FakeProduct();
        }
    }

    [TestClass]
    public class RulesTest
    {
        PricingRules pricingRules;
        Mock<ICatalogService> mockCatalogService;

        public FakeProduct createHdm()
        {
            FakeProduct mockHdm = new FakeProduct();

            mockHdm.Properties["SKU"] = "hdm";
            mockHdm.Properties["Name"] = "HDMI Adapter";
            mockHdm.Properties["Price"] = 30.00;

            return mockHdm;
        }

        public FakeProduct createMbp()
        {
            FakeProduct mockMbp = new FakeProduct();
            mockMbp.Properties["SKU"] = "mbp";
            mockMbp.Properties["Name"] = "MacBook Pro";
            mockMbp.Properties["Price"] = 1399.99;

            return mockMbp;
        }

        public FakeProduct createNexus()
        {
            FakeProduct mockNexus = new FakeProduct();
            mockNexus.Properties["SKU"] = "nx9";
            mockNexus.Properties["Name"] = "Nexus 9";
            mockNexus.Properties["Price"] = 549.99;

            return mockNexus;
        }

        public FakeProduct createAtv()
        {
            FakeProduct mockAtv = new FakeProduct();
            mockAtv.Properties["SKU"] = "atv";
            mockAtv.Properties["Name"] = "Apple TV";
            mockAtv.Properties["Price"] = 109.50;

            return mockAtv;
        }
        [TestInitialize]
        public void Setup()
        {
            pricingRules = new PricingRules();
            mockCatalogService = new Mock<ICatalogService>();

            mockCatalogService.Setup(m => m.getProduct("hdm")).Returns(createHdm());
        }

        [TestMethod]
        public void NexusDiscountTest()
        {
            // Test nexus less than five
            List<IProduct> productBasket = new List<IProduct>();
            for (int i = 0; i < 4; i++)
            {
                productBasket.Add(createNexus());
            }

            productBasket = pricingRules.applyPricingRules(productBasket, mockCatalogService.Object);
            foreach (IProduct product in productBasket)
            {
                Assert.AreEqual(549.99, product.Properties["Price"]);
            }

            // Test nexus more than five
            productBasket.Clear();
            for (int i = 0; i < 5; i++)
            {
                productBasket.Add(createNexus());
            }
            productBasket = pricingRules.applyPricingRules(productBasket, mockCatalogService.Object);
            foreach (IProduct product in productBasket)
            {
                Assert.AreEqual(499.99, product.Properties["Price"]);
            }
        }

        [TestMethod]
        public void MbpBundleTest()
        {
            // Test Bundle Deals with every Mac Book Pro Purchased without HMDI cables in basket
            List<IProduct> productBasket = new List<IProduct>();
            for (int i = 0; i < 4; i++)
            {
                productBasket.Add(createMbp());
            }

            productBasket = pricingRules.applyPricingRules(productBasket, mockCatalogService.Object);
            IList<IProduct> hdmiCables = productBasket.FindAll(x => x.Properties["SKU"] == "hdm");
            Assert.AreEqual(4, hdmiCables.Count);
            foreach (IProduct hdmiCable in hdmiCables)
            {
                Assert.AreEqual(0, hdmiCable.Properties["Price"]);
            }

            // Test Bundle Deals with every Mac Book Pro Purchased with HMDI cables less than than MBP
            productBasket.Clear();
            for (int i = 0; i < 4; i++)
            {
                productBasket.Add(createMbp());
            }

            for (int i = 0; i < 2; i++)
            {
                productBasket.Add(createHdm());
            }

            productBasket = pricingRules.applyPricingRules(productBasket, mockCatalogService.Object);
            hdmiCables = productBasket.FindAll(x => x.Properties["SKU"] == "hdm");
            Assert.AreEqual(4, hdmiCables.Count);
            foreach (IProduct hdmiCable in hdmiCables)
            {
                Assert.AreEqual(0, hdmiCable.Properties["Price"]);
            }

            // Test Bundle Deals with every Mac Book Pro Purchased with HMDI cables more than than MBP
            productBasket.Clear();
            for (int i = 0; i < 4; i++)
            {
                productBasket.Add(createMbp());
            }

            for (int i = 0; i < 5; i++)
            {
                productBasket.Add(createHdm());
            }

            productBasket = pricingRules.applyPricingRules(productBasket, mockCatalogService.Object);
            hdmiCables = productBasket.FindAll(x => x.Properties["SKU"] == "hdm");
            Assert.AreEqual(5, hdmiCables.Count);
            int freeHDMIcount = 0;
            foreach (IProduct hdmiCable in hdmiCables)
            {
                freeHDMIcount += (hdmiCable.Properties["Price"] == 0) ? 1 : 0;
            }
            Assert.AreEqual(4, freeHDMIcount);
        }

        [TestMethod]
        public void AtvDealTest()
        {
            //Test ATVs less than three
            List<IProduct> productBasket = new List<IProduct>();
            List<IProduct> discountedATV = new List<IProduct>();
            for (int i = 0; i < 2; i++)
            {
                productBasket.Add(createAtv());
            }
            productBasket = pricingRules.applyPricingRules(productBasket, mockCatalogService.Object);
            discountedATV = productBasket.FindAll(x => x.Properties["SKU"] == "atv" && x.Properties["Price"] == 0);
            Assert.AreEqual(0, discountedATV.Count);

            //Test ATVs more than three but less than six
            productBasket.Clear();
            discountedATV.Clear();
            for (int i = 0; i < 4; i++)
            {
                productBasket.Add(createAtv());
            }
            productBasket = pricingRules.applyPricingRules(productBasket, mockCatalogService.Object);
            discountedATV = productBasket.FindAll(x => x.Properties["SKU"] == "atv" && x.Properties["Price"] == 0);
            Assert.AreEqual(1, discountedATV.Count);

            //Test ATVs more than six
            productBasket.Clear();
            discountedATV.Clear();
            for (int i = 0; i < 7; i++)
            {
                productBasket.Add(createAtv());
            }
            productBasket = pricingRules.applyPricingRules(productBasket, mockCatalogService.Object);
            discountedATV = productBasket.FindAll(x => x.Properties["SKU"] == "atv" && x.Properties["Price"] == 0);
            Assert.AreEqual(2, discountedATV.Count);
        }
    }
}
