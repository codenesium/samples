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
	[Trait("Table", "ColumnSameAsFKTable")]
	[Trait("Area", "Services")]
	public partial class ColumnSameAsFKTableServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableRepository>();
			var records = new List<ColumnSameAsFKTable>();
			records.Add(new ColumnSameAsFKTable());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			List<ApiColumnSameAsFKTableServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableRepository>();
			var record = new ColumnSameAsFKTable();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			ApiColumnSameAsFKTableServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ColumnSameAsFKTable>(null));
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			ApiColumnSameAsFKTableServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableRepository>();
			var model = new ApiColumnSameAsFKTableServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ColumnSameAsFKTable>())).Returns(Task.FromResult(new ColumnSameAsFKTable()));
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			CreateResponse<ApiColumnSameAsFKTableServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiColumnSameAsFKTableServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ColumnSameAsFKTable>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableRepository>();
			var model = new ApiColumnSameAsFKTableServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ColumnSameAsFKTable>())).Returns(Task.FromResult(new ColumnSameAsFKTable()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ColumnSameAsFKTable()));
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			UpdateResponse<ApiColumnSameAsFKTableServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiColumnSameAsFKTableServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ColumnSameAsFKTable>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableRepository>();
			var model = new ApiColumnSameAsFKTableServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>b90b1378c0d1bd0d1378eeb99bd099b6</Hash>
</Codenesium>*/