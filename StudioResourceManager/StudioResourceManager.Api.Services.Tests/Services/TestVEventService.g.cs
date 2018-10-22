using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VEvent")]
	[Trait("Area", "Services")]
	public partial class VEventServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IVEventRepository>();
			var records = new List<VEvent>();
			records.Add(new VEvent());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VEventService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.VEventModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLVEventMapperMock,
			                                mock.DALMapperMockFactory.DALVEventMapperMock);

			List<ApiVEventResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IVEventRepository>();
			var record = new VEvent();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VEventService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.VEventModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLVEventMapperMock,
			                                mock.DALMapperMockFactory.DALVEventMapperMock);

			ApiVEventResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IVEventRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<VEvent>(null));
			var service = new VEventService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.VEventModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLVEventMapperMock,
			                                mock.DALMapperMockFactory.DALVEventMapperMock);

			ApiVEventResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IVEventRepository>();
			var model = new ApiVEventRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VEvent>())).Returns(Task.FromResult(new VEvent()));
			var service = new VEventService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.VEventModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLVEventMapperMock,
			                                mock.DALMapperMockFactory.DALVEventMapperMock);

			CreateResponse<ApiVEventResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.VEventModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVEventRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<VEvent>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IVEventRepository>();
			var model = new ApiVEventRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VEvent>())).Returns(Task.FromResult(new VEvent()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VEvent()));
			var service = new VEventService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.VEventModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLVEventMapperMock,
			                                mock.DALMapperMockFactory.DALVEventMapperMock);

			UpdateResponse<ApiVEventResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.VEventModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVEventRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<VEvent>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IVEventRepository>();
			var model = new ApiVEventRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VEventService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.VEventModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLVEventMapperMock,
			                                mock.DALMapperMockFactory.DALVEventMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VEventModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>8f27769f70a1f7b9130e00cab81a7ca4</Hash>
</Codenesium>*/