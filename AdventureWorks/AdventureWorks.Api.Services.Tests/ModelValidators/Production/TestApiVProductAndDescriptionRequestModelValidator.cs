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
	[Trait("Table", "VProductAndDescription")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVProductAndDescriptionRequestModelValidatorTest
	{
		public ApiVProductAndDescriptionRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Description_Create_null()
		{
			Mock<IVProductAndDescriptionRepository> vProductAndDescriptionRepository = new Mock<IVProductAndDescriptionRepository>();
			vProductAndDescriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new VProductAndDescription()));

			var validator = new ApiVProductAndDescriptionRequestModelValidator(vProductAndDescriptionRepository.Object);
			await validator.ValidateCreateAsync(new ApiVProductAndDescriptionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Description_Update_null()
		{
			Mock<IVProductAndDescriptionRepository> vProductAndDescriptionRepository = new Mock<IVProductAndDescriptionRepository>();
			vProductAndDescriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new VProductAndDescription()));

			var validator = new ApiVProductAndDescriptionRequestModelValidator(vProductAndDescriptionRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiVProductAndDescriptionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Description_Create_length()
		{
			Mock<IVProductAndDescriptionRepository> vProductAndDescriptionRepository = new Mock<IVProductAndDescriptionRepository>();
			vProductAndDescriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new VProductAndDescription()));

			var validator = new ApiVProductAndDescriptionRequestModelValidator(vProductAndDescriptionRepository.Object);
			await validator.ValidateCreateAsync(new ApiVProductAndDescriptionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 401));
		}

		[Fact]
		public async void Description_Update_length()
		{
			Mock<IVProductAndDescriptionRepository> vProductAndDescriptionRepository = new Mock<IVProductAndDescriptionRepository>();
			vProductAndDescriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new VProductAndDescription()));

			var validator = new ApiVProductAndDescriptionRequestModelValidator(vProductAndDescriptionRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiVProductAndDescriptionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 401));
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IVProductAndDescriptionRepository> vProductAndDescriptionRepository = new Mock<IVProductAndDescriptionRepository>();
			vProductAndDescriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new VProductAndDescription()));

			var validator = new ApiVProductAndDescriptionRequestModelValidator(vProductAndDescriptionRepository.Object);
			await validator.ValidateCreateAsync(new ApiVProductAndDescriptionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IVProductAndDescriptionRepository> vProductAndDescriptionRepository = new Mock<IVProductAndDescriptionRepository>();
			vProductAndDescriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new VProductAndDescription()));

			var validator = new ApiVProductAndDescriptionRequestModelValidator(vProductAndDescriptionRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiVProductAndDescriptionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IVProductAndDescriptionRepository> vProductAndDescriptionRepository = new Mock<IVProductAndDescriptionRepository>();
			vProductAndDescriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new VProductAndDescription()));

			var validator = new ApiVProductAndDescriptionRequestModelValidator(vProductAndDescriptionRepository.Object);
			await validator.ValidateCreateAsync(new ApiVProductAndDescriptionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IVProductAndDescriptionRepository> vProductAndDescriptionRepository = new Mock<IVProductAndDescriptionRepository>();
			vProductAndDescriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new VProductAndDescription()));

			var validator = new ApiVProductAndDescriptionRequestModelValidator(vProductAndDescriptionRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiVProductAndDescriptionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void ProductModel_Create_null()
		{
			Mock<IVProductAndDescriptionRepository> vProductAndDescriptionRepository = new Mock<IVProductAndDescriptionRepository>();
			vProductAndDescriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new VProductAndDescription()));

			var validator = new ApiVProductAndDescriptionRequestModelValidator(vProductAndDescriptionRepository.Object);
			await validator.ValidateCreateAsync(new ApiVProductAndDescriptionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductModel, null as string);
		}

		[Fact]
		public async void ProductModel_Update_null()
		{
			Mock<IVProductAndDescriptionRepository> vProductAndDescriptionRepository = new Mock<IVProductAndDescriptionRepository>();
			vProductAndDescriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new VProductAndDescription()));

			var validator = new ApiVProductAndDescriptionRequestModelValidator(vProductAndDescriptionRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiVProductAndDescriptionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductModel, null as string);
		}

		[Fact]
		public async void ProductModel_Create_length()
		{
			Mock<IVProductAndDescriptionRepository> vProductAndDescriptionRepository = new Mock<IVProductAndDescriptionRepository>();
			vProductAndDescriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new VProductAndDescription()));

			var validator = new ApiVProductAndDescriptionRequestModelValidator(vProductAndDescriptionRepository.Object);
			await validator.ValidateCreateAsync(new ApiVProductAndDescriptionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductModel, new string('A', 51));
		}

		[Fact]
		public async void ProductModel_Update_length()
		{
			Mock<IVProductAndDescriptionRepository> vProductAndDescriptionRepository = new Mock<IVProductAndDescriptionRepository>();
			vProductAndDescriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new VProductAndDescription()));

			var validator = new ApiVProductAndDescriptionRequestModelValidator(vProductAndDescriptionRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiVProductAndDescriptionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductModel, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>9bd7db0ba7ec64c991a346b919267802</Hash>
</Codenesium>*/