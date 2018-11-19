using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
		public async void All()
		{
			var mock = new ServiceMockFacade<IVenueRepository>();
			var records = new List<Venue>();
			records.Add(new Venue());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiVenueServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IVenueRepository>();
			var record = new Venue();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			ApiVenueServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IVenueRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Venue>(null));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			ApiVenueServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IVenueRepository>();
			var model = new ApiVenueServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Venue>())).Returns(Task.FromResult(new Venue()));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			CreateResponse<ApiVenueServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VenueModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVenueServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Venue>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IVenueRepository>();
			var model = new ApiVenueServerRequestModel();
			var validatorMock = new Mock<IApiVenueServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVenueServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			CreateResponse<ApiVenueServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVenueServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IVenueRepository>();
			var model = new ApiVenueServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Venue>())).Returns(Task.FromResult(new Venue()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			UpdateResponse<ApiVenueServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VenueModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVenueServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Venue>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IVenueRepository>();
			var model = new ApiVenueServerRequestModel();
			var validatorMock = new Mock<IApiVenueServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVenueServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			UpdateResponse<ApiVenueServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVenueServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IVenueRepository>();
			var model = new ApiVenueServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VenueModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IVenueRepository>();
			var model = new ApiVenueServerRequestModel();
			var validatorMock = new Mock<IApiVenueServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByAdminId_Exists()
		{
			var mock = new ServiceMockFacade<IVenueRepository>();
			var records = new List<Venue>();
			records.Add(new Venue());
			mock.RepositoryMock.Setup(x => x.ByAdminId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiVenueServerResponseModel> response = await service.ByAdminId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByAdminId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByAdminId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVenueRepository>();
			mock.RepositoryMock.Setup(x => x.ByAdminId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Venue>>(new List<Venue>()));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiVenueServerResponseModel> response = await service.ByAdminId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByAdminId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByProvinceId_Exists()
		{
			var mock = new ServiceMockFacade<IVenueRepository>();
			var records = new List<Venue>();
			records.Add(new Venue());
			mock.RepositoryMock.Setup(x => x.ByProvinceId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiVenueServerResponseModel> response = await service.ByProvinceId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByProvinceId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByProvinceId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVenueRepository>();
			mock.RepositoryMock.Setup(x => x.ByProvinceId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Venue>>(new List<Venue>()));
			var service = new VenueService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLVenueMapperMock,
			                               mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiVenueServerResponseModel> response = await service.ByProvinceId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByProvinceId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>0c8fc1ef518b682943bcaeb30303ebeb</Hash>
</Codenesium>*/