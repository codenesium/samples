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
	[Trait("Table", "PurchaseOrderHeader")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPurchaseOrderHeaderServerRequestModelValidatorTest
	{
		public ApiPurchaseOrderHeaderServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void ShipMethodID_Create_Valid_Reference()
		{
			Mock<IPurchaseOrderHeaderRepository> purchaseOrderHeaderRepository = new Mock<IPurchaseOrderHeaderRepository>();
			purchaseOrderHeaderRepository.Setup(x => x.ShipMethodByShipMethodID(It.IsAny<int>())).Returns(Task.FromResult<ShipMethod>(new ShipMethod()));

			var validator = new ApiPurchaseOrderHeaderServerRequestModelValidator(purchaseOrderHeaderRepository.Object);
			await validator.ValidateCreateAsync(new ApiPurchaseOrderHeaderServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ShipMethodID, 1);
		}

		[Fact]
		public async void ShipMethodID_Create_Invalid_Reference()
		{
			Mock<IPurchaseOrderHeaderRepository> purchaseOrderHeaderRepository = new Mock<IPurchaseOrderHeaderRepository>();
			purchaseOrderHeaderRepository.Setup(x => x.ShipMethodByShipMethodID(It.IsAny<int>())).Returns(Task.FromResult<ShipMethod>(null));

			var validator = new ApiPurchaseOrderHeaderServerRequestModelValidator(purchaseOrderHeaderRepository.Object);

			await validator.ValidateCreateAsync(new ApiPurchaseOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ShipMethodID, 1);
		}

		[Fact]
		public async void ShipMethodID_Update_Valid_Reference()
		{
			Mock<IPurchaseOrderHeaderRepository> purchaseOrderHeaderRepository = new Mock<IPurchaseOrderHeaderRepository>();
			purchaseOrderHeaderRepository.Setup(x => x.ShipMethodByShipMethodID(It.IsAny<int>())).Returns(Task.FromResult<ShipMethod>(new ShipMethod()));

			var validator = new ApiPurchaseOrderHeaderServerRequestModelValidator(purchaseOrderHeaderRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPurchaseOrderHeaderServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ShipMethodID, 1);
		}

		[Fact]
		public async void ShipMethodID_Update_Invalid_Reference()
		{
			Mock<IPurchaseOrderHeaderRepository> purchaseOrderHeaderRepository = new Mock<IPurchaseOrderHeaderRepository>();
			purchaseOrderHeaderRepository.Setup(x => x.ShipMethodByShipMethodID(It.IsAny<int>())).Returns(Task.FromResult<ShipMethod>(null));

			var validator = new ApiPurchaseOrderHeaderServerRequestModelValidator(purchaseOrderHeaderRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPurchaseOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ShipMethodID, 1);
		}

		[Fact]
		public async void VendorID_Create_Valid_Reference()
		{
			Mock<IPurchaseOrderHeaderRepository> purchaseOrderHeaderRepository = new Mock<IPurchaseOrderHeaderRepository>();
			purchaseOrderHeaderRepository.Setup(x => x.VendorByVendorID(It.IsAny<int>())).Returns(Task.FromResult<Vendor>(new Vendor()));

			var validator = new ApiPurchaseOrderHeaderServerRequestModelValidator(purchaseOrderHeaderRepository.Object);
			await validator.ValidateCreateAsync(new ApiPurchaseOrderHeaderServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.VendorID, 1);
		}

		[Fact]
		public async void VendorID_Create_Invalid_Reference()
		{
			Mock<IPurchaseOrderHeaderRepository> purchaseOrderHeaderRepository = new Mock<IPurchaseOrderHeaderRepository>();
			purchaseOrderHeaderRepository.Setup(x => x.VendorByVendorID(It.IsAny<int>())).Returns(Task.FromResult<Vendor>(null));

			var validator = new ApiPurchaseOrderHeaderServerRequestModelValidator(purchaseOrderHeaderRepository.Object);

			await validator.ValidateCreateAsync(new ApiPurchaseOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.VendorID, 1);
		}

		[Fact]
		public async void VendorID_Update_Valid_Reference()
		{
			Mock<IPurchaseOrderHeaderRepository> purchaseOrderHeaderRepository = new Mock<IPurchaseOrderHeaderRepository>();
			purchaseOrderHeaderRepository.Setup(x => x.VendorByVendorID(It.IsAny<int>())).Returns(Task.FromResult<Vendor>(new Vendor()));

			var validator = new ApiPurchaseOrderHeaderServerRequestModelValidator(purchaseOrderHeaderRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPurchaseOrderHeaderServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.VendorID, 1);
		}

		[Fact]
		public async void VendorID_Update_Invalid_Reference()
		{
			Mock<IPurchaseOrderHeaderRepository> purchaseOrderHeaderRepository = new Mock<IPurchaseOrderHeaderRepository>();
			purchaseOrderHeaderRepository.Setup(x => x.VendorByVendorID(It.IsAny<int>())).Returns(Task.FromResult<Vendor>(null));

			var validator = new ApiPurchaseOrderHeaderServerRequestModelValidator(purchaseOrderHeaderRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPurchaseOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.VendorID, 1);
		}
	}
}

/*<Codenesium>
    <Hash>44939790400475ccb6b89ee12fe6dbe4</Hash>
</Codenesium>*/