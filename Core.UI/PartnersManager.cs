namespace Core.UI
{
    using Core.Utils;
    using PageObjects;
    using System.Collections.Generic;
    using System.Linq;
    using TechTalk.SpecFlow;
    using Core.UI.Enums;

    [Binding]
    public static class PartnersManager
    {
        public static List<string> GetPartnersNameList()
        {
            Logger.Info("Try to get partners list");
            return new MainPage().FifaPartnersSection.PartnersList.Select(el => el.GetTitle()).ToList();
        }

        [Given(@"I switch to partner page ""(.*)""")]
        public static void GoToPartnerPage(Partner partner) 
        {
            var page = new MainPage();
            Logger.Info($"Try redirect to {partner} page");
            switch (partner)
            {
                case Partner.Adidas:
                    {
                        page.FifaPartnersSection.AdidasButton.Click();
                        break;
                    }
                case Partner.CocaCola:
                    {
                        page.FifaPartnersSection.CocaColaButton.Click();
                        break;
                    }   
                case Partner.Wanda:
                    {
                        page.FifaPartnersSection.WandaButton.Click();
                        break;
                    }
                case Partner.Hundai:
                    {
                        page.FifaPartnersSection.HundaiButton.Click();
                        break;
                    }
                case Partner.QuatarAirways:
                    {
                        page.FifaPartnersSection.QatarAirwaysButton.Click();
                        break;
                    }
                case Partner.QatarEnergy:
                    {
                        page.FifaPartnersSection.QatarEnergyButton.Click();
                        break;
                    }
                case Partner.Visa:
                    {
                        page.FifaPartnersSection.VisaButton.Click();
                        break;
                    }
                default: throw new ArgumentOutOfRangeException("Partner " + nameof(partner) + "doesn't exist!");
            }
            Logger.Info($"Successful redirection to {partner} page");
        }
    }
}