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
	[Trait("Table", "Lesson")]
	[Trait("Area", "Services")]
	public partial class LessonServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ILessonRepository>();
			var records = new List<Lesson>();
			records.Add(new Lesson());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LessonService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.LessonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXTeacherMapperMock);

			List<ApiLessonResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ILessonRepository>();
			var record = new Lesson();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new LessonService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.LessonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXTeacherMapperMock);

			ApiLessonResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ILessonRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Lesson>(null));
			var service = new LessonService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.LessonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXTeacherMapperMock);

			ApiLessonResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ILessonRepository>();
			var model = new ApiLessonRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Lesson>())).Returns(Task.FromResult(new Lesson()));
			var service = new LessonService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.LessonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXTeacherMapperMock);

			CreateResponse<ApiLessonResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.LessonModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLessonRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Lesson>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ILessonRepository>();
			var model = new ApiLessonRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Lesson>())).Returns(Task.FromResult(new Lesson()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Lesson()));
			var service = new LessonService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.LessonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXTeacherMapperMock);

			UpdateResponse<ApiLessonResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.LessonModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLessonRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Lesson>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ILessonRepository>();
			var model = new ApiLessonRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new LessonService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.LessonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXTeacherMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.LessonModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void LessonXStudents_Exists()
		{
			var mock = new ServiceMockFacade<ILessonRepository>();
			var records = new List<LessonXStudent>();
			records.Add(new LessonXStudent());
			mock.RepositoryMock.Setup(x => x.LessonXStudents(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LessonService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.LessonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXTeacherMapperMock);

			List<ApiLessonXStudentResponseModel> response = await service.LessonXStudents(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.LessonXStudents(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void LessonXStudents_Not_Exists()
		{
			var mock = new ServiceMockFacade<ILessonRepository>();
			mock.RepositoryMock.Setup(x => x.LessonXStudents(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<LessonXStudent>>(new List<LessonXStudent>()));
			var service = new LessonService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.LessonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXTeacherMapperMock);

			List<ApiLessonXStudentResponseModel> response = await service.LessonXStudents(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.LessonXStudents(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void LessonXTeachers_Exists()
		{
			var mock = new ServiceMockFacade<ILessonRepository>();
			var records = new List<LessonXTeacher>();
			records.Add(new LessonXTeacher());
			mock.RepositoryMock.Setup(x => x.LessonXTeachers(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LessonService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.LessonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXTeacherMapperMock);

			List<ApiLessonXTeacherResponseModel> response = await service.LessonXTeachers(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.LessonXTeachers(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void LessonXTeachers_Not_Exists()
		{
			var mock = new ServiceMockFacade<ILessonRepository>();
			mock.RepositoryMock.Setup(x => x.LessonXTeachers(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<LessonXTeacher>>(new List<LessonXTeacher>()));
			var service = new LessonService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.LessonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                mock.DALMapperMockFactory.DALLessonMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXStudentMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLLessonXTeacherMapperMock,
			                                mock.DALMapperMockFactory.DALLessonXTeacherMapperMock);

			List<ApiLessonXTeacherResponseModel> response = await service.LessonXTeachers(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.LessonXTeachers(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>20c2621685ccb6dda35afc32391eb827</Hash>
</Codenesium>*/