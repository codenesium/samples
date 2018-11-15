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
			                                 mock.DALMapperMockFactory.DALStudentMapperMock);

			List<ApiStudentServerResponseModel> response = await service.All();

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
			                                 mock.DALMapperMockFactory.DALStudentMapperMock);

			ApiStudentServerResponseModel response = await service.Get(default(int));

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
			                                 mock.DALMapperMockFactory.DALStudentMapperMock);

			ApiStudentServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IStudentRepository>();
			var model = new ApiStudentServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Student>())).Returns(Task.FromResult(new Student()));
			var service = new StudentService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALStudentMapperMock);

			CreateResponse<ApiStudentServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.StudentModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiStudentServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Student>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IStudentRepository>();
			var model = new ApiStudentServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Student>())).Returns(Task.FromResult(new Student()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));
			var service = new StudentService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALStudentMapperMock);

			UpdateResponse<ApiStudentServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.StudentModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStudentServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Student>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IStudentRepository>();
			var model = new ApiStudentServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new StudentService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALStudentMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.StudentModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByFamilyId_Exists()
		{
			var mock = new ServiceMockFacade<IStudentRepository>();
			var records = new List<Student>();
			records.Add(new Student());
			mock.RepositoryMock.Setup(x => x.ByFamilyId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StudentService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALStudentMapperMock);

			List<ApiStudentServerResponseModel> response = await service.ByFamilyId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByFamilyId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByFamilyId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStudentRepository>();
			mock.RepositoryMock.Setup(x => x.ByFamilyId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Student>>(new List<Student>()));
			var service = new StudentService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALStudentMapperMock);

			List<ApiStudentServerResponseModel> response = await service.ByFamilyId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByFamilyId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByUserId_Exists()
		{
			var mock = new ServiceMockFacade<IStudentRepository>();
			var records = new List<Student>();
			records.Add(new Student());
			mock.RepositoryMock.Setup(x => x.ByUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StudentService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALStudentMapperMock);

			List<ApiStudentServerResponseModel> response = await service.ByUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStudentRepository>();
			mock.RepositoryMock.Setup(x => x.ByUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Student>>(new List<Student>()));
			var service = new StudentService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALStudentMapperMock);

			List<ApiStudentServerResponseModel> response = await service.ByUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>bcadaf3132047ab5836ba176ac5155be</Hash>
</Codenesium>*/