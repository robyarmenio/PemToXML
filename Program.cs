// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Xml;

Console.WriteLine("PEM to XML RSA Key Converter started...");

string? filename = "";
if (args.Length > 0)
    filename = args[0];
else
{
    Console.WriteLine("Please enter PEM filename:");
    filename = Console.ReadLine();
}

if (!String.IsNullOrEmpty(filename))
{
    var privateKey = await File.ReadAllTextAsync(filename);
    var rsa = RSA.Create();
    rsa.ImportFromPem(privateKey.ToCharArray());
    var d = new XmlDocument();
    d.LoadXml(rsa.ToXmlString(true));

    var xmlFilename = filename.EndsWith(".pem") ? filename.Replace(".pem", ".xml") : filename + ".xml";
    d.Save(xmlFilename);
}