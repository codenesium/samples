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
			                                      mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

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
			                                      mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

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
			                                      mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

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
			                                      mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

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
			                                      mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

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
			                                      mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

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
			                                      mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

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
			                                      mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiRateResponseModel> response = await service.Rates(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Rates(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeacherXTeacherSkills_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherSkillRepository>();
			var records = new List<TeacherXTeacherSkill>();
			records.Add(new TeacherXTeacherSkill());
			mock.RepositoryMock.Setup(x => x.TeacherXTeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                      mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                      mock.DALMapperMockFactory.DALRateMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiTeacherXTeacherSkillResponseModel> response = await service.TeacherXTeacherSkills(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TeacherXTeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeacherXTeacherSkills_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherSkillRepository>();
			mock.RepositoryMock.Setup(x => x.TeacherXTeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TeacherXTeacherSkill>>(new List<TeacherXTeacherSkill>()));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                      mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                      mock.DALMapperMockFactory.DALRateMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTeacherXTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherXTeacherSkillMapperMock);

			List<ApiTeacherXTeacherSkillResponseModel> response = await service.TeacherXTeacherSkills(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TeacherXTeacherSkills(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>f391c2bdffd92128740cc704d97d473a</Hash>
</Codenesium>*/