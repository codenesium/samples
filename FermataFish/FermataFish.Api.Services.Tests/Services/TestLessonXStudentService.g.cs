using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "LessonXStudent")]
        [Trait("Area", "Services")]
        public partial class LessonXStudentServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ILessonXStudentRepository>();
                        var records = new List<LessonXStudent>();
                        records.Add(new LessonXStudent());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new LessonXStudentService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.LessonXStudentModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
                                                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock);

                        List<ApiLessonXStudentResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ILessonXStudentRepository>();
                        var record = new LessonXStudent();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new LessonXStudentService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.LessonXStudentModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
                                                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock);

                        ApiLessonXStudentResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ILessonXStudentRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<LessonXStudent>(null));
                        var service = new LessonXStudentService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.LessonXStudentModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
                                                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock);

                        ApiLessonXStudentResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ILessonXStudentRepository>();
                        var model = new ApiLessonXStudentRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LessonXStudent>())).Returns(Task.FromResult(new LessonXStudent()));
                        var service = new LessonXStudentService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.LessonXStudentModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
                                                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock);

                        CreateResponse<ApiLessonXStudentResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.LessonXStudentModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLessonXStudentRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<LessonXStudent>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ILessonXStudentRepository>();
                        var model = new ApiLessonXStudentRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LessonXStudent>())).Returns(Task.FromResult(new LessonXStudent()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LessonXStudent()));
                        var service = new LessonXStudentService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.LessonXStudentModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
                                                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock);

                        UpdateResponse<ApiLessonXStudentResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.LessonXStudentModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLessonXStudentRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<LessonXStudent>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ILessonXStudentRepository>();
                        var model = new ApiLessonXStudentRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new LessonXStudentService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.LessonXStudentModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
                                                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.LessonXStudentModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>e170fdae47e5fc42a65a1808171c35b9</Hash>
</Codenesium>*/