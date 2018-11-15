using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PaymentType")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPaymentTypeServerRequestModelValidatorTest
	{
		public ApiPaymentTypeServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IPaymentTypeRepository> paymentTypeRepository = new Mock<IPaymentTypeRepository>();
			paymentTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PaymentType()));

			var validator = new ApiPaymentTypeServerRequestModelValidator(paymentTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiPaymentTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IPaymentTypeRepository> paymentTypeRepository = new Mock<IPaymentTypeRepository>();
			paymentTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PaymentType()));

			var validator = new ApiPaymentTypeServerRequestModelValidator(paymentTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPaymentTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IPaymentTypeRepository> paymentTypeRepository = new Mock<IPaymentTypeRepository>();
			paymentTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PaymentType()));

			var validator = new ApiPaymentTypeServerRequestModelValidator(paymentTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiPaymentTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IPaymentTypeRepository> paymentTypeRepository = new Mock<IPaymentTypeRepository>();
			paymentTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PaymentType()));

			var validator = new ApiPaymentTypeServerRequestModelValidator(paymentTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPaymentTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>17acaaeb928a67d530779b5129503154</Hash>
</Codenesium>*/