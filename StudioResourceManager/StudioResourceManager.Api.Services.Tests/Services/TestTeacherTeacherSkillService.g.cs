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
	[Trait("Table", "TeacherTeacherSkill")]
	[Trait("Area", "Services")]
	public partial class TeacherTeacherSkillServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITeacherTeacherSkillRepository>();
			var records = new List<TeacherTeacherSkill>();
			records.Add(new TeacherTeacherSkill());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeacherTeacherSkillService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                             mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiTeacherTeacherSkillResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITeacherTeacherSkillRepository>();
			var record = new TeacherTeacherSkill();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TeacherTeacherSkillService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                             mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			ApiTeacherTeacherSkillResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITeacherTeacherSkillRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TeacherTeacherSkill>(null));
			var service = new TeacherTeacherSkillService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                             mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			ApiTeacherTeacherSkillResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ITeacherTeacherSkillRepository>();
			var model = new ApiTeacherTeacherSkillRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TeacherTeacherSkill>())).Returns(Task.FromResult(new TeacherTeacherSkill()));
			var service = new TeacherTeacherSkillService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                             mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			CreateResponse<ApiTeacherTeacherSkillResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherTeacherSkillRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TeacherTeacherSkill>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ITeacherTeacherSkillRepository>();
			var model = new ApiTeacherTeacherSkillRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TeacherTeacherSkill>())).Returns(Task.FromResult(new TeacherTeacherSkill()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TeacherTeacherSkill()));
			var service = new TeacherTeacherSkillService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                             mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			UpdateResponse<ApiTeacherTeacherSkillResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherTeacherSkillRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TeacherTeacherSkill>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ITeacherTeacherSkillRepository>();
			var model = new ApiTeacherTeacherSkillRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TeacherTeacherSkillService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                             mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>c9856ca355bb8757cd42561b354cdf7a</Hash>
</Codenesium>*/