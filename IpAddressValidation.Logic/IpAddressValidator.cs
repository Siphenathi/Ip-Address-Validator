using System;

namespace IpAddressValidation.Logic
{
    public class IpAddressValidator
    {
        public IpAddressValidator()
        {
        }

        public bool ValidateIpv4Address(string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(ipAddress) || ipAddress.EndsWith("."))
            {
                return false;
            }

            int startPosition = 0;
            int numberOfDots = 0;

            for (var x = 0; x < ipAddress.Length; x++)
            {
                if (ipAddress[x].ToString() == ".")
                {
                    startPosition = x;
                    numberOfDots++;
                }
            }

            var lastDigit = Convert.ToInt32(ipAddress.Substring(startPosition + 1));

            if (lastDigit == 0 || lastDigit == 255 || numberOfDots != 3)
            {
                return false;
            }

            return true;
        }
    }
}