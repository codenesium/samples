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
	[Trait("Table", "PipelineStepStatu")]
	[Trait("Area", "Services")]
	public partial class PipelineStepStatuServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatuRepository>();
			var records = new List<PipelineStepStatu>();
			records.Add(new PipelineStepStatu());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineStepStatuService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLPipelineStepStatuMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepStatuMapperMock,
			                                           mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			List<ApiPipelineStepStatuResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatuRepository>();
			var record = new PipelineStepStatu();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PipelineStepStatuService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLPipelineStepStatuMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepStatuMapperMock,
			                                           mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			ApiPipelineStepStatuResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatuRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PipelineStepStatu>(null));
			var service = new PipelineStepStatuService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLPipelineStepStatuMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepStatuMapperMock,
			                                           mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			ApiPipelineStepStatuResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatuRepository>();
			var model = new ApiPipelineStepStatuRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStepStatu>())).Returns(Task.FromResult(new PipelineStepStatu()));
			var service = new PipelineStepStatuService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLPipelineStepStatuMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepStatuMapperMock,
			                                           mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			CreateResponse<ApiPipelineStepStatuResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepStatuRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PipelineStepStatu>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatuRepository>();
			var model = new ApiPipelineStepStatuRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStepStatu>())).Returns(Task.FromResult(new PipelineStepStatu()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStatu()));
			var service = new PipelineStepStatuService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLPipelineStepStatuMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepStatuMapperMock,
			                                           mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			UpdateResponse<ApiPipelineStepStatuResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepStatuRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PipelineStepStatu>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatuRepository>();
			var model = new ApiPipelineStepStatuRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PipelineStepStatuService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLPipelineStepStatuMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepStatuMapperMock,
			                                           mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineSteps_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatuRepository>();
			var records = new List<PipelineStep>();
			records.Add(new PipelineStep());
			mock.RepositoryMock.Setup(x => x.PipelineSteps(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineStepStatuService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLPipelineStepStatuMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepStatuMapperMock,
			                                           mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			List<ApiPipelineStepResponseModel> response = await service.PipelineSteps(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineSteps(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineSteps_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatuRepository>();
			mock.RepositoryMock.Setup(x => x.PipelineSteps(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PipelineStep>>(new List<PipelineStep>()));
			var service = new PipelineStepStatuService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLPipelineStepStatuMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepStatuMapperMock,
			                                           mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			List<ApiPipelineStepResponseModel> response = await service.PipelineSteps(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineSteps(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>8a0697b64a505a809e0113e812c9d3f6</Hash>
</Codenesium>*/