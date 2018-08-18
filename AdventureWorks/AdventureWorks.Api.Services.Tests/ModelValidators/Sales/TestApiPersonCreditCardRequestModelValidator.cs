using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PersonCreditCard")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPersonCreditCardRequestModelValidatorTest
	{
		public ApiPersonCreditCardRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void CreditCardID_Create_Valid_Reference()
		{
			Mock<IPersonCreditCardRepository> personCreditCardRepository = new Mock<IPersonCreditCardRepository>();
			personCreditCardRepository.Setup(x => x.GetCreditCard(It.IsAny<int>())).Returns(Task.FromResult<CreditCard>(new CreditCard()));

			var validator = new ApiPersonCreditCardRequestModelValidator(personCreditCardRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonCreditCardRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CreditCardID, 1);
		}

		[Fact]
		public async void CreditCardID_Create_Invalid_Reference()
		{
			Mock<IPersonCreditCardRepository> personCreditCardRepository = new Mock<IPersonCreditCardRepository>();
			personCreditCardRepository.Setup(x => x.GetCreditCard(It.IsAny<int>())).Returns(Task.FromResult<CreditCard>(null));

			var validator = new ApiPersonCreditCardRequestModelValidator(personCreditCardRepository.Object);

			await validator.ValidateCreateAsync(new ApiPersonCreditCardRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CreditCardID, 1);
		}

		[Fact]
		public async void CreditCardID_Update_Valid_Reference()
		{
			Mock<IPersonCreditCardRepository> personCreditCardRepository = new Mock<IPersonCreditCardRepository>();
			personCreditCardRepository.Setup(x => x.GetCreditCard(It.IsAny<int>())).Returns(Task.FromResult<CreditCard>(new CreditCard()));

			var validator = new ApiPersonCreditCardRequestModelValidator(personCreditCardRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonCreditCardRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CreditCardID, 1);
		}

		[Fact]
		public async void CreditCardID_Update_Invalid_Reference()
		{
			Mock<IPersonCreditCardRepository> personCreditCardRepository = new Mock<IPersonCreditCardRepository>();
			personCreditCardRepository.Setup(x => x.GetCreditCard(It.IsAny<int>())).Returns(Task.FromResult<CreditCard>(null));

			var validator = new ApiPersonCreditCardRequestModelValidator(personCreditCardRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPersonCreditCardRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CreditCardID, 1);
		}
	}
}

/*<Codenesium>
    <Hash>79997bef2fae24efcf5ad48a3c6b0bbf</Hash>
</Codenesium>*/