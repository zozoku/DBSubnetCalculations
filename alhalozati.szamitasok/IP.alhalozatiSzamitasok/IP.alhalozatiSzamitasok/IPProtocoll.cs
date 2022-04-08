using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP.alhalozatiSzamitasok
{
    class IPProtocoll
    {
    }

    class IPv4
    {
        // Konstruktor által beállított mezők
        public uint IPnumber;
        public string dottedDecimal;
        public byte prefix;
        public byte defaultPrefix;
        public string networkMask; // dotted decimal: pl. 255.255.0.0
        public uint networkMaskNumber; // pl. 255*2^24 + 1*2^23 --> 255.128.0.0-nak megfelelő érték -->/9
        public string networkMaskBinary;
        public string defaultMask;
        byte[] decimal4Byte;
        char classABC;

        // tanár: 2022-04-08 (iskola)
        // számított mezők: a "Kalkulacio()" metódus segítségével történik /Calculation()/
        public string binaryMask;   // 32 bit: 0 vagy 1
        public string binaryIP;     // ez is 32 bit - tehát ennyi db 0 vagy 1 (kiegészítve minden bájt érték balról a szükséges számú 0-val)


        public IPv4(string dottedForm)
        {
            dottedDecimal = dottedForm;
            string[] decimal4String = dottedForm.Split('.');
            decimal4Byte = new byte[4];
            int i = 0;
            foreach (var item in decimal4String)
            {
                decimal4Byte[i] = byte.Parse(item);
                i++;
            }

            IPnumber = (uint)(Math.Pow(2, 24) * decimal4Byte[0] +
                        Math.Pow(2, 16) * decimal4Byte[1] +
                        Math.Pow(2, 8) * decimal4Byte[2] +
                        decimal4Byte[3]);
            if (decimal4Byte[0] < 128)
                defaultPrefix = 8;
            else if (decimal4Byte[0] < 192)
                defaultPrefix = 16;
            else if (decimal4Byte[0] < 224)
                defaultPrefix = 24;
            prefix = defaultPrefix;
        }


        public IPv4(string dottedForm, byte prefix)
        {
            dottedDecimal = dottedForm;
            string[] decimal4String = dottedForm.Split('.');
            decimal4Byte = new byte[4];
            int i = 0;
            foreach (var item in decimal4String)
            {
                decimal4Byte[i] = byte.Parse(item);
                i++;
            }

            IPnumber = (uint)(Math.Pow(2, 24) * decimal4Byte[0] +
                        Math.Pow(2, 16) * decimal4Byte[1] +
                        Math.Pow(2, 8) * decimal4Byte[2] +
                        decimal4Byte[3]);
            if (decimal4Byte[0] < 128) 
            { 
                defaultPrefix = 8;

            }
            else if (decimal4Byte[0] < 192)
                defaultPrefix = 16;
            else if (decimal4Byte[0] < 224)
                defaultPrefix = 24;
            this.prefix = prefix;

        }
        //public IPv4(string dottedForm, byte prefix)
        //    :base (dottedForm)
        //{

        //}

        public IPv4(uint number)
        {
            
            if ((decimal4Byte is null))
                decimal4Byte = new byte[4];
            decimal4Byte[3] = (byte)(number % ((uint)Math.Pow(2, 8)));
            number = number / (uint)Math.Pow(2, 8);
            decimal4Byte[2] = (byte)(number % ((uint)Math.Pow(2, 8)));
            number = number / (uint)Math.Pow(2, 8);
            decimal4Byte[1] = (byte)(number % ((uint)Math.Pow(2, 8)));
            number = number / (uint)Math.Pow(2, 8);
            // tanár: 2022-04-08 - iskolában
            // plusz kód a konstruktorban
            decimal4Byte[0] = (byte)number;
            dottedDecimal = string.Join(".", decimal4Byte);
            IPnumber = number;
            if (decimal4Byte[0] < 128)
                defaultPrefix = 8;
            else if (decimal4Byte[0] < 192)
                defaultPrefix = 16;
            else if (decimal4Byte[0] < 224)
                defaultPrefix = 24;
            prefix = defaultPrefix;
        }

        // tanár: 2022-04-08 - iskolában
        public IPv4(uint number, byte prefix)
        {
            if ((decimal4Byte is null))
                decimal4Byte = new byte[4];
            decimal4Byte[3] = (byte)(number % ((uint)Math.Pow(2, 8)));
            number = number / (uint)Math.Pow(2, 8);
            decimal4Byte[2] = (byte)(number % ((uint)Math.Pow(2, 8)));
            number = number / (uint)Math.Pow(2, 8);
            decimal4Byte[1] = (byte)(number % ((uint)Math.Pow(2, 8)));
            number = number / (uint)Math.Pow(2, 8);
            // tanár: 2022-04-08 - iskolában
            // plusz kód a konstruktorban
            decimal4Byte[0] = (byte)number;
            dottedDecimal = string.Join(".", decimal4Byte);
            IPnumber = number;

            this.prefix = prefix;
        }


        // eddig: konstruktorok


        // ez a metódus (számolja ki és) állítja be a számított mezők megfelelő értékét
        // ! ezt a metódust érdemes futtatni minden elkészült IPv4 példányon ! (pl. megjelenítés esetén és előtte kötelező is)
        public void Calculation()
        {
            string actualBinaryMask = "";
            if (prefix == defaultPrefix)
                switch (prefix)
                {
                    case 8:
                        actualBinaryMask = "11111111000000000000000000000000";
                        break;
                    case 16:
                        actualBinaryMask = "11111111111111110000000000000000";
                        break;
                    case 24:
                        actualBinaryMask = "11111111111111111111111100000000";
                        break;
                    default:
                        break;
                }
            else
            {
                for (int i = 0; i < 32; i++)
                {
                    if (i <= prefix)
                        actualBinaryMask += "1";
                    else
                        actualBinaryMask += "0"; 
                }
            }
            binaryMask = actualBinaryMask;
        }        
    }

    class IPv6
    { 
    }
}
