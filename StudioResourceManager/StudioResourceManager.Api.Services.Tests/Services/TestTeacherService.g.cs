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
	[Trait("Table", "Teacher")]
	[Trait("Area", "Services")]
	public partial class TeacherServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			var records = new List<Teacher>();
			records.Add(new Teacher());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiTeacherResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			var record = new Teacher();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			ApiTeacherResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(null));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			ApiTeacherResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			var model = new ApiTeacherRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Teacher>())).Returns(Task.FromResult(new Teacher()));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			CreateResponse<ApiTeacherResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Teacher>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			var model = new ApiTeacherRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Teacher>())).Returns(Task.FromResult(new Teacher()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			UpdateResponse<ApiTeacherResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Teacher>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			var model = new ApiTeacherRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void EventTeachers_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			var records = new List<EventTeacher>();
			records.Add(new EventTeacher());
			mock.RepositoryMock.Setup(x => x.EventTeachers(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiEventTeacherResponseModel> response = await service.EventTeachers(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.EventTeachers(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventTeachers_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			mock.RepositoryMock.Setup(x => x.EventTeachers(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<EventTeacher>>(new List<EventTeacher>()));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiEventTeacherResponseModel> response = await service.EventTeachers(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.EventTeachers(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Rates_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			var records = new List<Rate>();
			records.Add(new Rate());
			mock.RepositoryMock.Setup(x => x.Rates(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiRateResponseModel> response = await service.Rates(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Rates(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Rates_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			mock.RepositoryMock.Setup(x => x.Rates(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Rate>>(new List<Rate>()));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiRateResponseModel> response = await service.Rates(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Rates(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeacherTeacherSkills_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			var records = new List<TeacherTeacherSkill>();
			records.Add(new TeacherTeacherSkill());
			mock.RepositoryMock.Setup(x => x.TeacherTeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiTeacherTeacherSkillResponseModel> response = await service.TeacherTeacherSkills(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TeacherTeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeacherTeacherSkills_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			mock.RepositoryMock.Setup(x => x.TeacherTeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TeacherTeacherSkill>>(new List<TeacherTeacherSkill>()));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiTeacherTeacherSkillResponseModel> response = await service.TeacherTeacherSkills(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TeacherTeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>17722a5e5ccef47170f45928b00876db</Hash>
</Codenesium>*/