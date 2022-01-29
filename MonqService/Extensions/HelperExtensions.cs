using System.ComponentModel.DataAnnotations;

namespace MonqService.Extensions
{
    public static class HelperExtensions
    {
        /// <summary>
        /// Return <see cref="true"/> if email adress is valid
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static bool IsValidEmailAddress(this string address) => address != null && new EmailAddressAttribute().IsValid(address);


    }
}
