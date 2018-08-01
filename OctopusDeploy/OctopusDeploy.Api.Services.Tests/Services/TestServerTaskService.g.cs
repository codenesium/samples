using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ServerTask")]
	[Trait("Area", "Services")]
	public partial class ServerTaskServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IServerTaskRepository>();
			var records = new List<ServerTask>();
			records.Add(new ServerTask());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ServerTaskService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
			                                    mock.DALMapperMockFactory.DALServerTaskMapperMock);

			List<ApiServerTaskResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IServerTaskRepository>();
			var record = new ServerTask();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ServerTaskService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
			                                    mock.DALMapperMockFactory.DALServerTaskMapperMock);

			ApiServerTaskResponseModel response = await service.Get(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IServerTaskRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ServerTask>(null));
			var service = new ServerTaskService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
			                                    mock.DALMapperMockFactory.DALServerTaskMapperMock);

			ApiServerTaskResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IServerTaskRepository>();
			var model = new ApiServerTaskRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ServerTask>())).Returns(Task.FromResult(new ServerTask()));
			var service = new ServerTaskService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
			                                    mock.DALMapperMockFactory.DALServerTaskMapperMock);

			CreateResponse<ApiServerTaskResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiServerTaskRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ServerTask>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IServerTaskRepository>();
			var model = new ApiServerTaskRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ServerTask>())).Returns(Task.FromResult(new ServerTask()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ServerTask()));
			var service = new ServerTaskService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
			                                    mock.DALMapperMockFactory.DALServerTaskMapperMock);

			UpdateResponse<ApiServerTaskResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiServerTaskRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ServerTask>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IServerTaskRepository>();
			var model = new ApiServerTaskRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
			var service = new ServerTaskService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
			                                    mock.DALMapperMockFactory.DALServerTaskMapperMock);

			ActionResponse response = await service.Delete(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
			mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
		}

		[Fact]
		public async void ByDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId_Exists()
		{
			var mock = new ServiceMockFacade<IServerTaskRepository>();
			var records = new List<ServerTask>();
			records.Add(new ServerTask());
			mock.RepositoryMock.Setup(x => x.ByDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset?>(), It.IsAny<DateTimeOffset?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new ServerTaskService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
			                                    mock.DALMapperMockFactory.DALServerTaskMapperMock);

			List<ApiServerTaskResponseModel> response = await service.ByDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(default(string), default(DateTimeOffset), default(DateTimeOffset ?), default(DateTimeOffset ?), default(string), default(string), default(bool), default(bool), default(int), default(string), default(string), default(string), default(string), default(string), default(string), default(string));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset?>(), It.IsAny<DateTimeOffset?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ByDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IServerTaskRepository>();
			mock.RepositoryMock.Setup(x => x.ByDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset?>(), It.IsAny<DateTimeOffset?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<List<ServerTask>>(new List<ServerTask>()));
			var service = new ServerTaskService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
			                                    mock.DALMapperMockFactory.DALServerTaskMapperMock);

			List<ApiServerTaskResponseModel> response = await service.ByDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(default(string), default(DateTimeOffset), default(DateTimeOffset ?), default(DateTimeOffset ?), default(string), default(string), default(bool), default(bool), default(int), default(string), default(string), default(string), default(string), default(string), default(string), default(string));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset?>(), It.IsAny<DateTimeOffset?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ByStateConcurrencyTag_Exists()
		{
			var mock = new ServiceMockFacade<IServerTaskRepository>();
			var records = new List<ServerTask>();
			records.Add(new ServerTask());
			mock.RepositoryMock.Setup(x => x.ByStateConcurrencyTag(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new ServerTaskService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
			                                    mock.DALMapperMockFactory.DALServerTaskMapperMock);

			List<ApiServerTaskResponseModel> response = await service.ByStateConcurrencyTag(default(string), default(string));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByStateConcurrencyTag(It.IsAny<string>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ByStateConcurrencyTag_Not_Exists()
		{
			var mock = new ServiceMockFacade<IServerTaskRepository>();
			mock.RepositoryMock.Setup(x => x.ByStateConcurrencyTag(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<List<ServerTask>>(new List<ServerTask>()));
			var service = new ServerTaskService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
			                                    mock.DALMapperMockFactory.DALServerTaskMapperMock);

			List<ApiServerTaskResponseModel> response = await service.ByStateConcurrencyTag(default(string), default(string));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByStateConcurrencyTag(It.IsAny<string>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ByNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId_Exists()
		{
			var mock = new ServiceMockFacade<IServerTaskRepository>();
			var records = new List<ServerTask>();
			records.Add(new ServerTask());
			mock.RepositoryMock.Setup(x => x.ByNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset?>(), It.IsAny<DateTimeOffset?>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new ServerTaskService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
			                                    mock.DALMapperMockFactory.DALServerTaskMapperMock);

			List<ApiServerTaskResponseModel> response = await service.ByNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(default(string), default(string), default(DateTimeOffset ?), default(DateTimeOffset ?), default(string), default(bool), default(string), default(string), default(string), default(int), default(string), default(DateTimeOffset), default(string), default(string), default(bool), default(string));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset?>(), It.IsAny<DateTimeOffset?>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ByNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IServerTaskRepository>();
			mock.RepositoryMock.Setup(x => x.ByNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset?>(), It.IsAny<DateTimeOffset?>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>())).Returns(Task.FromResult<List<ServerTask>>(new List<ServerTask>()));
			var service = new ServerTaskService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ServerTaskModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLServerTaskMapperMock,
			                                    mock.DALMapperMockFactory.DALServerTaskMapperMock);

			List<ApiServerTaskResponseModel> response = await service.ByNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(default(string), default(string), default(DateTimeOffset ?), default(DateTimeOffset ?), default(string), default(bool), default(string), default(string), default(string), default(int), default(string), default(DateTimeOffset), default(string), default(string), default(bool), default(string));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset?>(), It.IsAny<DateTimeOffset?>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>8303f80383d58b245b33c99c82d6b2ca</Hash>
</Codenesium>*/