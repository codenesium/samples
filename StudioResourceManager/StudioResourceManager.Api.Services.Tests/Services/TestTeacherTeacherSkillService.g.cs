using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
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
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new TeacherTeacherSkillService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiTeacherTeacherSkillServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITeacherTeacherSkillRepository>();
			var record = new TeacherTeacherSkill();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TeacherTeacherSkillService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			ApiTeacherTeacherSkillServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITeacherTeacherSkillRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TeacherTeacherSkill>(null));
			var service = new TeacherTeacherSkillService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			ApiTeacherTeacherSkillServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ITeacherTeacherSkillRepository>();
			var model = new ApiTeacherTeacherSkillServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TeacherTeacherSkill>())).Returns(Task.FromResult(new TeacherTeacherSkill()));
			var service = new TeacherTeacherSkillService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			CreateResponse<ApiTeacherTeacherSkillServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherTeacherSkillServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TeacherTeacherSkill>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeacherTeacherSkillCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ITeacherTeacherSkillRepository>();
			var model = new ApiTeacherTeacherSkillServerRequestModel();
			var validatorMock = new Mock<IApiTeacherTeacherSkillServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherTeacherSkillServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TeacherTeacherSkillService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			CreateResponse<ApiTeacherTeacherSkillServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherTeacherSkillServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeacherTeacherSkillCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ITeacherTeacherSkillRepository>();
			var model = new ApiTeacherTeacherSkillServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TeacherTeacherSkill>())).Returns(Task.FromResult(new TeacherTeacherSkill()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TeacherTeacherSkill()));
			var service = new TeacherTeacherSkillService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			UpdateResponse<ApiTeacherTeacherSkillServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherTeacherSkillServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TeacherTeacherSkill>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeacherTeacherSkillUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ITeacherTeacherSkillRepository>();
			var model = new ApiTeacherTeacherSkillServerRequestModel();
			var validatorMock = new Mock<IApiTeacherTeacherSkillServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherTeacherSkillServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TeacherTeacherSkill()));
			var service = new TeacherTeacherSkillService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			UpdateResponse<ApiTeacherTeacherSkillServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherTeacherSkillServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeacherTeacherSkillUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ITeacherTeacherSkillRepository>();
			var model = new ApiTeacherTeacherSkillServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TeacherTeacherSkillService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeacherTeacherSkillDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ITeacherTeacherSkillRepository>();
			var model = new ApiTeacherTeacherSkillServerRequestModel();
			var validatorMock = new Mock<IApiTeacherTeacherSkillServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TeacherTeacherSkillService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeacherTeacherSkillDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByTeacherId_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherTeacherSkillRepository>();
			var records = new List<TeacherTeacherSkill>();
			records.Add(new TeacherTeacherSkill());
			mock.RepositoryMock.Setup(x => x.ByTeacherId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeacherTeacherSkillService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiTeacherTeacherSkillServerResponseModel> response = await service.ByTeacherId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTeacherId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTeacherId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherTeacherSkillRepository>();
			mock.RepositoryMock.Setup(x => x.ByTeacherId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TeacherTeacherSkill>>(new List<TeacherTeacherSkill>()));
			var service = new TeacherTeacherSkillService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiTeacherTeacherSkillServerResponseModel> response = await service.ByTeacherId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTeacherId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTeacherSkillId_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherTeacherSkillRepository>();
			var records = new List<TeacherTeacherSkill>();
			records.Add(new TeacherTeacherSkill());
			mock.RepositoryMock.Setup(x => x.ByTeacherSkillId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeacherTeacherSkillService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiTeacherTeacherSkillServerResponseModel> response = await service.ByTeacherSkillId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTeacherSkillId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTeacherSkillId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherTeacherSkillRepository>();
			mock.RepositoryMock.Setup(x => x.ByTeacherSkillId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TeacherTeacherSkill>>(new List<TeacherTeacherSkill>()));
			var service = new TeacherTeacherSkillService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.TeacherTeacherSkillModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiTeacherTeacherSkillServerResponseModel> response = await service.ByTeacherSkillId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTeacherSkillId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>acfb101c88b8292f0aff7609f789eab4</Hash>
</Codenesium>*/