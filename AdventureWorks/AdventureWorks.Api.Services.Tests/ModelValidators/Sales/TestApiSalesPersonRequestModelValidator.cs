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
	[Trait("Table", "SalesPerson")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSalesPersonRequestModelValidatorTest
	{
		public ApiSalesPersonRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void TerritoryID_Create_Valid_Reference()
		{
			Mock<ISalesPersonRepository> salesPersonRepository = new Mock<ISalesPersonRepository>();
			salesPersonRepository.Setup(x => x.GetSalesTerritory(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(new SalesTerritory()));

			var validator = new ApiSalesPersonRequestModelValidator(salesPersonRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesPersonRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TerritoryID, 1);
		}

		[Fact]
		public async void TerritoryID_Create_Invalid_Reference()
		{
			Mock<ISalesPersonRepository> salesPersonRepository = new Mock<ISalesPersonRepository>();
			salesPersonRepository.Setup(x => x.GetSalesTerritory(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(null));

			var validator = new ApiSalesPersonRequestModelValidator(salesPersonRepository.Object);

			await validator.ValidateCreateAsync(new ApiSalesPersonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TerritoryID, 1);
		}

		[Fact]
		public async void TerritoryID_Update_Valid_Reference()
		{
			Mock<ISalesPersonRepository> salesPersonRepository = new Mock<ISalesPersonRepository>();
			salesPersonRepository.Setup(x => x.GetSalesTerritory(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(new SalesTerritory()));

			var validator = new ApiSalesPersonRequestModelValidator(salesPersonRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesPersonRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TerritoryID, 1);
		}

		[Fact]
		public async void TerritoryID_Update_Invalid_Reference()
		{
			Mock<ISalesPersonRepository> salesPersonRepository = new Mock<ISalesPersonRepository>();
			salesPersonRepository.Setup(x => x.GetSalesTerritory(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(null));

			var validator = new ApiSalesPersonRequestModelValidator(salesPersonRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSalesPersonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TerritoryID, 1);
		}
	}
}

/*<Codenesium>
    <Hash>a65dfa36b79759f31f849a612618bf03</Hash>
</Codenesium>*/