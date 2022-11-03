using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Globalization;

namespace MottMacDonald
{
    public static class StringExtensions
    {
        public static string TitleCaseString(this string stringToConvert)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(stringToConvert);
        }
    }
}
