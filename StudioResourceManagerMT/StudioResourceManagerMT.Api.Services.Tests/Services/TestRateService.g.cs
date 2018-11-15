using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Rate")]
	[Trait("Area", "Services")]
	public partial class RateServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IRateRepository>();
			var records = new List<Rate>();
			records.Add(new Rate());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new RateService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.RateModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLRateMapperMock,
			                              mock.DALMapperMockFactory.DALRateMapperMock);

			List<ApiRateServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IRateRepository>();
			var record = new Rate();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new RateService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.RateModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLRateMapperMock,
			                              mock.DALMapperMockFactory.DALRateMapperMock);

			ApiRateServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IRateRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Rate>(null));
			var service = new RateService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.RateModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLRateMapperMock,
			                              mock.DALMapperMockFactory.DALRateMapperMock);

			ApiRateServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IRateRepository>();
			var model = new ApiRateServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Rate>())).Returns(Task.FromResult(new Rate()));
			var service = new RateService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.RateModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLRateMapperMock,
			                              mock.DALMapperMockFactory.DALRateMapperMock);

			CreateResponse<ApiRateServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.RateModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiRateServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Rate>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IRateRepository>();
			var model = new ApiRateServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Rate>())).Returns(Task.FromResult(new Rate()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Rate()));
			var service = new RateService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.RateModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLRateMapperMock,
			                              mock.DALMapperMockFactory.DALRateMapperMock);

			UpdateResponse<ApiRateServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.RateModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiRateServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Rate>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IRateRepository>();
			var model = new ApiRateServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new RateService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.RateModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLRateMapperMock,
			                              mock.DALMapperMockFactory.DALRateMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.RateModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByTeacherId_Exists()
		{
			var mock = new ServiceMockFacade<IRateRepository>();
			var records = new List<Rate>();
			records.Add(new Rate());
			mock.RepositoryMock.Setup(x => x.ByTeacherId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new RateService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.RateModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLRateMapperMock,
			                              mock.DALMapperMockFactory.DALRateMapperMock);

			List<ApiRateServerResponseModel> response = await service.ByTeacherId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTeacherId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTeacherId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IRateRepository>();
			mock.RepositoryMock.Setup(x => x.ByTeacherId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Rate>>(new List<Rate>()));
			var service = new RateService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.RateModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLRateMapperMock,
			                              mock.DALMapperMockFactory.DALRateMapperMock);

			List<ApiRateServerResponseModel> response = await service.ByTeacherId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTeacherId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTeacherSkillId_Exists()
		{
			var mock = new ServiceMockFacade<IRateRepository>();
			var records = new List<Rate>();
			records.Add(new Rate());
			mock.RepositoryMock.Setup(x => x.ByTeacherSkillId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new RateService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.RateModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLRateMapperMock,
			                              mock.DALMapperMockFactory.DALRateMapperMock);

			List<ApiRateServerResponseModel> response = await service.ByTeacherSkillId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTeacherSkillId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTeacherSkillId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IRateRepository>();
			mock.RepositoryMock.Setup(x => x.ByTeacherSkillId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Rate>>(new List<Rate>()));
			var service = new RateService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.RateModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLRateMapperMock,
			                              mock.DALMapperMockFactory.DALRateMapperMock);

			List<ApiRateServerResponseModel> response = await service.ByTeacherSkillId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTeacherSkillId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>910f4c2876eb16b61ce6a2dd5de28dfd</Hash>
</Codenesium>*/