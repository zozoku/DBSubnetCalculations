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
        public uint IPnumber;
        public string DottedDecimal;
        public byte prefix;
        public byte defaultPrefix;
        public string networkMask; // dotted decimal
        public uint networkMaskNumber; // 
        public string networkMaskBinary;
        public string defaultMask;
        byte[] decimal4Byte;

        public IPv4(string dottedForm)
        {
            DottedDecimal = dottedForm;
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
            decimal4Byte[0] = (byte)number;
        }

        //public
    }

    class IPv6
    { 
    }
}
