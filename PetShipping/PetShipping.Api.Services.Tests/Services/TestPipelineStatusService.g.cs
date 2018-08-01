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
	[Trait("Table", "PipelineStatus")]
	[Trait("Area", "Services")]
	public partial class PipelineStatusServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPipelineStatusRepository>();
			var records = new List<PipelineStatus>();
			records.Add(new PipelineStatus());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineStatusService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLPipelineStatusMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineStatusMapperMock,
			                                        mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineMapperMock);

			List<ApiPipelineStatusResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPipelineStatusRepository>();
			var record = new PipelineStatus();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PipelineStatusService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLPipelineStatusMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineStatusMapperMock,
			                                        mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineMapperMock);

			ApiPipelineStatusResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPipelineStatusRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PipelineStatus>(null));
			var service = new PipelineStatusService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLPipelineStatusMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineStatusMapperMock,
			                                        mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineMapperMock);

			ApiPipelineStatusResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IPipelineStatusRepository>();
			var model = new ApiPipelineStatusRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStatus>())).Returns(Task.FromResult(new PipelineStatus()));
			var service = new PipelineStatusService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLPipelineStatusMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineStatusMapperMock,
			                                        mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineMapperMock);

			CreateResponse<ApiPipelineStatusResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStatusRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PipelineStatus>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IPipelineStatusRepository>();
			var model = new ApiPipelineStatusRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStatus>())).Returns(Task.FromResult(new PipelineStatus()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStatus()));
			var service = new PipelineStatusService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLPipelineStatusMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineStatusMapperMock,
			                                        mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineMapperMock);

			UpdateResponse<ApiPipelineStatusResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStatusRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PipelineStatus>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IPipelineStatusRepository>();
			var model = new ApiPipelineStatusRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PipelineStatusService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLPipelineStatusMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineStatusMapperMock,
			                                        mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Pipelines_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStatusRepository>();
			var records = new List<Pipeline>();
			records.Add(new Pipeline());
			mock.RepositoryMock.Setup(x => x.Pipelines(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineStatusService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLPipelineStatusMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineStatusMapperMock,
			                                        mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineMapperMock);

			List<ApiPipelineResponseModel> response = await service.Pipelines(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Pipelines(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Pipelines_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStatusRepository>();
			mock.RepositoryMock.Setup(x => x.Pipelines(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Pipeline>>(new List<Pipeline>()));
			var service = new PipelineStatusService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLPipelineStatusMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineStatusMapperMock,
			                                        mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineMapperMock);

			List<ApiPipelineResponseModel> response = await service.Pipelines(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Pipelines(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>91bb5853d551a003faaef32e15287bed</Hash>
</Codenesium>*/