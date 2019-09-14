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
	[Trait("Table", "Family")]
	[Trait("Area", "Services")]
	public partial class FamilyServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IFamilyService, IFamilyRepository>();
			var records = new List<Family>();
			records.Add(new Family());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new FamilyService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock);

			List<ApiFamilyServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IFamilyService, IFamilyRepository>();
			var record = new Family();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new FamilyService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock);

			ApiFamilyServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IFamilyService, IFamilyRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Family>(null));
			var service = new FamilyService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock);

			ApiFamilyServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IFamilyService, IFamilyRepository>();

			var model = new ApiFamilyServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Family>())).Returns(Task.FromResult(new Family()));
			var service = new FamilyService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock);

			CreateResponse<ApiFamilyServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiFamilyServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Family>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FamilyCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IFamilyService, IFamilyRepository>();
			var model = new ApiFamilyServerRequestModel();
			var validatorMock = new Mock<IApiFamilyServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiFamilyServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new FamilyService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock);

			CreateResponse<ApiFamilyServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiFamilyServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FamilyCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IFamilyService, IFamilyRepository>();
			var model = new ApiFamilyServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Family>())).Returns(Task.FromResult(new Family()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Family()));
			var service = new FamilyService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock);

			UpdateResponse<ApiFamilyServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFamilyServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Family>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FamilyUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IFamilyService, IFamilyRepository>();
			var model = new ApiFamilyServerRequestModel();
			var validatorMock = new Mock<IApiFamilyServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFamilyServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Family()));
			var service = new FamilyService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock);

			UpdateResponse<ApiFamilyServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFamilyServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FamilyUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IFamilyService, IFamilyRepository>();
			var model = new ApiFamilyServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new FamilyService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FamilyDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IFamilyService, IFamilyRepository>();
			var model = new ApiFamilyServerRequestModel();
			var validatorMock = new Mock<IApiFamilyServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new FamilyService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FamilyDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void StudentsByFamilyId_Exists()
		{
			var mock = new ServiceMockFacade<IFamilyService, IFamilyRepository>();
			var records = new List<Student>();
			records.Add(new Student());
			mock.RepositoryMock.Setup(x => x.StudentsByFamilyId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new FamilyService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock);

			List<ApiStudentServerResponseModel> response = await service.StudentsByFamilyId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.StudentsByFamilyId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void StudentsByFamilyId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IFamilyService, IFamilyRepository>();
			mock.RepositoryMock.Setup(x => x.StudentsByFamilyId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Student>>(new List<Student>()));
			var service = new FamilyService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock);

			List<ApiStudentServerResponseModel> response = await service.StudentsByFamilyId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.StudentsByFamilyId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>3836c0f81702d5d58741a277f9c15dca</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/