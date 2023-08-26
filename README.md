# XMLValidator
A sample utility that can be used to validate an XML file against a given schema.

To use this function, you can call VerifyAndDeleteNonAlphabeticContent method and pass the file path of the XML file you want to verify and delete non-alphabetic content from. For example:

string filePath = "path/to/your/xml/file.xml";
XmlVerifier.VerifyAndDeleteNonAlphabeticContent(filePath);

Please note that this function assumes that the XML file is well-formed and can be loaded using the XmlDocument class.
