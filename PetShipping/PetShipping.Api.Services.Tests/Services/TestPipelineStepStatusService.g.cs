using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepStatus")]
	[Trait("Area", "Services")]
	public partial class PipelineStepStatusServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatusRepository>();
			var records = new List<PipelineStepStatus>();
			records.Add(new PipelineStepStatus());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineStepStatusService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLPipelineStepStatusMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepStatusMapperMock,
			                                            mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			List<ApiPipelineStepStatusResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatusRepository>();
			var record = new PipelineStepStatus();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PipelineStepStatusService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLPipelineStepStatusMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepStatusMapperMock,
			                                            mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			ApiPipelineStepStatusResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatusRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PipelineStepStatus>(null));
			var service = new PipelineStepStatusService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLPipelineStepStatusMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepStatusMapperMock,
			                                            mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			ApiPipelineStepStatusResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatusRepository>();
			var model = new ApiPipelineStepStatusRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStepStatus>())).Returns(Task.FromResult(new PipelineStepStatus()));
			var service = new PipelineStepStatusService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLPipelineStepStatusMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepStatusMapperMock,
			                                            mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			CreateResponse<ApiPipelineStepStatusResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepStatusRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PipelineStepStatus>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatusRepository>();
			var model = new ApiPipelineStepStatusRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStepStatus>())).Returns(Task.FromResult(new PipelineStepStatus()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStatus()));
			var service = new PipelineStepStatusService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLPipelineStepStatusMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepStatusMapperMock,
			                                            mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			UpdateResponse<ApiPipelineStepStatusResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepStatusRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PipelineStepStatus>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatusRepository>();
			var model = new ApiPipelineStepStatusRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PipelineStepStatusService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLPipelineStepStatusMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepStatusMapperMock,
			                                            mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineSteps_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatusRepository>();
			var records = new List<PipelineStep>();
			records.Add(new PipelineStep());
			mock.RepositoryMock.Setup(x => x.PipelineSteps(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineStepStatusService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLPipelineStepStatusMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepStatusMapperMock,
			                                            mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			List<ApiPipelineStepResponseModel> response = await service.PipelineSteps(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineSteps(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineSteps_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatusRepository>();
			mock.RepositoryMock.Setup(x => x.PipelineSteps(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PipelineStep>>(new List<PipelineStep>()));
			var service = new PipelineStepStatusService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLPipelineStepStatusMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepStatusMapperMock,
			                                            mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			List<ApiPipelineStepResponseModel> response = await service.PipelineSteps(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineSteps(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>844ab6c121d9d54480a274ac57401c7b</Hash>
</Codenesium>*/