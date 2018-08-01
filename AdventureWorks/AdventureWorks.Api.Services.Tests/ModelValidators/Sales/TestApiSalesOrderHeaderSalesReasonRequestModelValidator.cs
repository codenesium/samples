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
	[Trait("Table", "SalesOrderHeaderSalesReason")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSalesOrderHeaderSalesReasonRequestModelValidatorTest
	{
		public ApiSalesOrderHeaderSalesReasonRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void SalesReasonID_Create_Valid_Reference()
		{
			Mock<ISalesOrderHeaderSalesReasonRepository> salesOrderHeaderSalesReasonRepository = new Mock<ISalesOrderHeaderSalesReasonRepository>();
			salesOrderHeaderSalesReasonRepository.Setup(x => x.GetSalesReason(It.IsAny<int>())).Returns(Task.FromResult<SalesReason>(new SalesReason()));

			var validator = new ApiSalesOrderHeaderSalesReasonRequestModelValidator(salesOrderHeaderSalesReasonRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesOrderHeaderSalesReasonRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SalesReasonID, 1);
		}

		[Fact]
		public async void SalesReasonID_Create_Invalid_Reference()
		{
			Mock<ISalesOrderHeaderSalesReasonRepository> salesOrderHeaderSalesReasonRepository = new Mock<ISalesOrderHeaderSalesReasonRepository>();
			salesOrderHeaderSalesReasonRepository.Setup(x => x.GetSalesReason(It.IsAny<int>())).Returns(Task.FromResult<SalesReason>(null));

			var validator = new ApiSalesOrderHeaderSalesReasonRequestModelValidator(salesOrderHeaderSalesReasonRepository.Object);

			await validator.ValidateCreateAsync(new ApiSalesOrderHeaderSalesReasonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SalesReasonID, 1);
		}

		[Fact]
		public async void SalesReasonID_Update_Valid_Reference()
		{
			Mock<ISalesOrderHeaderSalesReasonRepository> salesOrderHeaderSalesReasonRepository = new Mock<ISalesOrderHeaderSalesReasonRepository>();
			salesOrderHeaderSalesReasonRepository.Setup(x => x.GetSalesReason(It.IsAny<int>())).Returns(Task.FromResult<SalesReason>(new SalesReason()));

			var validator = new ApiSalesOrderHeaderSalesReasonRequestModelValidator(salesOrderHeaderSalesReasonRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderSalesReasonRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SalesReasonID, 1);
		}

		[Fact]
		public async void SalesReasonID_Update_Invalid_Reference()
		{
			Mock<ISalesOrderHeaderSalesReasonRepository> salesOrderHeaderSalesReasonRepository = new Mock<ISalesOrderHeaderSalesReasonRepository>();
			salesOrderHeaderSalesReasonRepository.Setup(x => x.GetSalesReason(It.IsAny<int>())).Returns(Task.FromResult<SalesReason>(null));

			var validator = new ApiSalesOrderHeaderSalesReasonRequestModelValidator(salesOrderHeaderSalesReasonRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderSalesReasonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SalesReasonID, 1);
		}
	}
}

/*<Codenesium>
    <Hash>8aa28c9aecfa96606e1bc3d9410a72dc</Hash>
</Codenesium>*/