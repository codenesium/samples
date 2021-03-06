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
	[Trait("Table", "Teacher")]
	[Trait("Area", "Services")]
	public partial class TeacherServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ITeacherService, ITeacherRepository>();
			var records = new List<Teacher>();
			records.Add(new Teacher());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiTeacherServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ITeacherService, ITeacherRepository>();
			var record = new Teacher();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			ApiTeacherServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ITeacherService, ITeacherRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(null));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			ApiTeacherServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ITeacherService, ITeacherRepository>();

			var model = new ApiTeacherServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Teacher>())).Returns(Task.FromResult(new Teacher()));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			CreateResponse<ApiTeacherServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Teacher>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeacherCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ITeacherService, ITeacherRepository>();
			var model = new ApiTeacherServerRequestModel();
			var validatorMock = new Mock<IApiTeacherServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			CreateResponse<ApiTeacherServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeacherCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ITeacherService, ITeacherRepository>();
			var model = new ApiTeacherServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Teacher>())).Returns(Task.FromResult(new Teacher()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			UpdateResponse<ApiTeacherServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Teacher>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeacherUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ITeacherService, ITeacherRepository>();
			var model = new ApiTeacherServerRequestModel();
			var validatorMock = new Mock<IApiTeacherServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			UpdateResponse<ApiTeacherServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeacherUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ITeacherService, ITeacherRepository>();
			var model = new ApiTeacherServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeacherDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ITeacherService, ITeacherRepository>();
			var model = new ApiTeacherServerRequestModel();
			var validatorMock = new Mock<IApiTeacherServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeacherDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByUserId_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherService, ITeacherRepository>();
			var records = new List<Teacher>();
			records.Add(new Teacher());
			mock.RepositoryMock.Setup(x => x.ByUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiTeacherServerResponseModel> response = await service.ByUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherService, ITeacherRepository>();
			mock.RepositoryMock.Setup(x => x.ByUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Teacher>>(new List<Teacher>()));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiTeacherServerResponseModel> response = await service.ByUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventTeachersByTeacherId_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherService, ITeacherRepository>();
			var records = new List<EventTeacher>();
			records.Add(new EventTeacher());
			mock.RepositoryMock.Setup(x => x.EventTeachersByTeacherId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiEventTeacherServerResponseModel> response = await service.EventTeachersByTeacherId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.EventTeachersByTeacherId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventTeachersByTeacherId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherService, ITeacherRepository>();
			mock.RepositoryMock.Setup(x => x.EventTeachersByTeacherId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<EventTeacher>>(new List<EventTeacher>()));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiEventTeacherServerResponseModel> response = await service.EventTeachersByTeacherId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.EventTeachersByTeacherId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void RatesByTeacherId_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherService, ITeacherRepository>();
			var records = new List<Rate>();
			records.Add(new Rate());
			mock.RepositoryMock.Setup(x => x.RatesByTeacherId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiRateServerResponseModel> response = await service.RatesByTeacherId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.RatesByTeacherId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void RatesByTeacherId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherService, ITeacherRepository>();
			mock.RepositoryMock.Setup(x => x.RatesByTeacherId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Rate>>(new List<Rate>()));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiRateServerResponseModel> response = await service.RatesByTeacherId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.RatesByTeacherId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeacherTeacherSkillsByTeacherId_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherService, ITeacherRepository>();
			var records = new List<TeacherTeacherSkill>();
			records.Add(new TeacherTeacherSkill());
			mock.RepositoryMock.Setup(x => x.TeacherTeacherSkillsByTeacherId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiTeacherTeacherSkillServerResponseModel> response = await service.TeacherTeacherSkillsByTeacherId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TeacherTeacherSkillsByTeacherId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeacherTeacherSkillsByTeacherId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherService, ITeacherRepository>();
			mock.RepositoryMock.Setup(x => x.TeacherTeacherSkillsByTeacherId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TeacherTeacherSkill>>(new List<TeacherTeacherSkill>()));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALEventTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiTeacherTeacherSkillServerResponseModel> response = await service.TeacherTeacherSkillsByTeacherId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TeacherTeacherSkillsByTeacherId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>79b978d34b95301a15b6fdf6d77219c9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/