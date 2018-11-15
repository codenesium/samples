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
	[Trait("Table", "Address")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiAddressServerRequestModelValidatorTest
	{
		public ApiAddressServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void AddressLine1_Create_null()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateCreateAsync(new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AddressLine1, null as string);
		}

		[Fact]
		public async void AddressLine1_Update_null()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AddressLine1, null as string);
		}

		[Fact]
		public async void AddressLine1_Create_length()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateCreateAsync(new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AddressLine1, new string('A', 61));
		}

		[Fact]
		public async void AddressLine1_Update_length()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AddressLine1, new string('A', 61));
		}

		[Fact]
		public async void AddressLine2_Create_length()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateCreateAsync(new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AddressLine2, new string('A', 61));
		}

		[Fact]
		public async void AddressLine2_Update_length()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AddressLine2, new string('A', 61));
		}

		[Fact]
		public async void City_Create_null()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateCreateAsync(new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.City, null as string);
		}

		[Fact]
		public async void City_Update_null()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.City, null as string);
		}

		[Fact]
		public async void City_Create_length()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateCreateAsync(new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.City, new string('A', 31));
		}

		[Fact]
		public async void City_Update_length()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.City, new string('A', 31));
		}

		[Fact]
		public async void PostalCode_Create_null()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateCreateAsync(new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostalCode, null as string);
		}

		[Fact]
		public async void PostalCode_Update_null()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostalCode, null as string);
		}

		[Fact]
		public async void PostalCode_Create_length()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateCreateAsync(new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostalCode, new string('A', 16));
		}

		[Fact]
		public async void PostalCode_Update_length()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostalCode, new string('A', 16));
		}

		[Fact]
		private async void BeUniqueByAddressLine1AddressLine2CityStateProvinceIDPostalCode_Create_Exists()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<Address>(new Address()));
			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);

			await validator.ValidateCreateAsync(new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AddressLine1, "A");
		}

		[Fact]
		private async void BeUniqueByAddressLine1AddressLine2CityStateProvinceIDPostalCode_Create_Not_Exists()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<Address>(null));
			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);

			await validator.ValidateCreateAsync(new ApiAddressServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.AddressLine1, "A");
		}

		[Fact]
		private async void BeUniqueByAddressLine1AddressLine2CityStateProvinceIDPostalCode_Update_Exists()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<Address>(new Address()));
			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AddressLine1, "A");
		}

		[Fact]
		private async void BeUniqueByAddressLine1AddressLine2CityStateProvinceIDPostalCode_Update_Not_Exists()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<Address>(null));
			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiAddressServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.AddressLine1, "A");
		}
	}
}

/*<Codenesium>
    <Hash>68eb5786d857b7d529bd7e62e4c1a619</Hash>
</Codenesium>*/