# PemToXML
.NET 6.0 PEM to XML RSA Key Converter - Easy CLI tool

It is a more secure option than using online converters (it is never a good idea to post on Internet a private key)

## How to use it
This program converts a .PEM file (that is, a text file containing a base-64 encoded RSA Key) to its XML format.

You can execute it through CLI, optionally specifying the filename you want to convert as first line command argument. 
In case you don't provide one, the program will ask you to specify a filename to be converted.

In the same folder of the input file, the .xml file converted is created, if everyting is OK

## Input file format (example)
    -----BEGIN RSA PRIVATE KEY-----
    MIIEpAIBAAKCAQEAyLBBD1/lvIlYrGczQOUn8hRDaEixt9Q9AMPetZVSeEFzvaML
    [...]
    AmPnzopvgAzEAHYQaMPHGbktf+ngs+8V0GlW2thNyGKfllXsQZmVDQ==
    -----END RSA PRIVATE KEY-----

## Output file format (example)
    <RSAKeyValue>
        <Modulus>yLBBD1[...]nfu7w==</Modulus>
        <Exponent>AQAB</Exponent>
        <P>9D6NNtG[...]4c=</P>
        <Q>0lkH1Wb[...]ptH1k=</Q>
        <DP>oHr9[...]9lr8=</DP>
        <DQ>SDZ[...]gswk=</DQ>
        <InverseQ>jcNOF[...]lQ0=</InverseQ>
        <D>DFjLp[...]Q==</D>
    </RSAKeyValue>
