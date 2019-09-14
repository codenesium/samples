using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Sale")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSaleServerRequestModelValidatorTest
	{
		public ApiSaleServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Note_Create_null()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

			var validator = new ApiSaleServerRequestModelValidator(saleRepository.Object);
			await validator.ValidateCreateAsync(new ApiSaleServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Note, null as string);
		}

		[Fact]
		public async void Note_Update_null()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

			var validator = new ApiSaleServerRequestModelValidator(saleRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSaleServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Note, null as string);
		}

		[Fact]
		public async void PetId_Create_Valid_Reference()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.PetByPetId(It.IsAny<int>())).Returns(Task.FromResult<Pet>(new Pet()));

			var validator = new ApiSaleServerRequestModelValidator(saleRepository.Object);
			await validator.ValidateCreateAsync(new ApiSaleServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PetId, 1);
		}

		[Fact]
		public async void PetId_Create_Invalid_Reference()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.PetByPetId(It.IsAny<int>())).Returns(Task.FromResult<Pet>(null));

			var validator = new ApiSaleServerRequestModelValidator(saleRepository.Object);

			await validator.ValidateCreateAsync(new ApiSaleServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PetId, 1);
		}

		[Fact]
		public async void PetId_Update_Valid_Reference()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.PetByPetId(It.IsAny<int>())).Returns(Task.FromResult<Pet>(new Pet()));

			var validator = new ApiSaleServerRequestModelValidator(saleRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSaleServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PetId, 1);
		}

		[Fact]
		public async void PetId_Update_Invalid_Reference()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.PetByPetId(It.IsAny<int>())).Returns(Task.FromResult<Pet>(null));

			var validator = new ApiSaleServerRequestModelValidator(saleRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSaleServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PetId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>b870ebc20e07483ff56ddc9827916955</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/