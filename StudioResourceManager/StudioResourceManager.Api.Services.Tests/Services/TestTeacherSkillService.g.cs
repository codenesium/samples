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
	[Trait("Table", "TeacherSkill")]
	[Trait("Area", "Services")]
	public partial class TeacherSkillServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITeacherSkillRepository>();
			var records = new List<TeacherSkill>();
			records.Add(new TeacherSkill());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                      mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                      mock.DALMapperMockFactory.DALRateMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiTeacherSkillResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITeacherSkillRepository>();
			var record = new TeacherSkill();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                      mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                      mock.DALMapperMockFactory.DALRateMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			ApiTeacherSkillResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITeacherSkillRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(null));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                      mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                      mock.DALMapperMockFactory.DALRateMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			ApiTeacherSkillResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ITeacherSkillRepository>();
			var model = new ApiTeacherSkillRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TeacherSkill>())).Returns(Task.FromResult(new TeacherSkill()));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                      mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                      mock.DALMapperMockFactory.DALRateMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			CreateResponse<ApiTeacherSkillResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherSkillRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TeacherSkill>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ITeacherSkillRepository>();
			var model = new ApiTeacherSkillRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TeacherSkill>())).Returns(Task.FromResult(new TeacherSkill()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TeacherSkill()));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                      mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                      mock.DALMapperMockFactory.DALRateMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			UpdateResponse<ApiTeacherSkillResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherSkillRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TeacherSkill>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ITeacherSkillRepository>();
			var model = new ApiTeacherSkillRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                      mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                      mock.DALMapperMockFactory.DALRateMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTeacherTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Rates_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherSkillRepository>();
			var records = new List<Rate>();
			records.Add(new Rate());
			mock.RepositoryMock.Setup(x => x.Rates(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
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
			var mock = new ServiceMockFacade<ITeacherSkillRepository>();
			mock.RepositoryMock.Setup(x => x.Rates(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Rate>>(new List<Rate>()));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
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
			var mock = new ServiceMockFacade<ITeacherSkillRepository>();
			var records = new List<TeacherTeacherSkill>();
			records.Add(new TeacherTeacherSkill());
			mock.RepositoryMock.Setup(x => x.TeacherTeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
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
			var mock = new ServiceMockFacade<ITeacherSkillRepository>();
			mock.RepositoryMock.Setup(x => x.TeacherTeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TeacherTeacherSkill>>(new List<TeacherTeacherSkill>()));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
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
    <Hash>76e740f2ff008388f0a6a4b7a906b948</Hash>
</Codenesium>*/