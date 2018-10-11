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

		// table.Columns[i].GetReferenceTable().AppTableName= Client
		[Fact]
		public async void ClientId_Create_Valid_Reference()
		{
			Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
			clientCommunicationRepository.Setup(x => x.ClientByClientId(It.IsAny<int>())).Returns(Task.FromResult<Client>(new Client()));

			var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);
			await validator.ValidateCreateAsync(new ApiClientCommunicationRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ClientId, 1);
		}

		[Fact]
		public async void ClientId_Create_Invalid_Reference()
		{
			Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
			clientCommunicationRepository.Setup(x => x.ClientByClientId(It.IsAny<int>())).Returns(Task.FromResult<Client>(null));

			var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);

			await validator.ValidateCreateAsync(new ApiClientCommunicationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ClientId, 1);
		}

		[Fact]
		public async void ClientId_Update_Valid_Reference()
		{
			Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
			clientCommunicationRepository.Setup(x => x.ClientByClientId(It.IsAny<int>())).Returns(Task.FromResult<Client>(new Client()));

			var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiClientCommunicationRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ClientId, 1);
		}

		[Fact]
		public async void ClientId_Update_Invalid_Reference()
		{
			Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
			clientCommunicationRepository.Setup(x => x.ClientByClientId(It.IsAny<int>())).Returns(Task.FromResult<Client>(null));

			var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiClientCommunicationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ClientId, 1);
		}

		// table.Columns[i].GetReferenceTable().AppTableName= Employee
		[Fact]
		public async void EmployeeId_Create_Valid_Reference()
		{
			Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
			clientCommunicationRepository.Setup(x => x.EmployeeByEmployeeId(It.IsAny<int>())).Returns(Task.FromResult<Employee>(new Employee()));

			var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);
			await validator.ValidateCreateAsync(new ApiClientCommunicationRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeId, 1);
		}

		[Fact]
		public async void EmployeeId_Create_Invalid_Reference()
		{
			Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
			clientCommunicationRepository.Setup(x => x.EmployeeByEmployeeId(It.IsAny<int>())).Returns(Task.FromResult<Employee>(null));

			var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);

			await validator.ValidateCreateAsync(new ApiClientCommunicationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EmployeeId, 1);
		}

		[Fact]
		public async void EmployeeId_Update_Valid_Reference()
		{
			Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
			clientCommunicationRepository.Setup(x => x.EmployeeByEmployeeId(It.IsAny<int>())).Returns(Task.FromResult<Employee>(new Employee()));

			var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiClientCommunicationRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeId, 1);
		}

		[Fact]
		public async void EmployeeId_Update_Invalid_Reference()
		{
			Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
			clientCommunicationRepository.Setup(x => x.EmployeeByEmployeeId(It.IsAny<int>())).Returns(Task.FromResult<Employee>(null));

			var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiClientCommunicationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EmployeeId, 1);
		}

		[Fact]
		public async void Note_Create_null()
		{
			Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
			clientCommunicationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ClientCommunication()));

			var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);
			await validator.ValidateCreateAsync(new ApiClientCommunicationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Note, null as string);
		}

		[Fact]
		public async void Note_Update_null()
		{
			Mock<IClientCommunicationRepository> clientCommunicationRepository = new Mock<IClientCommunicationRepository>();
			clientCommunicationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ClientCommunication()));

			var validator = new ApiClientCommunicationRequestModelValidator(clientCommunicationRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiClientCommunicationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Note, null as string);
		}
	}
}

/*<Codenesium>
    <Hash>385c2aead0129766fad7d488fe83b068</Hash>
</Codenesium>*/