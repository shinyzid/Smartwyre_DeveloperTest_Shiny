using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Services
{

    /*
    I have added a new class file called NewRabateServices.cs(Its attached along with the mail).
    Added an interface called IIncentiveValidator so we can extend the business for additional requirements in future.
    FixedCashAmountValidator , FixedRateRebateValidator, AmountPerUomValidator are the three separate methods emphasizing SOLID principles. 
    Haven't implemented a try, catch block for the time being.    
    Also would prefer to use ObservableCollection to modify the Rebat class, so we could update the UI using InotifyChanged/Observable pattern.  
    Also for LINQ support/enhancements in future. 
    */

    public interface IIncentiveValidator
    {
        bool Validate(Rebate rebate, Product product, Request request, out decimal rebateAmount);
    }

    public class FixedCashAmountValidator : IIncentiveValidator
    {

        public bool Validate(Rebate rebate, Product product, Request request, out decimal rebateAmount)
        {
            rebateAmount = 0;

            if (rebate == null || rebate.Amount == 0 || !product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount))
                return false;

            rebateAmount = rebate.Amount;
            return true;
        }
    

    }

    public class FixedRateRebateValidator : IIncentiveValidator
    {
        public bool Validate(Rebate rebate, Product product, Request request, out decimal rebateAmount)
        {
            rebateAmount = 0;

            if (rebate == null || rebate.Percentage == 0 || product.Price == 0 || request.Volume == 0 ||
                !product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate))
                return false;

            rebateAmount = product.Price * rebate.Percentage * request.Volume;
            return true;
        }
    }

    public class AmountPerUomValidator : IIncentiveValidator
    {
        public bool Validate(Rebate rebate, Product product, Request request, out decimal rebateAmount)
        {
            rebateAmount = 0;

            if (rebate == null || rebate.Amount == 0 || request.Volume == 0 ||
                !product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom))
                return false;

            rebateAmount = rebate.Amount * request.Volume;
            return true;
        }
    }
}
