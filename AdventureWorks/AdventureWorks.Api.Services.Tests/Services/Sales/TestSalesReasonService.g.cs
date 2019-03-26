using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SalesReason")]
	[Trait("Area", "Services")]
	public partial class SalesReasonServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISalesReasonRepository>();
			var records = new List<SalesReason>();
			records.Add(new SalesReason());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new SalesReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesReasonModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALSalesReasonMapperMock);

			List<ApiSalesReasonServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISalesReasonRepository>();
			var record = new SalesReason();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SalesReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesReasonModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALSalesReasonMapperMock);

			ApiSalesReasonServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISalesReasonRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SalesReason>(null));
			var service = new SalesReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesReasonModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALSalesReasonMapperMock);

			ApiSalesReasonServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ISalesReasonRepository>();
			var model = new ApiSalesReasonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesReason>())).Returns(Task.FromResult(new SalesReason()));
			var service = new SalesReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesReasonModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALSalesReasonMapperMock);

			CreateResponse<ApiSalesReasonServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SalesReasonModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSalesReasonServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SalesReason>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SalesReasonCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ISalesReasonRepository>();
			var model = new ApiSalesReasonServerRequestModel();
			var validatorMock = new Mock<IApiSalesReasonServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSalesReasonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SalesReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALSalesReasonMapperMock);

			CreateResponse<ApiSalesReasonServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSalesReasonServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SalesReasonCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ISalesReasonRepository>();
			var model = new ApiSalesReasonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesReason>())).Returns(Task.FromResult(new SalesReason()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesReason()));
			var service = new SalesReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesReasonModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALSalesReasonMapperMock);

			UpdateResponse<ApiSalesReasonServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SalesReasonModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesReasonServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SalesReason>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SalesReasonUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ISalesReasonRepository>();
			var model = new ApiSalesReasonServerRequestModel();
			var validatorMock = new Mock<IApiSalesReasonServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesReasonServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesReason()));
			var service = new SalesReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALSalesReasonMapperMock);

			UpdateResponse<ApiSalesReasonServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesReasonServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SalesReasonUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ISalesReasonRepository>();
			var model = new ApiSalesReasonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SalesReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesReasonModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALSalesReasonMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SalesReasonModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SalesReasonDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ISalesReasonRepository>();
			var model = new ApiSalesReasonServerRequestModel();
			var validatorMock = new Mock<IApiSalesReasonServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SalesReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALSalesReasonMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SalesReasonDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>94690c11454636176f907d775597d209</Hash>
</Codenesium>*/