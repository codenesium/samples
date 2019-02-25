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
	[Trait("Table", "WorkOrder")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiWorkOrderServerRequestModelValidatorTest
	{
		public ApiWorkOrderServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void ProductID_Create_Valid_Reference()
		{
			Mock<IWorkOrderRepository> workOrderRepository = new Mock<IWorkOrderRepository>();
			workOrderRepository.Setup(x => x.ProductByProductID(It.IsAny<int>())).Returns(Task.FromResult<Product>(new Product()));

			var validator = new ApiWorkOrderServerRequestModelValidator(workOrderRepository.Object);
			await validator.ValidateCreateAsync(new ApiWorkOrderServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ProductID, 1);
		}

		[Fact]
		public async void ProductID_Create_Invalid_Reference()
		{
			Mock<IWorkOrderRepository> workOrderRepository = new Mock<IWorkOrderRepository>();
			workOrderRepository.Setup(x => x.ProductByProductID(It.IsAny<int>())).Returns(Task.FromResult<Product>(null));

			var validator = new ApiWorkOrderServerRequestModelValidator(workOrderRepository.Object);

			await validator.ValidateCreateAsync(new ApiWorkOrderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductID, 1);
		}

		[Fact]
		public async void ProductID_Update_Valid_Reference()
		{
			Mock<IWorkOrderRepository> workOrderRepository = new Mock<IWorkOrderRepository>();
			workOrderRepository.Setup(x => x.ProductByProductID(It.IsAny<int>())).Returns(Task.FromResult<Product>(new Product()));

			var validator = new ApiWorkOrderServerRequestModelValidator(workOrderRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiWorkOrderServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ProductID, 1);
		}

		[Fact]
		public async void ProductID_Update_Invalid_Reference()
		{
			Mock<IWorkOrderRepository> workOrderRepository = new Mock<IWorkOrderRepository>();
			workOrderRepository.Setup(x => x.ProductByProductID(It.IsAny<int>())).Returns(Task.FromResult<Product>(null));

			var validator = new ApiWorkOrderServerRequestModelValidator(workOrderRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiWorkOrderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductID, 1);
		}

		[Fact]
		public async void ScrapReasonID_Create_Valid_Reference()
		{
			Mock<IWorkOrderRepository> workOrderRepository = new Mock<IWorkOrderRepository>();
			workOrderRepository.Setup(x => x.ScrapReasonByScrapReasonID(It.IsAny<short>())).Returns(Task.FromResult<ScrapReason>(new ScrapReason()));

			var validator = new ApiWorkOrderServerRequestModelValidator(workOrderRepository.Object);
			await validator.ValidateCreateAsync(new ApiWorkOrderServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ScrapReasonID, 1);
		}

		[Fact]
		public async void ScrapReasonID_Create_Invalid_Reference()
		{
			Mock<IWorkOrderRepository> workOrderRepository = new Mock<IWorkOrderRepository>();
			workOrderRepository.Setup(x => x.ScrapReasonByScrapReasonID(It.IsAny<short>())).Returns(Task.FromResult<ScrapReason>(null));

			var validator = new ApiWorkOrderServerRequestModelValidator(workOrderRepository.Object);

			await validator.ValidateCreateAsync(new ApiWorkOrderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ScrapReasonID, 1);
		}

		[Fact]
		public async void ScrapReasonID_Update_Valid_Reference()
		{
			Mock<IWorkOrderRepository> workOrderRepository = new Mock<IWorkOrderRepository>();
			workOrderRepository.Setup(x => x.ScrapReasonByScrapReasonID(It.IsAny<short>())).Returns(Task.FromResult<ScrapReason>(new ScrapReason()));

			var validator = new ApiWorkOrderServerRequestModelValidator(workOrderRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiWorkOrderServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ScrapReasonID, 1);
		}

		[Fact]
		public async void ScrapReasonID_Update_Invalid_Reference()
		{
			Mock<IWorkOrderRepository> workOrderRepository = new Mock<IWorkOrderRepository>();
			workOrderRepository.Setup(x => x.ScrapReasonByScrapReasonID(It.IsAny<short>())).Returns(Task.FromResult<ScrapReason>(null));

			var validator = new ApiWorkOrderServerRequestModelValidator(workOrderRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiWorkOrderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ScrapReasonID, 1);
		}
	}
}

/*<Codenesium>
    <Hash>1534d30df7a0bc3b0295ab40be241c6f</Hash>
</Codenesium>*/