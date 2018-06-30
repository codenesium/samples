using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "VariableSet")]
        [Trait("Area", "Services")]
        public partial class VariableSetServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IVariableSetRepository>();
                        var records = new List<VariableSet>();
                        records.Add(new VariableSet());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new VariableSetService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VariableSetModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVariableSetMapperMock,
                                                             mock.DALMapperMockFactory.DALVariableSetMapperMock);

                        List<ApiVariableSetResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IVariableSetRepository>();
                        var record = new VariableSet();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new VariableSetService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VariableSetModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVariableSetMapperMock,
                                                             mock.DALMapperMockFactory.DALVariableSetMapperMock);

                        ApiVariableSetResponseModel response = await service.Get(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IVariableSetRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<VariableSet>(null));
                        var service = new VariableSetService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VariableSetModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVariableSetMapperMock,
                                                             mock.DALMapperMockFactory.DALVariableSetMapperMock);

                        ApiVariableSetResponseModel response = await service.Get(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IVariableSetRepository>();
                        var model = new ApiVariableSetRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VariableSet>())).Returns(Task.FromResult(new VariableSet()));
                        var service = new VariableSetService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VariableSetModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVariableSetMapperMock,
                                                             mock.DALMapperMockFactory.DALVariableSetMapperMock);

                        CreateResponse<ApiVariableSetResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.VariableSetModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVariableSetRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<VariableSet>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IVariableSetRepository>();
                        var model = new ApiVariableSetRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VariableSet>())).Returns(Task.FromResult(new VariableSet()));
                        var service = new VariableSetService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VariableSetModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVariableSetMapperMock,
                                                             mock.DALMapperMockFactory.DALVariableSetMapperMock);

                        ActionResponse response = await service.Update(default(string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.VariableSetModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiVariableSetRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<VariableSet>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IVariableSetRepository>();
                        var model = new ApiVariableSetRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new VariableSetService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.VariableSetModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLVariableSetMapperMock,
                                                             mock.DALMapperMockFactory.DALVariableSetMapperMock);

                        ActionResponse response = await service.Delete(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.VariableSetModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>06e11827e9efb0e2443fbd3b0f388414</Hash>
</Codenesium>*/