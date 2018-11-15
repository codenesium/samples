using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ChainStatus")]
	[Trait("Area", "Services")]
	public partial class ChainStatusServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IChainStatusRepository>();
			var records = new List<ChainStatus>();
			records.Add(new ChainStatus());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ChainStatusService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLChainStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALChainStatusMapperMock);

			List<ApiChainStatusServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IChainStatusRepository>();
			var record = new ChainStatus();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ChainStatusService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLChainStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALChainStatusMapperMock);

			ApiChainStatusServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IChainStatusRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ChainStatus>(null));
			var service = new ChainStatusService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLChainStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALChainStatusMapperMock);

			ApiChainStatusServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IChainStatusRepository>();
			var model = new ApiChainStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ChainStatus>())).Returns(Task.FromResult(new ChainStatus()));
			var service = new ChainStatusService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLChainStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALChainStatusMapperMock);

			CreateResponse<ApiChainStatusServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiChainStatusServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ChainStatus>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IChainStatusRepository>();
			var model = new ApiChainStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ChainStatus>())).Returns(Task.FromResult(new ChainStatus()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatus()));
			var service = new ChainStatusService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLChainStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALChainStatusMapperMock);

			UpdateResponse<ApiChainStatusServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiChainStatusServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ChainStatus>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IChainStatusRepository>();
			var model = new ApiChainStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ChainStatusService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLChainStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALChainStatusMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IChainStatusRepository>();
			var record = new ChainStatus();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ChainStatusService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLChainStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALChainStatusMapperMock);

			ApiChainStatusServerResponseModel response = await service.ByName("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IChainStatusRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ChainStatus>(null));
			var service = new ChainStatusService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLChainStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALChainStatusMapperMock);

			ApiChainStatusServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>e51fda83a931403d3bad9d067f6f8132</Hash>
</Codenesium>*/