using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "User")]
	[Trait("Area", "Services")]
	public partial class UserServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<User>();
			records.Add(new User());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                              mock.DALMapperMockFactory.DALAdminMapperMock,
			                              mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                              mock.DALMapperMockFactory.DALStudentMapperMock,
			                              mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                              mock.DALMapperMockFactory.DALTeacherMapperMock);

			List<ApiUserServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var record = new User();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                              mock.DALMapperMockFactory.DALAdminMapperMock,
			                              mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                              mock.DALMapperMockFactory.DALStudentMapperMock,
			                              mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                              mock.DALMapperMockFactory.DALTeacherMapperMock);

			ApiUserServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<User>(null));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                              mock.DALMapperMockFactory.DALAdminMapperMock,
			                              mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                              mock.DALMapperMockFactory.DALStudentMapperMock,
			                              mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                              mock.DALMapperMockFactory.DALTeacherMapperMock);

			ApiUserServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var model = new ApiUserServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<User>())).Returns(Task.FromResult(new User()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                              mock.DALMapperMockFactory.DALAdminMapperMock,
			                              mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                              mock.DALMapperMockFactory.DALStudentMapperMock,
			                              mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                              mock.DALMapperMockFactory.DALTeacherMapperMock);

			CreateResponse<ApiUserServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.UserModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiUserServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<User>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var model = new ApiUserServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<User>())).Returns(Task.FromResult(new User()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                              mock.DALMapperMockFactory.DALAdminMapperMock,
			                              mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                              mock.DALMapperMockFactory.DALStudentMapperMock,
			                              mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                              mock.DALMapperMockFactory.DALTeacherMapperMock);

			UpdateResponse<ApiUserServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.UserModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUserServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<User>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var model = new ApiUserServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                              mock.DALMapperMockFactory.DALAdminMapperMock,
			                              mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                              mock.DALMapperMockFactory.DALStudentMapperMock,
			                              mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                              mock.DALMapperMockFactory.DALTeacherMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.UserModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void AdminsByUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<Admin>();
			records.Add(new Admin());
			mock.RepositoryMock.Setup(x => x.AdminsByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                              mock.DALMapperMockFactory.DALAdminMapperMock,
			                              mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                              mock.DALMapperMockFactory.DALStudentMapperMock,
			                              mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                              mock.DALMapperMockFactory.DALTeacherMapperMock);

			List<ApiAdminServerResponseModel> response = await service.AdminsByUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.AdminsByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void AdminsByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.AdminsByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Admin>>(new List<Admin>()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                              mock.DALMapperMockFactory.DALAdminMapperMock,
			                              mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                              mock.DALMapperMockFactory.DALStudentMapperMock,
			                              mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                              mock.DALMapperMockFactory.DALTeacherMapperMock);

			List<ApiAdminServerResponseModel> response = await service.AdminsByUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.AdminsByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void StudentsByUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<Student>();
			records.Add(new Student());
			mock.RepositoryMock.Setup(x => x.StudentsByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                              mock.DALMapperMockFactory.DALAdminMapperMock,
			                              mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                              mock.DALMapperMockFactory.DALStudentMapperMock,
			                              mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                              mock.DALMapperMockFactory.DALTeacherMapperMock);

			List<ApiStudentServerResponseModel> response = await service.StudentsByUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.StudentsByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void StudentsByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.StudentsByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Student>>(new List<Student>()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                              mock.DALMapperMockFactory.DALAdminMapperMock,
			                              mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                              mock.DALMapperMockFactory.DALStudentMapperMock,
			                              mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                              mock.DALMapperMockFactory.DALTeacherMapperMock);

			List<ApiStudentServerResponseModel> response = await service.StudentsByUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.StudentsByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeachersByUserId_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			var records = new List<Teacher>();
			records.Add(new Teacher());
			mock.RepositoryMock.Setup(x => x.TeachersByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                              mock.DALMapperMockFactory.DALAdminMapperMock,
			                              mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                              mock.DALMapperMockFactory.DALStudentMapperMock,
			                              mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                              mock.DALMapperMockFactory.DALTeacherMapperMock);

			List<ApiTeacherServerResponseModel> response = await service.TeachersByUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TeachersByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeachersByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUserRepository>();
			mock.RepositoryMock.Setup(x => x.TeachersByUserId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Teacher>>(new List<Teacher>()));
			var service = new UserService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLUserMapperMock,
			                              mock.DALMapperMockFactory.DALUserMapperMock,
			                              mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                              mock.DALMapperMockFactory.DALAdminMapperMock,
			                              mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                              mock.DALMapperMockFactory.DALStudentMapperMock,
			                              mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                              mock.DALMapperMockFactory.DALTeacherMapperMock);

			List<ApiTeacherServerResponseModel> response = await service.TeachersByUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TeachersByUserId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>d878a631d5b09747b050dfc29e3ed526</Hash>
</Codenesium>*/