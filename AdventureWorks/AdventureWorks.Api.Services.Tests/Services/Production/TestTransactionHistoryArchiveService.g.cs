using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionHistoryArchive")]
	[Trait("Area", "Services")]
	public partial class TransactionHistoryArchiveServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			var records = new List<TransactionHistoryArchive>();
			records.Add(new TransactionHistoryArchive());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			List<ApiTransactionHistoryArchiveServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			var record = new TransactionHistoryArchive();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			ApiTransactionHistoryArchiveServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TransactionHistoryArchive>(null));
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			ApiTransactionHistoryArchiveServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			var model = new ApiTransactionHistoryArchiveServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TransactionHistoryArchive>())).Returns(Task.FromResult(new TransactionHistoryArchive()));
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			CreateResponse<ApiTransactionHistoryArchiveServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TransactionHistoryArchive>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			var model = new ApiTransactionHistoryArchiveServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TransactionHistoryArchive>())).Returns(Task.FromResult(new TransactionHistoryArchive()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistoryArchive()));
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			UpdateResponse<ApiTransactionHistoryArchiveServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TransactionHistoryArchive>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			var model = new ApiTransactionHistoryArchiveServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByProductID_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			var records = new List<TransactionHistoryArchive>();
			records.Add(new TransactionHistoryArchive());
			mock.RepositoryMock.Setup(x => x.ByProductID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			List<ApiTransactionHistoryArchiveServerResponseModel> response = await service.ByProductID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByProductID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByProductID_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			mock.RepositoryMock.Setup(x => x.ByProductID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TransactionHistoryArchive>>(new List<TransactionHistoryArchive>()));
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			List<ApiTransactionHistoryArchiveServerResponseModel> response = await service.ByProductID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByProductID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByReferenceOrderIDReferenceOrderLineID_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			var records = new List<TransactionHistoryArchive>();
			records.Add(new TransactionHistoryArchive());
			mock.RepositoryMock.Setup(x => x.ByReferenceOrderIDReferenceOrderLineID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			List<ApiTransactionHistoryArchiveServerResponseModel> response = await service.ByReferenceOrderIDReferenceOrderLineID(default(int), default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByReferenceOrderIDReferenceOrderLineID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByReferenceOrderIDReferenceOrderLineID_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			mock.RepositoryMock.Setup(x => x.ByReferenceOrderIDReferenceOrderLineID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TransactionHistoryArchive>>(new List<TransactionHistoryArchive>()));
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			List<ApiTransactionHistoryArchiveServerResponseModel> response = await service.ByReferenceOrderIDReferenceOrderLineID(default(int), default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByReferenceOrderIDReferenceOrderLineID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>42ed5d36b7e9276cf498a56ca1c02c47</Hash>
</Codenesium>*/