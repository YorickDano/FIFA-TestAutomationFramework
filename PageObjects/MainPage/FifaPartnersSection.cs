namespace PageObjects
{
    using Core.Elements;
    using OpenQA.Selenium;
    using static Core.Utils.ElementFinder;

    public class FifaPartnersSection : IPageObject
    {
        public IEnumerable<IButton> PartnersList => GetElements<Button>(By.XPath("//div[contains(@class,'logos')]//img"), nameof(PartnersList));
        public IButton AdidasButton => Get<Button>(By.XPath(GetPartnerXpath("adidas")), nameof(AdidasButton));
        public IButton CocaColaButton => Get<Button>(By.XPath(GetPartnerXpath("coca-cola")), nameof(CocaColaButton));
        public IButton WandaButton => Get<Button>(By.XPath(GetPartnerXpath("wanda")), nameof(WandaButton));
        public IButton HundaiButton => Get<Button>(By.XPath(GetPartnerXpath("hundai")), nameof(HundaiButton));
        public IButton QatarAirwaysButton => Get<Button>(By.XPath(GetPartnerXpath("qatarairways")), nameof(QatarAirwaysButton));
        public IButton QatarEnergyButton => Get<Button>(By.XPath(GetPartnerXpath("qatarenergy")), nameof(QatarEnergyButton));
        public IButton VisaButton => Get<Button>(By.XPath(GetPartnerXpath("visa")), nameof(VisaButton));
      
        private static string GetPartnerXpath(string partnerName) => $"//div[contains(@class,'logos')]//a[contains(@href,'{partnerName}')]";
    }
}
