uusing System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

public class XmlVerifier
{
    public static void VerifyAndDeleteNonAlphabeticContent(string filePath)
    {
        try
        {
            // Load the XML file
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            // Get all text nodes in the XML document
            XmlNodeList textNodes = xmlDoc.SelectNodes("//text()");

            // Iterate through each text node
            foreach (XmlNode textNode in textNodes)
            {
                // Remove any non-alphabetic characters using regular expression
                string cleanedText = Regex.Replace(textNode.InnerText, "[^a-zA-Z]", "");

                // Update the text node with the cleaned text
                textNode.InnerText = cleanedText;
            }

            // Save the modified XML document
            xmlDoc.Save(filePath);

            Console.WriteLine("XML file verified and non-alphabetic content deleted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred while verifying XML file: " + ex.Message);
        }
    }
}
