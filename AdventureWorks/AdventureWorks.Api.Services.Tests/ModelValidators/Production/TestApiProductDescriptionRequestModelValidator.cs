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
	[Trait("Table", "ProductDescription")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiProductDescriptionRequestModelValidatorTest
	{
		public ApiProductDescriptionRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Description_Create_null()
		{
			Mock<IProductDescriptionRepository> productDescriptionRepository = new Mock<IProductDescriptionRepository>();
			productDescriptionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductDescription()));

			var validator = new ApiProductDescriptionRequestModelValidator(productDescriptionRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductDescriptionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Description_Update_null()
		{
			Mock<IProductDescriptionRepository> productDescriptionRepository = new Mock<IProductDescriptionRepository>();
			productDescriptionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductDescription()));

			var validator = new ApiProductDescriptionRequestModelValidator(productDescriptionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductDescriptionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Description_Create_length()
		{
			Mock<IProductDescriptionRepository> productDescriptionRepository = new Mock<IProductDescriptionRepository>();
			productDescriptionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductDescription()));

			var validator = new ApiProductDescriptionRequestModelValidator(productDescriptionRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductDescriptionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 401));
		}

		[Fact]
		public async void Description_Update_length()
		{
			Mock<IProductDescriptionRepository> productDescriptionRepository = new Mock<IProductDescriptionRepository>();
			productDescriptionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductDescription()));

			var validator = new ApiProductDescriptionRequestModelValidator(productDescriptionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductDescriptionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 401));
		}
	}
}

/*<Codenesium>
    <Hash>8498d955ba797294aa3761b7106c4d1d</Hash>
</Codenesium>*/