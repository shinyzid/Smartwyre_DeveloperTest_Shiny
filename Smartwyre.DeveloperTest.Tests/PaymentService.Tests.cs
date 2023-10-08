using System;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class PaymentServiceTests
{
    [Fact]
    public void Test1()
    {
        //throw new NotImplementedException();
        FixedCashAmountValidator_Test();
        //FixedRateRebateValidator_Test();
        //AmountPerUomValidator_Test();

    }

    [Fact]
    private void FixedCashAmountValidator_Test()
        {
            // Arrange
            Rebate rebate = new Rebate { Incentive = IncentiveType.FixedCashAmount, Amount = 50 };
            Product product = new Product { SupportedIncentives = SupportedIncentiveType.FixedCashAmount };
            Request request = new Request { Volume = 10 };
            decimal rebateAmount;

            IIncentiveValidator validator = new FixedCashAmountValidator();

            // Act
            bool result = validator.Validate(rebate, product, request, out rebateAmount);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(50, rebateAmount);
        }

    [Fact]
    private void FixedRateRebateValidator_Test()
        {
            // Arrange
            Rebate rebate = new Rebate { Incentive = IncentiveType.FixedRateRebate, Percentage = 0.1 };
            Product product = new Product { SupportedIncentives = SupportedIncentiveType.FixedRateRebate };
            Request request = new Request { Volume = 10, Price = 100 };
            decimal rebateAmount;

            IIncentiveValidator validator = new FixedRateRebateValidator();

            // Act
            bool result = validator.Validate(rebate, product, request, out rebateAmount);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(100, rebateAmount);
        }

    [Fact]
    private void AmountPerUomValidator_Test()
        {
            // Arrange
            Rebate rebate = new Rebate { Incentive = IncentiveType.AmountPerUom, Amount = 5 };
            Product product = new Product { SupportedIncentives = SupportedIncentiveType.AmountPerUom };
            Request request = new Request { Volume = 10 };
            decimal rebateAmount;

            IIncentiveValidator validator = new AmountPerUomValidator();

            // Act
            bool result = validator.Validate(rebate, product, request, out rebateAmount);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(50, rebateAmount);
        }
    
}
