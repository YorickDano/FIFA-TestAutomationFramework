namespace Core.UI
{
    using Core.Utils;
    using PageObjects;
    using PageObjects.Footer;

    public class CheckLinksManager
    {
        public static int CountNumberOfLinks()
        {
            Logger.Info($"Counting number of links to other pages");
            return new Footer().ListOfLinksToOtherPages.ToList().Count();
        }
    }
}
