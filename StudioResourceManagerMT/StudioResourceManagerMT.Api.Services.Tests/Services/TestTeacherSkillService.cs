using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TeacherSkill")]
	[Trait("Area", "Services")]
	public partial class TeacherSkillServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ITeacherSkillService, ITeacherSkillRepository>();
			var records = new List<TeacherSkill>();
			records.Add(new TeacherSkill());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALRateMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiTeacherSkillServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ITeacherSkillService, ITeacherSkillRepository>();
			var record = new TeacherSkill();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALRateMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			ApiTeacherSkillServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ITeacherSkillService, ITeacherSkillRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TeacherSkill>(null));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALRateMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			ApiTeacherSkillServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ITeacherSkillService, ITeacherSkillRepository>();

			var model = new ApiTeacherSkillServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TeacherSkill>())).Returns(Task.FromResult(new TeacherSkill()));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALRateMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			CreateResponse<ApiTeacherSkillServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherSkillServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TeacherSkill>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeacherSkillCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ITeacherSkillService, ITeacherSkillRepository>();
			var model = new ApiTeacherSkillServerRequestModel();
			var validatorMock = new Mock<IApiTeacherSkillServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherSkillServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALRateMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			CreateResponse<ApiTeacherSkillServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherSkillServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeacherSkillCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ITeacherSkillService, ITeacherSkillRepository>();
			var model = new ApiTeacherSkillServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TeacherSkill>())).Returns(Task.FromResult(new TeacherSkill()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TeacherSkill()));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALRateMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			UpdateResponse<ApiTeacherSkillServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherSkillServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TeacherSkill>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeacherSkillUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ITeacherSkillService, ITeacherSkillRepository>();
			var model = new ApiTeacherSkillServerRequestModel();
			var validatorMock = new Mock<IApiTeacherSkillServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherSkillServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TeacherSkill()));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALRateMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			UpdateResponse<ApiTeacherSkillServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherSkillServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeacherSkillUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ITeacherSkillService, ITeacherSkillRepository>();
			var model = new ApiTeacherSkillServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALRateMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeacherSkillDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ITeacherSkillService, ITeacherSkillRepository>();
			var model = new ApiTeacherSkillServerRequestModel();
			var validatorMock = new Mock<IApiTeacherSkillServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALRateMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeacherSkillDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void RatesByTeacherSkillId_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherSkillService, ITeacherSkillRepository>();
			var records = new List<Rate>();
			records.Add(new Rate());
			mock.RepositoryMock.Setup(x => x.RatesByTeacherSkillId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALRateMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiRateServerResponseModel> response = await service.RatesByTeacherSkillId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.RatesByTeacherSkillId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void RatesByTeacherSkillId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherSkillService, ITeacherSkillRepository>();
			mock.RepositoryMock.Setup(x => x.RatesByTeacherSkillId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Rate>>(new List<Rate>()));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALRateMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiRateServerResponseModel> response = await service.RatesByTeacherSkillId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.RatesByTeacherSkillId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeacherTeacherSkillsByTeacherSkillId_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherSkillService, ITeacherSkillRepository>();
			var records = new List<TeacherTeacherSkill>();
			records.Add(new TeacherTeacherSkill());
			mock.RepositoryMock.Setup(x => x.TeacherTeacherSkillsByTeacherSkillId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALRateMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiTeacherTeacherSkillServerResponseModel> response = await service.TeacherTeacherSkillsByTeacherSkillId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TeacherTeacherSkillsByTeacherSkillId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeacherTeacherSkillsByTeacherSkillId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherSkillService, ITeacherSkillRepository>();
			mock.RepositoryMock.Setup(x => x.TeacherTeacherSkillsByTeacherSkillId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TeacherTeacherSkill>>(new List<TeacherTeacherSkill>()));
			var service = new TeacherSkillService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TeacherSkillModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALTeacherSkillMapperMock,
			                                      mock.DALMapperMockFactory.DALRateMapperMock,
			                                      mock.DALMapperMockFactory.DALTeacherTeacherSkillMapperMock);

			List<ApiTeacherTeacherSkillServerResponseModel> response = await service.TeacherTeacherSkillsByTeacherSkillId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TeacherTeacherSkillsByTeacherSkillId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>0ff67b53a669a4ac8e630c3e91eb0116</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/