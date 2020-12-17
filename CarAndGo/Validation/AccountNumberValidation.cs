using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarAndGo.Validation
{
    public class AccountNumberValidation
    {
        public bool IsValid(string accountNumber)
        {
            if (Regex.IsMatch(accountNumber, @"(((86|\+3706) \d{3} \d{4})" +
                                              @"|((86|\+3706)\d{3}\d{4})|" +
                                              @"((86|\+3706) \d{3}\d{4})|" +
                                               @"((86|\+3706)\d{3} \d{4}))"))
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
    }
}
