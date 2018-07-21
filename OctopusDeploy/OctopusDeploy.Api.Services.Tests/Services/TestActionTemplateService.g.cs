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
        [Trait("Table", "ActionTemplate")]
        [Trait("Area", "Services")]
        public partial class ActionTemplateServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IActionTemplateRepository>();
                        var records = new List<ActionTemplate>();
                        records.Add(new ActionTemplate());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ActionTemplateService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.ActionTemplateModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLActionTemplateMapperMock,
                                                                mock.DALMapperMockFactory.DALActionTemplateMapperMock);

                        List<ApiActionTemplateResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IActionTemplateRepository>();
                        var record = new ActionTemplate();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new ActionTemplateService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.ActionTemplateModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLActionTemplateMapperMock,
                                                                mock.DALMapperMockFactory.DALActionTemplateMapperMock);

                        ApiActionTemplateResponseModel response = await service.Get(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IActionTemplateRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ActionTemplate>(null));
                        var service = new ActionTemplateService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.ActionTemplateModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLActionTemplateMapperMock,
                                                                mock.DALMapperMockFactory.DALActionTemplateMapperMock);

                        ApiActionTemplateResponseModel response = await service.Get(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IActionTemplateRepository>();
                        var model = new ApiActionTemplateRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ActionTemplate>())).Returns(Task.FromResult(new ActionTemplate()));
                        var service = new ActionTemplateService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.ActionTemplateModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLActionTemplateMapperMock,
                                                                mock.DALMapperMockFactory.DALActionTemplateMapperMock);

                        CreateResponse<ApiActionTemplateResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ActionTemplateModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiActionTemplateRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ActionTemplate>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IActionTemplateRepository>();
                        var model = new ApiActionTemplateRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ActionTemplate>())).Returns(Task.FromResult(new ActionTemplate()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplate()));
                        var service = new ActionTemplateService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.ActionTemplateModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLActionTemplateMapperMock,
                                                                mock.DALMapperMockFactory.DALActionTemplateMapperMock);

                        UpdateResponse<ApiActionTemplateResponseModel> response = await service.Update(default(string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ActionTemplateModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiActionTemplateRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ActionTemplate>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IActionTemplateRepository>();
                        var model = new ApiActionTemplateRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new ActionTemplateService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.ActionTemplateModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLActionTemplateMapperMock,
                                                                mock.DALMapperMockFactory.DALActionTemplateMapperMock);

                        ActionResponse response = await service.Delete(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.ActionTemplateModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Exists()
                {
                        var mock = new ServiceMockFacade<IActionTemplateRepository>();
                        var record = new ActionTemplate();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new ActionTemplateService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.ActionTemplateModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLActionTemplateMapperMock,
                                                                mock.DALMapperMockFactory.DALActionTemplateMapperMock);

                        ApiActionTemplateResponseModel response = await service.ByName(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IActionTemplateRepository>();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ActionTemplate>(null));
                        var service = new ActionTemplateService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.ActionTemplateModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLActionTemplateMapperMock,
                                                                mock.DALMapperMockFactory.DALActionTemplateMapperMock);

                        ApiActionTemplateResponseModel response = await service.ByName(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>c1eb3deaba97b8f0351d71d54c085f39</Hash>
</Codenesium>*/