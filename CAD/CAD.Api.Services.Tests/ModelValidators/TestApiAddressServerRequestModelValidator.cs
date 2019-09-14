using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
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

namespace CADNS.Api.Services.Tests
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
		public async void Address1_Create_null()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateCreateAsync(new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address1, null as string);
		}

		[Fact]
		public async void Address1_Update_null()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address1, null as string);
		}

		[Fact]
		public async void Address1_Create_length()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateCreateAsync(new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address1, new string('A', 129));
		}

		[Fact]
		public async void Address1_Update_length()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address1, new string('A', 129));
		}

		[Fact]
		public async void Address2_Create_length()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateCreateAsync(new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address2, new string('A', 129));
		}

		[Fact]
		public async void Address2_Update_length()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address2, new string('A', 129));
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

			validator.ShouldHaveValidationErrorFor(x => x.City, new string('A', 129));
		}

		[Fact]
		public async void City_Update_length()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.City, new string('A', 129));
		}

		[Fact]
		public async void State_Create_null()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateCreateAsync(new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.State, null as string);
		}

		[Fact]
		public async void State_Update_null()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.State, null as string);
		}

		[Fact]
		public async void State_Create_length()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateCreateAsync(new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.State, new string('A', 3));
		}

		[Fact]
		public async void State_Update_length()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.State, new string('A', 3));
		}

		[Fact]
		public async void Zip_Create_length()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateCreateAsync(new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Zip, new string('A', 13));
		}

		[Fact]
		public async void Zip_Update_length()
		{
			Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
			addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

			var validator = new ApiAddressServerRequestModelValidator(addressRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAddressServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Zip, new string('A', 13));
		}
	}
}

/*<Codenesium>
    <Hash>2c357c3625411d41b113478f61f18098</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/