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
        [Trait("Table", "ErrorLog")]
        [Trait("Area", "Services")]
        public partial class ErrorLogServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IErrorLogRepository>();
                        var records = new List<ErrorLog>();
                        records.Add(new ErrorLog());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ErrorLogService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.ErrorLogModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLErrorLogMapperMock,
                                                          mock.DALMapperMockFactory.DALErrorLogMapperMock);

                        List<ApiErrorLogResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IErrorLogRepository>();
                        var record = new ErrorLog();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new ErrorLogService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.ErrorLogModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLErrorLogMapperMock,
                                                          mock.DALMapperMockFactory.DALErrorLogMapperMock);

                        ApiErrorLogResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IErrorLogRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ErrorLog>(null));
                        var service = new ErrorLogService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.ErrorLogModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLErrorLogMapperMock,
                                                          mock.DALMapperMockFactory.DALErrorLogMapperMock);

                        ApiErrorLogResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IErrorLogRepository>();
                        var model = new ApiErrorLogRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ErrorLog>())).Returns(Task.FromResult(new ErrorLog()));
                        var service = new ErrorLogService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.ErrorLogModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLErrorLogMapperMock,
                                                          mock.DALMapperMockFactory.DALErrorLogMapperMock);

                        CreateResponse<ApiErrorLogResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ErrorLogModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiErrorLogRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ErrorLog>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IErrorLogRepository>();
                        var model = new ApiErrorLogRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ErrorLog>())).Returns(Task.FromResult(new ErrorLog()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ErrorLog()));
                        var service = new ErrorLogService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.ErrorLogModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLErrorLogMapperMock,
                                                          mock.DALMapperMockFactory.DALErrorLogMapperMock);

                        UpdateResponse<ApiErrorLogResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ErrorLogModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiErrorLogRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ErrorLog>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IErrorLogRepository>();
                        var model = new ApiErrorLogRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new ErrorLogService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.ErrorLogModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLErrorLogMapperMock,
                                                          mock.DALMapperMockFactory.DALErrorLogMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.ErrorLogModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>340e874b2891eb81a492b462ec329e02</Hash>
</Codenesium>*/