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
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Invitation")]
        [Trait("Area", "Services")]
        public partial class InvitationServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IInvitationRepository>();
                        var records = new List<Invitation>();
                        records.Add(new Invitation());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new InvitationService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.InvitationModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLInvitationMapperMock,
                                                            mock.DALMapperMockFactory.DALInvitationMapperMock);

                        List<ApiInvitationResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IInvitationRepository>();
                        var record = new Invitation();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new InvitationService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.InvitationModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLInvitationMapperMock,
                                                            mock.DALMapperMockFactory.DALInvitationMapperMock);

                        ApiInvitationResponseModel response = await service.Get(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IInvitationRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Invitation>(null));
                        var service = new InvitationService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.InvitationModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLInvitationMapperMock,
                                                            mock.DALMapperMockFactory.DALInvitationMapperMock);

                        ApiInvitationResponseModel response = await service.Get(default (string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IInvitationRepository>();
                        var model = new ApiInvitationRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Invitation>())).Returns(Task.FromResult(new Invitation()));
                        var service = new InvitationService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.InvitationModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLInvitationMapperMock,
                                                            mock.DALMapperMockFactory.DALInvitationMapperMock);

                        CreateResponse<ApiInvitationResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.InvitationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiInvitationRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Invitation>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IInvitationRepository>();
                        var model = new ApiInvitationRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Invitation>())).Returns(Task.FromResult(new Invitation()));
                        var service = new InvitationService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.InvitationModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLInvitationMapperMock,
                                                            mock.DALMapperMockFactory.DALInvitationMapperMock);

                        ActionResponse response = await service.Update(default (string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.InvitationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiInvitationRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Invitation>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IInvitationRepository>();
                        var model = new ApiInvitationRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new InvitationService(mock.LoggerMock.Object,
                                                            mock.RepositoryMock.Object,
                                                            mock.ModelValidatorMockFactory.InvitationModelValidatorMock.Object,
                                                            mock.BOLMapperMockFactory.BOLInvitationMapperMock,
                                                            mock.DALMapperMockFactory.DALInvitationMapperMock);

                        ActionResponse response = await service.Delete(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.InvitationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>f73d69fa41b79c4023bc35fd1ae1b7a2</Hash>
</Codenesium>*/