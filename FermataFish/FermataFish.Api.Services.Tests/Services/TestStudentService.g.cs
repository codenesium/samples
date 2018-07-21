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
        [Trait("Table", "Student")]
        [Trait("Area", "Services")]
        public partial class StudentServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IStudentRepository>();
                        var records = new List<Student>();
                        records.Add(new Student());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new StudentService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXTeacherMapperMock,
                                                         mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

                        List<ApiStudentResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IStudentRepository>();
                        var record = new Student();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new StudentService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXTeacherMapperMock,
                                                         mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

                        ApiStudentResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IStudentRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Student>(null));
                        var service = new StudentService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXTeacherMapperMock,
                                                         mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

                        ApiStudentResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IStudentRepository>();
                        var model = new ApiStudentRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Student>())).Returns(Task.FromResult(new Student()));
                        var service = new StudentService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXTeacherMapperMock,
                                                         mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

                        CreateResponse<ApiStudentResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.StudentModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiStudentRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Student>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IStudentRepository>();
                        var model = new ApiStudentRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Student>())).Returns(Task.FromResult(new Student()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));
                        var service = new StudentService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXTeacherMapperMock,
                                                         mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

                        UpdateResponse<ApiStudentResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.StudentModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStudentRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Student>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IStudentRepository>();
                        var model = new ApiStudentRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new StudentService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXTeacherMapperMock,
                                                         mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.StudentModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void LessonXStudents_Exists()
                {
                        var mock = new ServiceMockFacade<IStudentRepository>();
                        var records = new List<LessonXStudent>();
                        records.Add(new LessonXStudent());
                        mock.RepositoryMock.Setup(x => x.LessonXStudents(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new StudentService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXTeacherMapperMock,
                                                         mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

                        List<ApiLessonXStudentResponseModel> response = await service.LessonXStudents(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.LessonXStudents(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void LessonXStudents_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IStudentRepository>();
                        mock.RepositoryMock.Setup(x => x.LessonXStudents(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<LessonXStudent>>(new List<LessonXStudent>()));
                        var service = new StudentService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXTeacherMapperMock,
                                                         mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

                        List<ApiLessonXStudentResponseModel> response = await service.LessonXStudents(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.LessonXStudents(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void LessonXTeachers_Exists()
                {
                        var mock = new ServiceMockFacade<IStudentRepository>();
                        var records = new List<LessonXTeacher>();
                        records.Add(new LessonXTeacher());
                        mock.RepositoryMock.Setup(x => x.LessonXTeachers(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new StudentService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXTeacherMapperMock,
                                                         mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

                        List<ApiLessonXTeacherResponseModel> response = await service.LessonXTeachers(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.LessonXTeachers(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void LessonXTeachers_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IStudentRepository>();
                        mock.RepositoryMock.Setup(x => x.LessonXTeachers(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<LessonXTeacher>>(new List<LessonXTeacher>()));
                        var service = new StudentService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXTeacherMapperMock,
                                                         mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

                        List<ApiLessonXTeacherResponseModel> response = await service.LessonXTeachers(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.LessonXTeachers(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void StudentXFamilies_Exists()
                {
                        var mock = new ServiceMockFacade<IStudentRepository>();
                        var records = new List<StudentXFamily>();
                        records.Add(new StudentXFamily());
                        mock.RepositoryMock.Setup(x => x.StudentXFamilies(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new StudentService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXTeacherMapperMock,
                                                         mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

                        List<ApiStudentXFamilyResponseModel> response = await service.StudentXFamilies(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.StudentXFamilies(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void StudentXFamilies_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IStudentRepository>();
                        mock.RepositoryMock.Setup(x => x.StudentXFamilies(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<StudentXFamily>>(new List<StudentXFamily>()));
                        var service = new StudentService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
                                                         mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
                                                         mock.DALMapperMockFactory.DALLessonXTeacherMapperMock,
                                                         mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
                                                         mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

                        List<ApiStudentXFamilyResponseModel> response = await service.StudentXFamilies(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.StudentXFamilies(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>65c12a3f318cec76a985529171dd2380</Hash>
</Codenesium>*/