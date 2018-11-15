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
	[Trait("Table", "Client")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiClientServerRequestModelValidatorTest
	{
		public ApiClientServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Email_Create_null()
		{
			Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
			clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

			var validator = new ApiClientServerRequestModelValidator(clientRepository.Object);
			await validator.ValidateCreateAsync(new ApiClientServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Update_null()
		{
			Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
			clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

			var validator = new ApiClientServerRequestModelValidator(clientRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiClientServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Create_length()
		{
			Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
			clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

			var validator = new ApiClientServerRequestModelValidator(clientRepository.Object);
			await validator.ValidateCreateAsync(new ApiClientServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void Email_Update_length()
		{
			Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
			clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

			var validator = new ApiClientServerRequestModelValidator(clientRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiClientServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Create_null()
		{
			Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
			clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

			var validator = new ApiClientServerRequestModelValidator(clientRepository.Object);
			await validator.ValidateCreateAsync(new ApiClientServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
		}

		[Fact]
		public async void FirstName_Update_null()
		{
			Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
			clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

			var validator = new ApiClientServerRequestModelValidator(clientRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiClientServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
		}

		[Fact]
		public async void FirstName_Create_length()
		{
			Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
			clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

			var validator = new ApiClientServerRequestModelValidator(clientRepository.Object);
			await validator.ValidateCreateAsync(new ApiClientServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Update_length()
		{
			Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
			clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

			var validator = new ApiClientServerRequestModelValidator(clientRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiClientServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Create_null()
		{
			Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
			clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

			var validator = new ApiClientServerRequestModelValidator(clientRepository.Object);
			await validator.ValidateCreateAsync(new ApiClientServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
		}

		[Fact]
		public async void LastName_Update_null()
		{
			Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
			clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

			var validator = new ApiClientServerRequestModelValidator(clientRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiClientServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
		}

		[Fact]
		public async void LastName_Create_length()
		{
			Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
			clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

			var validator = new ApiClientServerRequestModelValidator(clientRepository.Object);
			await validator.ValidateCreateAsync(new ApiClientServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Update_length()
		{
			Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
			clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

			var validator = new ApiClientServerRequestModelValidator(clientRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiClientServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void Phone_Create_null()
		{
			Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
			clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

			var validator = new ApiClientServerRequestModelValidator(clientRepository.Object);
			await validator.ValidateCreateAsync(new ApiClientServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
		}

		[Fact]
		public async void Phone_Update_null()
		{
			Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
			clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

			var validator = new ApiClientServerRequestModelValidator(clientRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiClientServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
		}

		[Fact]
		public async void Phone_Create_length()
		{
			Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
			clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

			var validator = new ApiClientServerRequestModelValidator(clientRepository.Object);
			await validator.ValidateCreateAsync(new ApiClientServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 11));
		}

		[Fact]
		public async void Phone_Update_length()
		{
			Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
			clientRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Client()));

			var validator = new ApiClientServerRequestModelValidator(clientRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiClientServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 11));
		}
	}
}

/*<Codenesium>
    <Hash>c44d7e625701703d55fe2354748a6d3b</Hash>
</Codenesium>*/