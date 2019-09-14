using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Admin")]
	[Trait("Area", "Services")]
	public partial class AdminServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IAdminService, IAdminRepository>();
			var records = new List<Admin>();
			records.Add(new Admin());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new AdminService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALAdminMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiAdminServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IAdminService, IAdminRepository>();
			var record = new Admin();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new AdminService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALAdminMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			ApiAdminServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IAdminService, IAdminRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Admin>(null));
			var service = new AdminService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALAdminMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			ApiAdminServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IAdminService, IAdminRepository>();

			var model = new ApiAdminServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Admin>())).Returns(Task.FromResult(new Admin()));
			var service = new AdminService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALAdminMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			CreateResponse<ApiAdminServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.AdminModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiAdminServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Admin>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AdminCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IAdminService, IAdminRepository>();
			var model = new ApiAdminServerRequestModel();
			var validatorMock = new Mock<IApiAdminServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAdminServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new AdminService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALAdminMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			CreateResponse<ApiAdminServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiAdminServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AdminCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IAdminService, IAdminRepository>();
			var model = new ApiAdminServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Admin>())).Returns(Task.FromResult(new Admin()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));
			var service = new AdminService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALAdminMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			UpdateResponse<ApiAdminServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.AdminModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAdminServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Admin>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AdminUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IAdminService, IAdminRepository>();
			var model = new ApiAdminServerRequestModel();
			var validatorMock = new Mock<IApiAdminServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAdminServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));
			var service = new AdminService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALAdminMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			UpdateResponse<ApiAdminServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAdminServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AdminUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IAdminService, IAdminRepository>();
			var model = new ApiAdminServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new AdminService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALAdminMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.AdminModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AdminDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IAdminService, IAdminRepository>();
			var model = new ApiAdminServerRequestModel();
			var validatorMock = new Mock<IApiAdminServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new AdminService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALAdminMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AdminDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void VenuesByAdminId_Exists()
		{
			var mock = new ServiceMockFacade<IAdminService, IAdminRepository>();
			var records = new List<Venue>();
			records.Add(new Venue());
			mock.RepositoryMock.Setup(x => x.VenuesByAdminId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new AdminService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALAdminMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiVenueServerResponseModel> response = await service.VenuesByAdminId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.VenuesByAdminId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void VenuesByAdminId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IAdminService, IAdminRepository>();
			mock.RepositoryMock.Setup(x => x.VenuesByAdminId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Venue>>(new List<Venue>()));
			var service = new AdminService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALAdminMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiVenueServerResponseModel> response = await service.VenuesByAdminId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.VenuesByAdminId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>ca341259c02833776474ba15521f11c1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/