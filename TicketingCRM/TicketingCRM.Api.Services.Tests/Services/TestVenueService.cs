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
	[Trait("Table", "Venue")]
	[Trait("Area", "Services")]
	public partial class VenueServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IVenueService, IVenueRepository>();
			var records = new List<Venue>();
			records.Add(new Venue());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiVenueServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IVenueService, IVenueRepository>();
			var record = new Venue();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			ApiVenueServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IVenueService, IVenueRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Venue>(null));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			ApiVenueServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IVenueService, IVenueRepository>();

			var model = new ApiVenueServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Venue>())).Returns(Task.FromResult(new Venue()));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			CreateResponse<ApiVenueServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VenueModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVenueServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Venue>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VenueCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IVenueService, IVenueRepository>();
			var model = new ApiVenueServerRequestModel();
			var validatorMock = new Mock<IApiVenueServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVenueServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			CreateResponse<ApiVenueServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVenueServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VenueCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IVenueService, IVenueRepository>();
			var model = new ApiVenueServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Venue>())).Returns(Task.FromResult(new Venue()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			UpdateResponse<ApiVenueServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VenueModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVenueServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Venue>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VenueUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IVenueService, IVenueRepository>();
			var model = new ApiVenueServerRequestModel();
			var validatorMock = new Mock<IApiVenueServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVenueServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			UpdateResponse<ApiVenueServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVenueServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VenueUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IVenueService, IVenueRepository>();
			var model = new ApiVenueServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VenueModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VenueDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IVenueService, IVenueRepository>();
			var model = new ApiVenueServerRequestModel();
			var validatorMock = new Mock<IApiVenueServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VenueDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByAdminId_Exists()
		{
			var mock = new ServiceMockFacade<IVenueService, IVenueRepository>();
			var records = new List<Venue>();
			records.Add(new Venue());
			mock.RepositoryMock.Setup(x => x.ByAdminId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiVenueServerResponseModel> response = await service.ByAdminId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByAdminId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByAdminId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVenueService, IVenueRepository>();
			mock.RepositoryMock.Setup(x => x.ByAdminId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Venue>>(new List<Venue>()));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiVenueServerResponseModel> response = await service.ByAdminId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByAdminId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByProvinceId_Exists()
		{
			var mock = new ServiceMockFacade<IVenueService, IVenueRepository>();
			var records = new List<Venue>();
			records.Add(new Venue());
			mock.RepositoryMock.Setup(x => x.ByProvinceId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiVenueServerResponseModel> response = await service.ByProvinceId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByProvinceId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByProvinceId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVenueService, IVenueRepository>();
			mock.RepositoryMock.Setup(x => x.ByProvinceId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Venue>>(new List<Venue>()));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiVenueServerResponseModel> response = await service.ByProvinceId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByProvinceId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>50c1f7e73ee5a956520c66f2e2846baa</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/