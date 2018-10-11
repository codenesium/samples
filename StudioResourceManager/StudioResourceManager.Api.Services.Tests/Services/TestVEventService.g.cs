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
	}
}

/*<Codenesium>
    <Hash>5650afa2de4ceb92d8cabb299b174cab</Hash>
</Codenesium>*/