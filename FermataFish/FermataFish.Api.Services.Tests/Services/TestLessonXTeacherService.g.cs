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
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "LessonXTeacher")]
        [Trait("Area", "Services")]
        public partial class LessonXTeacherServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ILessonXTeacherRepository>();
                        var records = new List<LessonXTeacher>();
                        records.Add(new LessonXTeacher());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new LessonXTeacherService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.LessonXTeacherModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
                                                                mock.DALMapperMockFactory.DALLessonXTeacherMapperMock);

                        List<ApiLessonXTeacherResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ILessonXTeacherRepository>();
                        var record = new LessonXTeacher();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new LessonXTeacherService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.LessonXTeacherModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
                                                                mock.DALMapperMockFactory.DALLessonXTeacherMapperMock);

                        ApiLessonXTeacherResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ILessonXTeacherRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<LessonXTeacher>(null));
                        var service = new LessonXTeacherService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.LessonXTeacherModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
                                                                mock.DALMapperMockFactory.DALLessonXTeacherMapperMock);

                        ApiLessonXTeacherResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ILessonXTeacherRepository>();
                        var model = new ApiLessonXTeacherRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LessonXTeacher>())).Returns(Task.FromResult(new LessonXTeacher()));
                        var service = new LessonXTeacherService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.LessonXTeacherModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
                                                                mock.DALMapperMockFactory.DALLessonXTeacherMapperMock);

                        CreateResponse<ApiLessonXTeacherResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.LessonXTeacherModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLessonXTeacherRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<LessonXTeacher>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ILessonXTeacherRepository>();
                        var model = new ApiLessonXTeacherRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LessonXTeacher>())).Returns(Task.FromResult(new LessonXTeacher()));
                        var service = new LessonXTeacherService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.LessonXTeacherModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
                                                                mock.DALMapperMockFactory.DALLessonXTeacherMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.LessonXTeacherModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLessonXTeacherRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<LessonXTeacher>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ILessonXTeacherRepository>();
                        var model = new ApiLessonXTeacherRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new LessonXTeacherService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.LessonXTeacherModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
                                                                mock.DALMapperMockFactory.DALLessonXTeacherMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.LessonXTeacherModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>938deea6f96dcd1b4bedbb3ada7986bc</Hash>
</Codenesium>*/