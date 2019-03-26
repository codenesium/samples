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
	[Trait("Table", "ShipMethod")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiShipMethodServerRequestModelValidatorTest
	{
		public ApiShipMethodServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IShipMethodRepository> shipMethodRepository = new Mock<IShipMethodRepository>();
			shipMethodRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ShipMethod()));

			var validator = new ApiShipMethodServerRequestModelValidator(shipMethodRepository.Object);
			await validator.ValidateCreateAsync(new ApiShipMethodServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IShipMethodRepository> shipMethodRepository = new Mock<IShipMethodRepository>();
			shipMethodRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ShipMethod()));

			var validator = new ApiShipMethodServerRequestModelValidator(shipMethodRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiShipMethodServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IShipMethodRepository> shipMethodRepository = new Mock<IShipMethodRepository>();
			shipMethodRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ShipMethod()));

			var validator = new ApiShipMethodServerRequestModelValidator(shipMethodRepository.Object);
			await validator.ValidateCreateAsync(new ApiShipMethodServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IShipMethodRepository> shipMethodRepository = new Mock<IShipMethodRepository>();
			shipMethodRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ShipMethod()));

			var validator = new ApiShipMethodServerRequestModelValidator(shipMethodRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiShipMethodServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<IShipMethodRepository> shipMethodRepository = new Mock<IShipMethodRepository>();
			shipMethodRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ShipMethod>(new ShipMethod()));
			var validator = new ApiShipMethodServerRequestModelValidator(shipMethodRepository.Object);

			await validator.ValidateCreateAsync(new ApiShipMethodServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<IShipMethodRepository> shipMethodRepository = new Mock<IShipMethodRepository>();
			shipMethodRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ShipMethod>(null));
			var validator = new ApiShipMethodServerRequestModelValidator(shipMethodRepository.Object);

			await validator.ValidateCreateAsync(new ApiShipMethodServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<IShipMethodRepository> shipMethodRepository = new Mock<IShipMethodRepository>();
			shipMethodRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ShipMethod>(new ShipMethod()));
			var validator = new ApiShipMethodServerRequestModelValidator(shipMethodRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiShipMethodServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<IShipMethodRepository> shipMethodRepository = new Mock<IShipMethodRepository>();
			shipMethodRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ShipMethod>(null));
			var validator = new ApiShipMethodServerRequestModelValidator(shipMethodRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiShipMethodServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>4c98c21a660a8b9de56d72c85ee1be08</Hash>
</Codenesium>*/