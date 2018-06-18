using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "TransactionHistory")]
        [Trait("Area", "Services")]
        public partial class TransactionHistoryServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
                        var records = new List<TransactionHistory>();
                        records.Add(new TransactionHistory());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new TransactionHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

                        List<ApiTransactionHistoryResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
                        var record = new TransactionHistory();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new TransactionHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

                        ApiTransactionHistoryResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TransactionHistory>(null));
                        var service = new TransactionHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

                        ApiTransactionHistoryResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
                        var model = new ApiTransactionHistoryRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TransactionHistory>())).Returns(Task.FromResult(new TransactionHistory()));
                        var service = new TransactionHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

                        CreateResponse<ApiTransactionHistoryResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionHistoryRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TransactionHistory>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
                        var model = new ApiTransactionHistoryRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TransactionHistory>())).Returns(Task.FromResult(new TransactionHistory()));
                        var service = new TransactionHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TransactionHistory>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
                        var model = new ApiTransactionHistoryRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new TransactionHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByProductID_Exists()
                {
                        var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
                        var records = new List<TransactionHistory>();
                        records.Add(new TransactionHistory());
                        mock.RepositoryMock.Setup(x => x.ByProductID(It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new TransactionHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

                        List<ApiTransactionHistoryResponseModel> response = await service.ByProductID(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByProductID(It.IsAny<int>()));
                }

                [Fact]
                public async void ByProductID_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
                        mock.RepositoryMock.Setup(x => x.ByProductID(It.IsAny<int>())).Returns(Task.FromResult<List<TransactionHistory>>(new List<TransactionHistory>()));
                        var service = new TransactionHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

                        List<ApiTransactionHistoryResponseModel> response = await service.ByProductID(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByProductID(It.IsAny<int>()));
                }

                [Fact]
                public async void ByReferenceOrderIDReferenceOrderLineID_Exists()
                {
                        var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
                        var records = new List<TransactionHistory>();
                        records.Add(new TransactionHistory());
                        mock.RepositoryMock.Setup(x => x.ByReferenceOrderIDReferenceOrderLineID(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new TransactionHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

                        List<ApiTransactionHistoryResponseModel> response = await service.ByReferenceOrderIDReferenceOrderLineID(default (int), default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByReferenceOrderIDReferenceOrderLineID(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void ByReferenceOrderIDReferenceOrderLineID_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
                        mock.RepositoryMock.Setup(x => x.ByReferenceOrderIDReferenceOrderLineID(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TransactionHistory>>(new List<TransactionHistory>()));
                        var service = new TransactionHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLTransactionHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

                        List<ApiTransactionHistoryResponseModel> response = await service.ByReferenceOrderIDReferenceOrderLineID(default (int), default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByReferenceOrderIDReferenceOrderLineID(It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>9ce0cf2aaf99b307a12226de63c27446</Hash>
</Codenesium>*/