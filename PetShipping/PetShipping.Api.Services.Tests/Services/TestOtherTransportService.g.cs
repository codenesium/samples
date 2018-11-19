using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OtherTransport")]
	[Trait("Area", "Services")]
	public partial class OtherTransportServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IOtherTransportRepository>();
			var records = new List<OtherTransport>();
			records.Add(new OtherTransport());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			List<ApiOtherTransportServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IOtherTransportRepository>();
			var record = new OtherTransport();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			ApiOtherTransportServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IOtherTransportRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<OtherTransport>(null));
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			ApiOtherTransportServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IOtherTransportRepository>();
			var model = new ApiOtherTransportServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<OtherTransport>())).Returns(Task.FromResult(new OtherTransport()));
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			CreateResponse<ApiOtherTransportServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiOtherTransportServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<OtherTransport>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IOtherTransportRepository>();
			var model = new ApiOtherTransportServerRequestModel();
			var validatorMock = new Mock<IApiOtherTransportServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiOtherTransportServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			CreateResponse<ApiOtherTransportServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiOtherTransportServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IOtherTransportRepository>();
			var model = new ApiOtherTransportServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<OtherTransport>())).Returns(Task.FromResult(new OtherTransport()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new OtherTransport()));
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			UpdateResponse<ApiOtherTransportServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOtherTransportServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<OtherTransport>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IOtherTransportRepository>();
			var model = new ApiOtherTransportServerRequestModel();
			var validatorMock = new Mock<IApiOtherTransportServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOtherTransportServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new OtherTransport()));
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			UpdateResponse<ApiOtherTransportServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOtherTransportServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IOtherTransportRepository>();
			var model = new ApiOtherTransportServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IOtherTransportRepository>();
			var model = new ApiOtherTransportServerRequestModel();
			var validatorMock = new Mock<IApiOtherTransportServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>e937098f546d44f856b822d58b428906</Hash>
</Codenesium>*/