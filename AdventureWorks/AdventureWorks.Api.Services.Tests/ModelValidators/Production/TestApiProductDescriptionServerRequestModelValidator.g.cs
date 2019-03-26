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
	public partial class ApiProductDescriptionServerRequestModelValidatorTest
	{
		public ApiProductDescriptionServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Description_Create_null()
		{
			Mock<IProductDescriptionRepository> productDescriptionRepository = new Mock<IProductDescriptionRepository>();
			productDescriptionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductDescription()));

			var validator = new ApiProductDescriptionServerRequestModelValidator(productDescriptionRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductDescriptionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Description_Update_null()
		{
			Mock<IProductDescriptionRepository> productDescriptionRepository = new Mock<IProductDescriptionRepository>();
			productDescriptionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductDescription()));

			var validator = new ApiProductDescriptionServerRequestModelValidator(productDescriptionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductDescriptionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Description_Create_length()
		{
			Mock<IProductDescriptionRepository> productDescriptionRepository = new Mock<IProductDescriptionRepository>();
			productDescriptionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductDescription()));

			var validator = new ApiProductDescriptionServerRequestModelValidator(productDescriptionRepository.Object);
			await validator.ValidateCreateAsync(new ApiProductDescriptionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 401));
		}

		[Fact]
		public async void Description_Update_length()
		{
			Mock<IProductDescriptionRepository> productDescriptionRepository = new Mock<IProductDescriptionRepository>();
			productDescriptionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductDescription()));

			var validator = new ApiProductDescriptionServerRequestModelValidator(productDescriptionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiProductDescriptionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 401));
		}

		[Fact]
		private async void BeUniqueByRowguid_Create_Exists()
		{
			Mock<IProductDescriptionRepository> productDescriptionRepository = new Mock<IProductDescriptionRepository>();
			productDescriptionRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<ProductDescription>(new ProductDescription()));
			var validator = new ApiProductDescriptionServerRequestModelValidator(productDescriptionRepository.Object);

			await validator.ValidateCreateAsync(new ApiProductDescriptionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Create_Not_Exists()
		{
			Mock<IProductDescriptionRepository> productDescriptionRepository = new Mock<IProductDescriptionRepository>();
			productDescriptionRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<ProductDescription>(null));
			var validator = new ApiProductDescriptionServerRequestModelValidator(productDescriptionRepository.Object);

			await validator.ValidateCreateAsync(new ApiProductDescriptionServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Update_Exists()
		{
			Mock<IProductDescriptionRepository> productDescriptionRepository = new Mock<IProductDescriptionRepository>();
			productDescriptionRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<ProductDescription>(new ProductDescription()));
			var validator = new ApiProductDescriptionServerRequestModelValidator(productDescriptionRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiProductDescriptionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Update_Not_Exists()
		{
			Mock<IProductDescriptionRepository> productDescriptionRepository = new Mock<IProductDescriptionRepository>();
			productDescriptionRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<ProductDescription>(null));
			var validator = new ApiProductDescriptionServerRequestModelValidator(productDescriptionRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiProductDescriptionServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>401a2182ab8ed61f85603e42b4629d03</Hash>
</Codenesium>*/