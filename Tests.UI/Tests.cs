namespace Tests.UI
{
    using Core.Services;
    using Core.UI;
    using Core.UI.Enums;
    using FluentAssertions;
    using Models.Tests;
    using NUnit.Framework;
    using System;
    using System.IO;
    using static Core.Utils.AssertsPool;

    public class Tests : BaseTest
    {
        [Test]
        public void RedirectionTest()
        {
            var testDataFullPath = Path.Combine("UI", "ExpectedData", $"testsData.{Environment.GetEnvironmentVariable("stage")}.json");

            var testData = JsonDeserializer.DeserializeSectionFromFile<RedirectionTestData>(testDataFullPath);
            ConfirmPrivacyManager.ConfirmPrivacy();
            SocialNetworksManager.GoToSocialNetwork(SocialNetwork.Instagram);
            Verify(() => BrowserPool.GetBrowser().GetCurrentUrl().Should().Be(testData.ExpectedUrl));
        }

        [Test]
        public void FifaPartnersTest()
        {
            var testDataFullPath = Path.Combine("UI", "ExpectedData", $"testsData.{Environment.GetEnvironmentVariable("stage")}.json");

            var testData = JsonDeserializer.DeserializeSectionFromFile<FifaPartnersTestData>(testDataFullPath);
            ConfirmPrivacyManager.ConfirmPrivacy();
            Verify(() => PartnersManager.GetPartnersNameList().Should().BeEquivalentTo(testData.ExpectedPartners));
        }

        [Test]
        public void HeaderLinksTest()
        {
            ConfirmPrivacyManager.ConfirmPrivacy();
            LanguageManager.ChangeLanguageTo(Language.Russian);
            Verify(() => HeaderMenuManager.GetLinkCount().Should().Be(0));
        }
    }
}
