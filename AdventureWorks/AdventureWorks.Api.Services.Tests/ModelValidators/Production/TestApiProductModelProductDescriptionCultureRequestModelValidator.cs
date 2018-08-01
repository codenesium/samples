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
	[Trait("Table", "ProductModelProductDescriptionCulture")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiProductModelProductDescriptionCultureRequestModelValidatorTest
	{
		public ApiProductModelProductDescriptionCultureRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void CultureID_Create_null()
		{
			Mock<IProductModelProductDescriptionCultureRepository> productModelProductDescriptionCultureRepository = new Mock<IProductModelProductDescriptionCultureRepository>();
			productModelProductDescriptionCultureRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductModelProductDescriptionCulture()));

			var validator = new ApiProductModelProductDescriptionCultureRequestModelValidator(productModelProductDescriptionCultureRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductModelProductDescriptionCultureRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CultureID, null as string);
		}

		[Fact]
		public async void CultureID_Update_null()
		{
			Mock<IProductModelProductDescriptionCultureRepository> productModelProductDescriptionCultureRepository = new Mock<IProductModelProductDescriptionCultureRepository>();
			productModelProductDescriptionCultureRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductModelProductDescriptionCulture()));

			var validator = new ApiProductModelProductDescriptionCultureRequestModelValidator(productModelProductDescriptionCultureRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductModelProductDescriptionCultureRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CultureID, null as string);
		}

		[Fact]
		public async void CultureID_Create_length()
		{
			Mock<IProductModelProductDescriptionCultureRepository> productModelProductDescriptionCultureRepository = new Mock<IProductModelProductDescriptionCultureRepository>();
			productModelProductDescriptionCultureRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductModelProductDescriptionCulture()));

			var validator = new ApiProductModelProductDescriptionCultureRequestModelValidator(productModelProductDescriptionCultureRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductModelProductDescriptionCultureRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CultureID, new string('A', 7));
		}

		[Fact]
		public async void CultureID_Update_length()
		{
			Mock<IProductModelProductDescriptionCultureRepository> productModelProductDescriptionCultureRepository = new Mock<IProductModelProductDescriptionCultureRepository>();
			productModelProductDescriptionCultureRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductModelProductDescriptionCulture()));

			var validator = new ApiProductModelProductDescriptionCultureRequestModelValidator(productModelProductDescriptionCultureRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductModelProductDescriptionCultureRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CultureID, new string('A', 7));
		}
	}
}

/*<Codenesium>
    <Hash>d39df0eceae44302520574919ba6a550</Hash>
</Codenesium>*/