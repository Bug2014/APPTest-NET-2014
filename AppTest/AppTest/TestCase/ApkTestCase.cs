using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using System.Threading;
using System.Collections;

namespace AppTest.TestCase
{
    /// <summary>
    /// 不使用框架 
    /// </summary>
    public class ApkTestCase
    {

        /// <summary>
        /// 获取APK地址 
        /// </summary>
        /// <returns></returns>
        public string GetAppPath()
        {
            string appPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            return string.Format("{0}{1}{2}",appPath,"Apks\\","ctrip_9013.apk");
        
        }

        public void RunAppCase()
        {
           DesiredCapabilities cap=new DesiredCapabilities();
           cap.SetCapability("deviceName", "HC44DWM01308");  
           cap.SetCapability("platformName", "Android");  
           cap.SetCapability("udid","HC44DWM01308");
           cap.SetCapability("app",GetAppPath());
           var driver=new AppiumDriver(new Uri("http://localhost:4723/wd/hub"),cap);
          
           Thread.Sleep(15000);
            try
            {
                var isEXIT = driver.FindElement(By.Name("以后再说"));
                if (isEXIT != null)
                {
                    driver.FindElement(By.Name("以后再说")).Click();

                }
           
            }
            catch (Exception ex)
            {}

            #region  通过js执行滑动屏幕的功能
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            Hashtable swipObj = new Hashtable();
            swipObj.Add("startX", 300.0);
            swipObj.Add("startY", 300.0);
            swipObj.Add("endX", 20.0);
            swipObj.Add("endY", 20.0);
            swipObj.Add("duration", 0.5);
            js.ExecuteScript("mobile: swipe", swipObj);
            Thread.Sleep(2000);
            js.ExecuteScript("mobile: swipe", swipObj);
            Thread.Sleep(2000);
            js.ExecuteScript("mobile: swipe", swipObj);
            Thread.Sleep(2000);
            js.ExecuteScript("mobile: swipe", swipObj);
            #endregion
            Thread.Sleep(3000);

              //登陆--我的携程 
            driver.FindElement(By.Name("我的携程")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Name("点击登录")).Click();
            Thread.Sleep(3000);
   
            //输入用户名
            driver.FindElement(By.Name("携程用户名/绑定手机/邮箱/卡号")).SendKeys(" test111111");
            #region  输入中文用户名测试
            //driver.FindElement(By.Name("携程用户名/绑定手机/邮箱/卡号")).SendKeys("赵江");
            //IWebElement ete = driver.FindElement(By.Name("携程用户名/绑定手机/邮箱/卡号"));
            //var ejs = (IJavaScriptExecutor)driver;
            //ejs.ExecuteAsyncScript("arguments[0].value=arguments[1];", ete, "赵江");
            #endregion
          
            Thread.Sleep(3000);

            var editTexts = driver.FindElements(By.ClassName("android.widget.EditText"));
            Thread.Sleep(3000);
            editTexts[editTexts.Count - 1].SendKeys("123456789");
            Thread.Sleep(3000);

            driver.FindElements(By.ClassName("android.widget.Button"))[0].Click();
            Thread.Sleep(9000);


            //我的携程
            driver.FindElement(By.Name("首页")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.Name("门票")).Click();
            Thread.Sleep(12000);

            #region 搜索框

            //driver.FindElementByAccessibilityId("景点名称/城市/游玩主题").Click(); //该方法成功了 
            //Thread.Sleep(10000);
            //driver.FindElement(By.ClassName("android.widget.EditText")).SendKeys("上海");
            //Thread.Sleep(5000);
            //driver.FindElementByAccessibilityId("搜索").Click();
            //Thread.Sleep(5000);

            //其他定位方式 未成功 
            //driver.FindElementByAndroidUIAutomator("new UiSelector().className(\"android.widget.TextView\").text(\"机票\")").Click();
            //driver.FindElementByAndroidUIAutomator("new UiSelector().Desctiption(\"景点名称/城市/游玩主题\")").Click();
            //driver.FindElements(By.ClassName("android.widget.RelativeLayout"))[1].FindElements(By.ClassName("android.view.View"))[8].Click();          
            //driver.FindElements(By.ClassName("android.widget.RelativeLayout"))[1].Click();

            //Thread.Sleep(5000);
            //driver.FindElement(By.ClassName("android.widget.EditText")).SendKeys("上海");
            //Thread.Sleep(5000);
            #endregion
           

            //其余后面的步骤 
            driver.FindElementByAccessibilityId("上海").Click();
            Thread.Sleep(5000);

            //上海科技馆 Heading
            driver.FindElementByAccessibilityId("上海科技馆 Heading").Click();
            Thread.Sleep(5000);

            driver.FindElementByAccessibilityId("预订").Click();
            Thread.Sleep(5000);

            driver.FindElementByAccessibilityId("请选择游玩日期").Click();
            Thread.Sleep(5000);

            driver.FindElementByAccessibilityId("17").Click();
            Thread.Sleep(9000);

            driver.FindElementByAccessibilityId("接收确认短信").Click();
            Thread.Sleep(9000);

            driver.FindElementByAccessibilityId("测试一").Click();
            Thread.Sleep(5000);

            driver.FindElementByAccessibilityId("下一步").Click();
            Thread.Sleep(9000);

            driver.FindElementByAccessibilityId("常用卡支付").Click();
            Thread.Sleep(5000);

            driver.FindElementByAccessibilityId("宁波银行-信用卡").Click();
            Thread.Sleep(5000);

            driver.FindElements(By.ClassName("android.widget.EditText"))[0].SendKeys("0003");
            Thread.Sleep(5000);

            driver.FindElements(By.ClassName("android.widget.Button"))[0].Click();
            Thread.Sleep(5000);

            //返回 
            driver.FindElements(By.ClassName("android.view.View"))[0].Click();
            Thread.Sleep(5000);

            //返回我的携程退票操作 
            driver.FindElement(By.Name("我的携程")).Click();
            Thread.Sleep(5000);

            driver.FindElement(By.Name("全部订单")).Click();
            Thread.Sleep(5000);

            driver.FindElement(By.Name("景点门票订单")).Click();
            Thread.Sleep(15000);

            driver.FindElementByAccessibilityId("申请取消").Click();
            Thread.Sleep(9000);

            driver.FindElementByAccessibilityId("申请取消").Click();
            Thread.Sleep(9000);

            driver.FindElementByAccessibilityId("确认").Click();
            Thread.Sleep(9000);     
        }
       
    }
}
