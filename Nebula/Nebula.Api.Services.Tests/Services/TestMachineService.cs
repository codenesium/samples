using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Machine")]
	[Trait("Area", "Services")]
	public partial class MachineServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IMachineService, IMachineRepository>();
			var records = new List<Machine>();
			records.Add(new Machine());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiMachineServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IMachineService, IMachineRepository>();
			var record = new Machine();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiMachineServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IMachineService, IMachineRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Machine>(null));
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiMachineServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IMachineService, IMachineRepository>();

			var model = new ApiMachineServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Machine>())).Returns(Task.FromResult(new Machine()));
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			CreateResponse<ApiMachineServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.MachineModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiMachineServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Machine>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<MachineCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IMachineService, IMachineRepository>();
			var model = new ApiMachineServerRequestModel();
			var validatorMock = new Mock<IApiMachineServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiMachineServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			CreateResponse<ApiMachineServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiMachineServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<MachineCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IMachineService, IMachineRepository>();
			var model = new ApiMachineServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Machine>())).Returns(Task.FromResult(new Machine()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			UpdateResponse<ApiMachineServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.MachineModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMachineServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Machine>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<MachineUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IMachineService, IMachineRepository>();
			var model = new ApiMachineServerRequestModel();
			var validatorMock = new Mock<IApiMachineServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMachineServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			UpdateResponse<ApiMachineServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMachineServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<MachineUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IMachineService, IMachineRepository>();
			var model = new ApiMachineServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.MachineModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<MachineDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IMachineService, IMachineRepository>();
			var model = new ApiMachineServerRequestModel();
			var validatorMock = new Mock<IApiMachineServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<MachineDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByMachineGuid_Exists()
		{
			var mock = new ServiceMockFacade<IMachineService, IMachineRepository>();
			var record = new Machine();
			mock.RepositoryMock.Setup(x => x.ByMachineGuid(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiMachineServerResponseModel response = await service.ByMachineGuid(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByMachineGuid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByMachineGuid_Not_Exists()
		{
			var mock = new ServiceMockFacade<IMachineService, IMachineRepository>();
			mock.RepositoryMock.Setup(x => x.ByMachineGuid(It.IsAny<Guid>())).Returns(Task.FromResult<Machine>(null));
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiMachineServerResponseModel response = await service.ByMachineGuid(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByMachineGuid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void LinksByAssignedMachineId_Exists()
		{
			var mock = new ServiceMockFacade<IMachineService, IMachineRepository>();
			var records = new List<Link>();
			records.Add(new Link());
			mock.RepositoryMock.Setup(x => x.LinksByAssignedMachineId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiLinkServerResponseModel> response = await service.LinksByAssignedMachineId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.LinksByAssignedMachineId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void LinksByAssignedMachineId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IMachineService, IMachineRepository>();
			mock.RepositoryMock.Setup(x => x.LinksByAssignedMachineId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Link>>(new List<Link>()));
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiLinkServerResponseModel> response = await service.LinksByAssignedMachineId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.LinksByAssignedMachineId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>c82e8651e23b7b469d1f0bc9fcf48b53</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/