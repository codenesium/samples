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
	[Trait("Table", "HandlerPipelineStep")]
	[Trait("Area", "Services")]
	public partial class HandlerPipelineStepServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IHandlerPipelineStepRepository>();
			var records = new List<HandlerPipelineStep>();
			records.Add(new HandlerPipelineStep());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new HandlerPipelineStepService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
			                                             mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock);

			List<ApiHandlerPipelineStepServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IHandlerPipelineStepRepository>();
			var record = new HandlerPipelineStep();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new HandlerPipelineStepService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
			                                             mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock);

			ApiHandlerPipelineStepServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IHandlerPipelineStepRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<HandlerPipelineStep>(null));
			var service = new HandlerPipelineStepService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
			                                             mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock);

			ApiHandlerPipelineStepServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IHandlerPipelineStepRepository>();
			var model = new ApiHandlerPipelineStepServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<HandlerPipelineStep>())).Returns(Task.FromResult(new HandlerPipelineStep()));
			var service = new HandlerPipelineStepService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
			                                             mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock);

			CreateResponse<ApiHandlerPipelineStepServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiHandlerPipelineStepServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<HandlerPipelineStep>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IHandlerPipelineStepRepository>();
			var model = new ApiHandlerPipelineStepServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<HandlerPipelineStep>())).Returns(Task.FromResult(new HandlerPipelineStep()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new HandlerPipelineStep()));
			var service = new HandlerPipelineStepService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
			                                             mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock);

			UpdateResponse<ApiHandlerPipelineStepServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiHandlerPipelineStepServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<HandlerPipelineStep>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IHandlerPipelineStepRepository>();
			var model = new ApiHandlerPipelineStepServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new HandlerPipelineStepService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
			                                             mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>f95b04030e0dffd26b33a6b1b1ee8861</Hash>
</Codenesium>*/