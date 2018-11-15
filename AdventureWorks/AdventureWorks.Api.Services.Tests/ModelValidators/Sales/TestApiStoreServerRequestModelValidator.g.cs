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
	[Trait("Table", "Store")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiStoreServerRequestModelValidatorTest
	{
		public ApiStoreServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();
			storeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Store()));

			var validator = new ApiStoreServerRequestModelValidator(storeRepository.Object);
			await validator.ValidateCreateAsync(new ApiStoreServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();
			storeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Store()));

			var validator = new ApiStoreServerRequestModelValidator(storeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStoreServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();
			storeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Store()));

			var validator = new ApiStoreServerRequestModelValidator(storeRepository.Object);
			await validator.ValidateCreateAsync(new ApiStoreServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();
			storeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Store()));

			var validator = new ApiStoreServerRequestModelValidator(storeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStoreServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void SalesPersonID_Create_Valid_Reference()
		{
			Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();
			storeRepository.Setup(x => x.SalesPersonBySalesPersonID(It.IsAny<int>())).Returns(Task.FromResult<SalesPerson>(new SalesPerson()));

			var validator = new ApiStoreServerRequestModelValidator(storeRepository.Object);
			await validator.ValidateCreateAsync(new ApiStoreServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SalesPersonID, 1);
		}

		[Fact]
		public async void SalesPersonID_Create_Invalid_Reference()
		{
			Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();
			storeRepository.Setup(x => x.SalesPersonBySalesPersonID(It.IsAny<int>())).Returns(Task.FromResult<SalesPerson>(null));

			var validator = new ApiStoreServerRequestModelValidator(storeRepository.Object);

			await validator.ValidateCreateAsync(new ApiStoreServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SalesPersonID, 1);
		}

		[Fact]
		public async void SalesPersonID_Update_Valid_Reference()
		{
			Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();
			storeRepository.Setup(x => x.SalesPersonBySalesPersonID(It.IsAny<int>())).Returns(Task.FromResult<SalesPerson>(new SalesPerson()));

			var validator = new ApiStoreServerRequestModelValidator(storeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStoreServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SalesPersonID, 1);
		}

		[Fact]
		public async void SalesPersonID_Update_Invalid_Reference()
		{
			Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();
			storeRepository.Setup(x => x.SalesPersonBySalesPersonID(It.IsAny<int>())).Returns(Task.FromResult<SalesPerson>(null));

			var validator = new ApiStoreServerRequestModelValidator(storeRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiStoreServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SalesPersonID, 1);
		}

		[Fact]
		private async void BeUniqueByRowguid_Create_Exists()
		{
			Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();
			storeRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<Store>(new Store()));
			var validator = new ApiStoreServerRequestModelValidator(storeRepository.Object);

			await validator.ValidateCreateAsync(new ApiStoreServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Create_Not_Exists()
		{
			Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();
			storeRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<Store>(null));
			var validator = new ApiStoreServerRequestModelValidator(storeRepository.Object);

			await validator.ValidateCreateAsync(new ApiStoreServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Update_Exists()
		{
			Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();
			storeRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<Store>(new Store()));
			var validator = new ApiStoreServerRequestModelValidator(storeRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiStoreServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Update_Not_Exists()
		{
			Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();
			storeRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<Store>(null));
			var validator = new ApiStoreServerRequestModelValidator(storeRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiStoreServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>918d847b49f740a36dc47274c645fc11</Hash>
</Codenesium>*/