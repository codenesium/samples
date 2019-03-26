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
	[Trait("Table", "SalesTerritory")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSalesTerritoryServerRequestModelValidatorTest
	{
		public ApiSalesTerritoryServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void CountryRegionCode_Create_null()
		{
			Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
			salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

			var validator = new ApiSalesTerritoryServerRequestModelValidator(salesTerritoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesTerritoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CountryRegionCode, null as string);
		}

		[Fact]
		public async void CountryRegionCode_Update_null()
		{
			Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
			salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

			var validator = new ApiSalesTerritoryServerRequestModelValidator(salesTerritoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesTerritoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CountryRegionCode, null as string);
		}

		[Fact]
		public async void CountryRegionCode_Create_length()
		{
			Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
			salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

			var validator = new ApiSalesTerritoryServerRequestModelValidator(salesTerritoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesTerritoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CountryRegionCode, new string('A', 4));
		}

		[Fact]
		public async void CountryRegionCode_Update_length()
		{
			Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
			salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

			var validator = new ApiSalesTerritoryServerRequestModelValidator(salesTerritoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesTerritoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CountryRegionCode, new string('A', 4));
		}

		[Fact]
		public async void ReservedGroup_Create_null()
		{
			Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
			salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

			var validator = new ApiSalesTerritoryServerRequestModelValidator(salesTerritoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesTerritoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReservedGroup, null as string);
		}

		[Fact]
		public async void ReservedGroup_Update_null()
		{
			Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
			salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

			var validator = new ApiSalesTerritoryServerRequestModelValidator(salesTerritoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesTerritoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReservedGroup, null as string);
		}

		[Fact]
		public async void ReservedGroup_Create_length()
		{
			Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
			salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

			var validator = new ApiSalesTerritoryServerRequestModelValidator(salesTerritoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesTerritoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReservedGroup, new string('A', 51));
		}

		[Fact]
		public async void ReservedGroup_Update_length()
		{
			Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
			salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

			var validator = new ApiSalesTerritoryServerRequestModelValidator(salesTerritoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesTerritoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReservedGroup, new string('A', 51));
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
			salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

			var validator = new ApiSalesTerritoryServerRequestModelValidator(salesTerritoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesTerritoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
			salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

			var validator = new ApiSalesTerritoryServerRequestModelValidator(salesTerritoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesTerritoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
			salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

			var validator = new ApiSalesTerritoryServerRequestModelValidator(salesTerritoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesTerritoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
			salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

			var validator = new ApiSalesTerritoryServerRequestModelValidator(salesTerritoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesTerritoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
			salesTerritoryRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<SalesTerritory>(new SalesTerritory()));
			var validator = new ApiSalesTerritoryServerRequestModelValidator(salesTerritoryRepository.Object);

			await validator.ValidateCreateAsync(new ApiSalesTerritoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
			salesTerritoryRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<SalesTerritory>(null));
			var validator = new ApiSalesTerritoryServerRequestModelValidator(salesTerritoryRepository.Object);

			await validator.ValidateCreateAsync(new ApiSalesTerritoryServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
			salesTerritoryRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<SalesTerritory>(new SalesTerritory()));
			var validator = new ApiSalesTerritoryServerRequestModelValidator(salesTerritoryRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSalesTerritoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
			salesTerritoryRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<SalesTerritory>(null));
			var validator = new ApiSalesTerritoryServerRequestModelValidator(salesTerritoryRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSalesTerritoryServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>973ae63de12a613f2f9a5b9a79f003f1</Hash>
</Codenesium>*/