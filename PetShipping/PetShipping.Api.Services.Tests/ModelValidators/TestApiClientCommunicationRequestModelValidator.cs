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
	[Trait("Table", "ClientCommunication")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiClientCommunicationRequestModelValidatorTest
	{
		public ApiClientCommunicationRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void ClientId_Create_Valid_Reference()
		{
			Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
			clientCommunicationRepository.Setup(x => x.GetClient(It.IsAny<int>())).Returns(Task.FromResult<Client>(new Client()));

			var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);
			await validator.ValidateCreateAsync(new ApiClientCommunicationRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ClientId, 1);
		}

		[Fact]
		public async void ClientId_Create_Invalid_Reference()
		{
			Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
			clientCommunicationRepository.Setup(x => x.GetClient(It.IsAny<int>())).Returns(Task.FromResult<Client>(null));

			var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);

			await validator.ValidateCreateAsync(new ApiClientCommunicationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ClientId, 1);
		}

		[Fact]
		public async void ClientId_Update_Valid_Reference()
		{
			Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
			clientCommunicationRepository.Setup(x => x.GetClient(It.IsAny<int>())).Returns(Task.FromResult<Client>(new Client()));

			var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiClientCommunicationRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ClientId, 1);
		}

		[Fact]
		public async void ClientId_Update_Invalid_Reference()
		{
			Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
			clientCommunicationRepository.Setup(x => x.GetClient(It.IsAny<int>())).Returns(Task.FromResult<Client>(null));

			var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiClientCommunicationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ClientId, 1);
		}

		[Fact]
		public async void EmployeeId_Create_Valid_Reference()
		{
			Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
			clientCommunicationRepository.Setup(x => x.GetEmployee(It.IsAny<int>())).Returns(Task.FromResult<Employee>(new Employee()));

			var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);
			await validator.ValidateCreateAsync(new ApiClientCommunicationRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeId, 1);
		}

		[Fact]
		public async void EmployeeId_Create_Invalid_Reference()
		{
			Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
			clientCommunicationRepository.Setup(x => x.GetEmployee(It.IsAny<int>())).Returns(Task.FromResult<Employee>(null));

			var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);

			await validator.ValidateCreateAsync(new ApiClientCommunicationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EmployeeId, 1);
		}

		[Fact]
		public async void EmployeeId_Update_Valid_Reference()
		{
			Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
			clientCommunicationRepository.Setup(x => x.GetEmployee(It.IsAny<int>())).Returns(Task.FromResult<Employee>(new Employee()));

			var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiClientCommunicationRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeId, 1);
		}

		[Fact]
		public async void EmployeeId_Update_Invalid_Reference()
		{
			Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
			clientCommunicationRepository.Setup(x => x.GetEmployee(It.IsAny<int>())).Returns(Task.FromResult<Employee>(null));

			var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiClientCommunicationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EmployeeId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>8003c0ecc73f78be034ee21f8995e789</Hash>
</Codenesium>*/