using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using System.Threading;


namespace UnitTestProject1
{
    

    [TestClass]
    public class UnitTest1
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        public static WindowsDriver<WindowsElement> winDriver;
        public static WindowsElement tb_a, tb_b, btn_Go, lb_Result;
        public static int k;

        [TestInitialize]
        public void TestInit()
        {
            var desiredCapabilities = new AppiumOptions();
            desiredCapabilities.AddAdditionalCapability("app", @"D:\MyCalc.exe");

            winDriver = new WindowsDriver<WindowsElement>(
                new Uri("http://127.0.0.1:4723"),
                desiredCapabilities
            );

            Thread.Sleep(1000);

            tb_a = winDriver.FindElementByAccessibilityId("tb_a");            
            tb_b = winDriver.FindElementByAccessibilityId("tb_b");
            
            btn_Go = winDriver.FindElementByAccessibilityId("btn_Go");
            lb_Result = winDriver.FindElementByAccessibilityId("lb_Result");
           // k = 4;
        }

        [TestMethod]
        public void PrintItOut()
        {
            tb_a.SendKeys("10");
            tb_b.SendKeys("2");
            btn_Go.Click();
            Assert.AreEqual(5,Convert.ToInt32(lb_Result.Text));
            //Assert.Fail(k.ToString());
        }
            
           
           /* [DataRow(10,2,5)]
        [DataRow(100, 2, 501)]
        [DataRow(200, 10, 20)]*/
        [DataSource(@"Provider=MSOLEDBSQL;Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\4GB20190705\Work\infsusu\pi\Appium\UnitTestProject1\UnitTestProject1\MoiTesty.mdf;Integrated Security=True;Connect Timeout=30", "dbo.Table")]
        [TestMethod]
        public void DataManagedTest()
            {

            Assert.Fail(TestContext.DataRow["a"].ToString());
                /*tb_a.SendKeys();
                tb_b.SendKeys(b.ToString());
                btn_Go.Click();            

                Assert.AreEqual(result,Convert.ToInt32(lb_Result.Text));*/
            }

            [TestCleanup]
            public void TestClean()
            {
                winDriver.Quit();
            }

            
        }
}
