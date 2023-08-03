namespace PageObjects.WorldRankingPage
{
    using Core.Elements;
    using Core.Utils;
    using Core.Interfaces;
    using OpenQA.Selenium;
    using static Core.Utils.ElementFinder;

    public class WorldRankingPage
    {
        public IEnumerable<Button> TableRankingMen => 
            GetElements<Button>(By.XPath("//*[(text()='Men')]/parent::*/following-sibling::table/descendant::tr[contains(@class, 'fc-ranking-item_rankingTableRow__EvVTX')]"), nameof(TableRankingMen));
    }
}
