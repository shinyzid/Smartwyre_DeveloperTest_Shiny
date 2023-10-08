using System;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    {
        //throw new NotImplementedException();

        Rebate rebate = new Rebate { Incentive = IncentiveType.FixedCashAmount, Amount = 50 };
        Product product = new Product { SupportedIncentives = SupportedIncentiveType.FixedCashAmount };
        Request request = new Request { Volume = 10 };

        IIncentiveValidator validator = new FixedCashAmountValidator();

        decimal rebateAmount;

        bool result = validator.Validate(rebate, product, request, out rebateAmount);

        if (result)
        {
            Console.WriteLine("Validation successful!");
            Console.WriteLine("Rebate Amount: " + rebateAmount);
        }
        else
        {
            Console.WriteLine("Validation failed.");
        }
    }
} 











    

