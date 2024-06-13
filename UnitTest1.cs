using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection.Emit;
using Selenium.CaptchaIdentifier;
using System.Xml.Linq;
using System.Reflection.PortableExecutable;
using VkNet.Model;
using Selenium.FramesSearcher.Extensions;

namespace ProjetFormulaire
{
    public class Tests
    {
        public IWebDriver driver;
        IJavaScriptExecutor js;
        [SetUp]
        public void Setup()// partie precondition de test 
        {

            driver = new ChromeDriver(@"C:\\Users\\Bouss\\SELENIUM\\chromedriver.exe");

        }


        [Test]
        public void CreationCompteEnTantQueChef()// test 1 Creation Compte En Tant Que Chef
        {

            js = (IJavaScriptExecutor)driver;

            driver.Navigate().GoToUrl("https://www.nocibe.fr/fete-des-peres/C-86790/NW-4776-type-doffres~eligibles-aux-codes-promo?msclkid=eb9efd9e6ddd17bb467b99e133b8496d&utm_source=bing&utm_medium=cpc&utm_campaign=%5BB%5D%20%5BKW%5D%20%5BBrand%5D%20FR_n%3ANocibe_id%3A0000_k%3Abrandid_mt%3Aexact_&utm_term=nocibe&utm_content=%5BKW%5D%20%5BBrand%5D%20FR_n%3ANocibe_id%3A0000%2B1_k%3Atypeid_mt%3Aexact_#products");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//*[@id=\"didomi-popup\"]/div/div/div/span")).Click();
            driver.FindElement(By.CssSelector("#headerTop > div:nth-child(1) > div > header > div.header__wrapper > div.header__icons > div.header__icon.header__icon-account > a > svg")).Click();
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//*[@id=\"wrapper\"]/div[2]/div/div[1]/div[2]/div/button")).Click();
            driver.FindElement(By.Id("email2")).SendKeys("boussoul.sadek@gmail.com");
            Thread.Sleep(1000);

            driver.FindElement(By.Id("pass")).SendKeys("Sadek@2024");
            driver.FindElement(By.XPath("//*[@id=\"create-account-form\"]/div[4]/div[1]/div[2]/label[2]/span[1]/span")).Click();
            driver.FindElement(By.Id("prenom")).SendKeys("SadeK");
            driver.FindElement(By.Id("nom")).SendKeys("BOUSSOUL");
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//*[@id=\"create-account-form\"]/div[4]/div[5]/div[2]/label[2]/span[1]/span")).Click();
            SelectElement select = new SelectElement(driver.FindElement(By.Id("jj_naissance")));
            select.SelectByValue("8");

            SelectElement select1 = new SelectElement(driver.FindElement(By.Id("mm_naissance")));
            select1.SelectByValue("12");

            SelectElement select2 = new SelectElement(driver.FindElement(By.Id("aaaa_naissance")));
            select2.SelectByValue("1995");
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//*[@id=\"create-account-form\"]/div[4]/div[5]/div[2]/label[2]/span[1]/span")).Click();

            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//*[@id=\"create-account-form\"]/div[4]/div[5]/div[1]")));
            Thread.Sleep(2000);

            SelectElement select3 = new SelectElement(driver.FindElement(By.Id("pays")));
            select3.SelectByValue("1");


            driver.FindElement(By.XPath("//*[@id=\"adresse\"]")).SendKeys("64 Avenue Jean Jaurès");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"cp\"]")).SendKeys("94110");



            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath(" //*[@id=\"create-account-form\"]/div[6]/h2")));
            //SelectElement select4 = new SelectElement(driver.FindElement(By.Id("villeSelect")));
            //select4.SelectByValue("1");
            driver.FindElement(By.Id("NumTelPortField")).SendKeys("0769354612");

            driver.FindElement(By.XPath("//*[@id=\"create-account-form\"]/div[7]/div[1]/label[3]/span[1]/span")).Click();
            ////////////////////////////////
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.FindElement(By.XPath("//*[@id=\"create-account-form\"]/div[7]/div[1]/label[3]/span[1]")).Click();

            //js.ExecuteScript("arguments[0].scrollIntoView({ behavior: 'smooth', block: 'end', inline: 'nearest' });", driver.FindElement(By.Id("email2-error")));
            driver.FindElement(By.XPath("//*[@id=\"create-account-form\"]/div[7]/div[1]/label[3]/span[1]/span")).Click();

            Assert.AreEqual("Impossible de créer un compte avec cette adresse e-mail.", driver.FindElement(By.Id("email2-error")).Text);
            Console.WriteLine("Effectivement, on ne peut pas créer un compte avec boite Email deja utilisée");

        }



        [Test]
        public void connexion()// test 2 connexion 
        {

            js = (IJavaScriptExecutor)driver;

            driver.Navigate().GoToUrl("https://www.nocibe.fr/fete-des-peres/C-86790/NW-4776-type-doffres~eligibles-aux-codes-promo?msclkid=eb9efd9e6ddd17bb467b99e133b8496d&utm_source=bing&utm_medium=cpc&utm_campaign=%5BB%5D%20%5BKW%5D%20%5BBrand%5D%20FR_n%3ANocibe_id%3A0000_k%3Abrandid_mt%3Aexact_&utm_term=nocibe&utm_content=%5BKW%5D%20%5BBrand%5D%20FR_n%3ANocibe_id%3A0000%2B1_k%3Atypeid_mt%3Aexact_#products");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//*[@id=\"didomi-popup\"]/div/div/div/span")).Click();
            driver.FindElement(By.CssSelector("#headerTop > div:nth-child(1) > div > header > div.header__wrapper > div.header__icons > div.header__icon.header__icon-account > a > svg")).Click();
            
            driver.FindElement(By.Id("email")).SendKeys("boussoul.sadek@gmail.com");
            driver.FindElement(By.Id("mdp1")).SendKeys("Sadek@2024");
            driver.FindElement(By.XPath("//*[@id=\"new-user\"]/div/div/div/button/span")).Click();
        }

        [Test]
        public void ajoutaupanier()// test 3 ajouter un produit au panier 
        {

            js = (IJavaScriptExecutor)driver;

            driver.Navigate().GoToUrl("https://www.nocibe.fr/fete-des-peres/C-86790/NW-4776-type-doffres~eligibles-aux-codes-promo?msclkid=eb9efd9e6ddd17bb467b99e133b8496d&utm_source=bing&utm_medium=cpc&utm_campaign=%5BB%5D%20%5BKW%5D%20%5BBrand%5D%20FR_n%3ANocibe_id%3A0000_k%3Abrandid_mt%3Aexact_&utm_term=nocibe&utm_content=%5BKW%5D%20%5BBrand%5D%20FR_n%3ANocibe_id%3A0000%2B1_k%3Atypeid_mt%3Aexact_#products");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//*[@id=\"didomi-popup\"]/div/div/div/span")).Click();
            driver.FindElement(By.CssSelector("#headerTop > div:nth-child(1) > div > header > div.header__wrapper > div.header__icons > div.header__icon.header__icon-account > a > svg")).Click();
            
            driver.FindElement(By.Id("email")).SendKeys("boussoul.sadek@gmail.com");
            driver.FindElement(By.Id("mdp1")).SendKeys("Sadek@2024");
            driver.FindElement(By.XPath("//*[@id=\"new-user\"]/div/div/div/button/span")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.CssSelector("#account>section>div>a")).Click();
            driver.FindElement(By.XPath("//*[@id=\"navMenu\"]/ul/li[1]/a")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//*[@id=\"navMenu\"]/ul/li[1]/div/div/div/ul/li[3]/a")).Click();

            driver.FindElement(By.XPath("//*[@id=\"prodlist\"]/div[3]/div[1]/div[2]/div[2]/div[1]/i")).Click();
            driver.FindElement(By.Id("brandsearch")).SendKeys("Azzaro");
            driver.FindElement(By.XPath("//*[@id=\"prodlist\"]/div[3]/div[1]/div[2]/div[2]/div[2]/ul/li[15]/label/div[2]/span")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//*[@id=\"prodlist\"]/div[3]/div[1]/div[2]/div[2]/div[2]/a")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//*[@id=\"prodlist\"]/div[4]/div[2]/div[1]/a/h3/strong")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//*[@id=\"btnAddBasket\"]/span[2]")).Click();

            js.ExecuteScript("arguments[0].scrollIntoView({ behavior: 'smooth', block: 'end', inline: 'nearest' });", driver.FindElement(By.XPath("//*[@id=\"headerTop\"]/div[1]/div/header/div[2]/div[2]/a/img")));

            Thread.Sleep(2000);
            driver.FindElement(By.Id("btnAddBasket")).Click(); //Cheveux 
            
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"btnAddBasket\"]/span[2]")).Click(); //cheveux sec et abimé
            

            //Thread.Sleep(1000);
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//*[@id=\"account-nav\"]/a[10]")));// scrole pour la deconnection 
            
            //Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//*[@id=\"account-nav\"]/button")).Click(); //deconnexion 


        }
        [Test]
        public void verificationpagnierEtPaiement()// test 4 verifier la validation de l'achat et le payement 
        {

            js = (IJavaScriptExecutor)driver;

            driver.Navigate().GoToUrl("https://www.nocibe.fr/fete-des-peres/C-86790/NW-4776-type-doffres~eligibles-aux-codes-promo?msclkid=eb9efd9e6ddd17bb467b99e133b8496d&utm_source=bing&utm_medium=cpc&utm_campaign=%5BB%5D%20%5BKW%5D%20%5BBrand%5D%20FR_n%3ANocibe_id%3A0000_k%3Abrandid_mt%3Aexact_&utm_term=nocibe&utm_content=%5BKW%5D%20%5BBrand%5D%20FR_n%3ANocibe_id%3A0000%2B1_k%3Atypeid_mt%3Aexact_#products");
            //driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"didomi-popup\"]/div/div/div/span")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#headerTop > div:nth-child(1) > div > header > div.header__wrapper > div.header__icons > div.header__icon.header__icon-account > a > svg")).Click();
            driver.FindElement(By.Id("email")).SendKeys("boussoul.sadek@gmail.com");
            driver.FindElement(By.Id("mdp1")).SendKeys("Sadek@2024");
         
            driver.FindElement(By.XPath("//*[@id=\"new-user\"]/div/div/div/button/span")).Click();
            
            Thread.Sleep(2000);
            Assert.AreEqual("Heureux de vous revoir :)", driver.FindElement(By.XPath("//*[@id=\"need_to_merge_basket_modal\"]/div/div[2]/div[1]")).Text);
            driver.FindElement(By.XPath("//*[@id=\"need_to_merge_basket_modal\"]/div/div[2]/div[2]/div/button[2]")).Click(); //accepter le panier
            
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"basket\"]/div[1]/div[2]/div[2]/div[4]/div[3]/form/button")).Click(); //valider le panier
            // mode de livraison           
          
            
            Thread.Sleep(1000);
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//*[@id=\"deliveryModes\"]/div/div/div[2]/div[3]/div/div[1]")));
            driver.FindElement(By.XPath("//*[@id=\"deliveryModes\"]/div/div/div[2]/div[3]/div/div[1]")).Click();// En point de retrais
            
            Thread.Sleep(2000);
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//*[@id=\"livraison\"]/label")));
            driver.FindElement(By.XPath("//*[@id=\"livraison\"]/label")).Click(); // Point de relais
            
            Thread.Sleep(1000);
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//*[@id=\"bloc_liv_000\"]/div/div[3]/div[1]/div/div[1]/div[3]/button[2]")));
            driver.FindElement(By.XPath("//*[@id=\"bloc_liv_000\"]/div/div[3]/div[1]/div/div[1]/div[3]/button[2]")).Click(); // valider la livraison
            

            //driver.FindElement(By.CssSelector("#advantages > div.chckt__left > div.adv__gifts > div > div > span > svg")).Click();// avoir des extraits
            
            Thread.Sleep(1000);
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.Id("validateDeliveryButton")));
            driver.FindElement(By.Id("validateDeliveryButton")).Click();

            // passer au paiement

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"adv_payment_submit\"]")).Click();


            //Carte de credit 
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"payment\"]/div[1]/div/div[1]")).Click();

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"payment\"]/div[1]/div/div[2]/div/div[2]/button[3]")).Click();

            /*driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/input")).SendKeys("Prénom Nom");
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/form/div/div[1]/input")));
            driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/form/div/div[1]/input")).SendKeys("5434 5563 4456 6654");
            driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/input")).SendKeys("12/25");
            driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/input")).SendKeys("721");
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//*[@id=\"hipay-form\"]/div[3]/span")));
            driver.FindElement(By.XPath("//*[@id=\"hipay-form\"]/div[3]/span")).Click();
            driver.FindElement(By.XPath("//*[@id=\"hipay-submit-button\"]")).Submit();
            */ 

        }




        [Test]
        public void EffectuerUnSansEtreConnecte()
        {

            js = (IJavaScriptExecutor)driver;

            driver.Navigate().GoToUrl("https://www.nocibe.fr/fete-des-peres/C-86790/NW-4776-type-doffres~eligibles-aux-codes-promo?msclkid=eb9efd9e6ddd17bb467b99e133b8496d&utm_source=bing&utm_medium=cpc&utm_campaign=%5BB%5D%20%5BKW%5D%20%5BBrand%5D%20FR_n%3ANocibe_id%3A0000_k%3Abrandid_mt%3Aexact_&utm_term=nocibe&utm_content=%5BKW%5D%20%5BBrand%5D%20FR_n%3ANocibe_id%3A0000%2B1_k%3Atypeid_mt%3Aexact_#products");
            driver.Manage().Window.Maximize();

            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"didomi-popup\"]/div/div/div/span")).Click(); // Refus des Cokies

            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"prodlist\"]/div[3]/div[1]/div[2]/div[4]/div[1]")).Click(); // Types de produits
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//*[@id=\"prodlist\"]/div[3]/div[1]/div[2]/div[4]/div[2]/ul/li[15]/label/div[2]/span")));// scrole Gel douche
            driver.FindElement(By.XPath("//*[@id=\"prodlist\"]/div[3]/div[1]/div[2]/div[4]/div[2]/ul/li[20]/label/div[2]/span")).Click(); // rasage barbe 
            driver.FindElement(By.XPath("//*[@id=\"prodlist\"]/div[3]/div[1]/div[2]/div[4]/div[2]/a")).Click(); //Appliquer le filtre

            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"prodlist\"]/div[3]/div[1]/div[2]/div[7]/div[1]")).Click(); // Types de peaux
            driver.FindElement(By.XPath("//*[@id=\"prodlist\"]/div[3]/div[1]/div[2]/div[7]/div[2]/ul/li[2]/label/div[2]/span")).Click(); // tt type de peaux mm sensibles
            driver.FindElement(By.XPath("//*[@id=\"prodlist\"]/div[3]/div[1]/div[2]/div[7]/div[2]/a")).Click(); // Appliquer les filtre

            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"prodlist\"]/div[4]/div[2]/div[2]/a/div[2]/img")).Click(); // Biotherme
            driver.FindElement(By.XPath("//*[@id=\"btnAddBasket\"]")).Click(); // Ajouter au panier
            Thread.Sleep(2000);
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//*[@id=\"headerTop\"]/div[1]/div/header/div[2]/div[5]/div[2]/a/svg/path[1]")));
            driver.FindElement(By.XPath("//*[@id=\"headerTop\"]/div[1]/div/header/div[2]/div[5]/div[2]/a/svg/path[1]")).Click();// Voir le panier 

            Thread.Sleep(2000);
            //driver.FindElement(By.Id("basket_goToLivraison")).Click(); // Valider le panier
            //Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"email\"]")).SendKeys("boussoul.sadek@gmail.com");
            driver.FindElement(By.XPath("//*[@id=\"mdp1\"]")).SendKeys("Sadek@2024");
            driver.FindElement(By.XPath("//*[@id=\"new-user\"]/div/div/div/button/span")).Click();


            //  driver.FindElement(By.XPath("//*[@id=\"prodlist\"]/div[4]/div[2]/div[3]/a/div[2]/img")).Click(); // Monsieur barbier
            //Thread.Sleep(2000);
            //driver.FindElement(By.XPath("//*[@id=\"checkDispo\"]")).Click(); // acheter en click and collect
            //Thread.Sleep(2000);
            //driver.FindElement(By.XPath("//*[@id=\"f_productLocator_search\"]/div[2]/div/a")).Click(); // Me geolocaliser
            //Thread.Sleep(2000);
            //driver.FindElement(By.CssSelector("#btnAddBasketundefined > span")).Click(); //Acheter click and collect
            //Thread.Sleep(5000);


        }

        [TearDown]
        public void TearDown()
        {
            //driver.Close();
            //driver.Dispose();
        }
    }
}