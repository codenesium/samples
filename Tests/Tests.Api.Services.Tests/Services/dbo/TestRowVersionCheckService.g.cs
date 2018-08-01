using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "RowVersionCheck")]
	[Trait("Area", "Services")]
	public partial class RowVersionCheckServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IRowVersionCheckRepository>();
			var records = new List<RowVersionCheck>();
			records.Add(new RowVersionCheck());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new RowVersionCheckService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.RowVersionCheckModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLRowVersionCheckMapperMock,
			                                         mock.DALMapperMockFactory.DALRowVersionCheckMapperMock);

			List<ApiRowVersionCheckResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IRowVersionCheckRepository>();
			var record = new RowVersionCheck();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new RowVersionCheckService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.RowVersionCheckModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLRowVersionCheckMapperMock,
			                                         mock.DALMapperMockFactory.DALRowVersionCheckMapperMock);

			ApiRowVersionCheckResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IRowVersionCheckRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<RowVersionCheck>(null));
			var service = new RowVersionCheckService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.RowVersionCheckModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLRowVersionCheckMapperMock,
			                                         mock.DALMapperMockFactory.DALRowVersionCheckMapperMock);

			ApiRowVersionCheckResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IRowVersionCheckRepository>();
			var model = new ApiRowVersionCheckRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<RowVersionCheck>())).Returns(Task.FromResult(new RowVersionCheck()));
			var service = new RowVersionCheckService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.RowVersionCheckModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLRowVersionCheckMapperMock,
			                                         mock.DALMapperMockFactory.DALRowVersionCheckMapperMock);

			CreateResponse<ApiRowVersionCheckResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.RowVersionCheckModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiRowVersionCheckRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<RowVersionCheck>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IRowVersionCheckRepository>();
			var model = new ApiRowVersionCheckRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<RowVersionCheck>())).Returns(Task.FromResult(new RowVersionCheck()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new RowVersionCheck()));
			var service = new RowVersionCheckService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.RowVersionCheckModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLRowVersionCheckMapperMock,
			                                         mock.DALMapperMockFactory.DALRowVersionCheckMapperMock);

			UpdateResponse<ApiRowVersionCheckResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.RowVersionCheckModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiRowVersionCheckRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<RowVersionCheck>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IRowVersionCheckRepository>();
			var model = new ApiRowVersionCheckRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new RowVersionCheckService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.RowVersionCheckModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLRowVersionCheckMapperMock,
			                                         mock.DALMapperMockFactory.DALRowVersionCheckMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.RowVersionCheckModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>5f0da2a328930024a92ee9c2128b546d</Hash>
</Codenesium>*/