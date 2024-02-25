// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Xml;

Console.WriteLine("PEM to XML RSA Key Converter started...");

string? filename = "";
string? keySelection = "";

if (args.Length > 0)
    filename = args[0];
else
{
    Console.WriteLine("Please choose private key (Press 0) OR public key (Press 1):");
    keySelection = Console.ReadLine();

    Console.WriteLine("Please enter PEM filename:");
    filename = Console.ReadLine();
}

if (!String.IsNullOrEmpty(filename))
    // Use for public key
    if (keySelection == "1")
    {
        var publicKeyPem = await File.ReadAllTextAsync(filename);
        // Remove headers and footers
        publicKeyPem = publicKeyPem.Replace("-----BEGIN PUBLIC KEY-----", "").Replace("-----END PUBLIC KEY-----", "").Trim();
        var publicKeyBytes = Convert.FromBase64String(publicKeyPem);
        var rsa = RSA.Create();
        rsa.ImportSubjectPublicKeyInfo(publicKeyBytes, out _);
        var d = new XmlDocument();
        d.LoadXml(rsa.ToXmlString(false)); // false to get only the public key

        var xmlFilename = filename.EndsWith(".pem") ? filename.Replace(".pem", ".xml") : filename + ".xml";
        d.Save(xmlFilename);
    }
    // In case of private key
    else if (keySelection == "0")
    {
        var privateKey = await File.ReadAllTextAsync(filename);
        var rsa = RSA.Create();
        rsa.ImportFromPem(privateKey.ToCharArray());
        var d = new XmlDocument();
        d.LoadXml(rsa.ToXmlString(true));

        var xmlFilename = filename.EndsWith(".pem") ? filename.Replace(".pem", ".xml") : filename + ".xml";
        d.Save(xmlFilename);
    }