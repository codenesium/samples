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
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PurchaseOrderHeader")]
	[Trait("Area", "Services")]
	public partial class PurchaseOrderHeaderServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			var records = new List<PurchaseOrderHeader>();
			records.Add(new PurchaseOrderHeader());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			List<ApiPurchaseOrderHeaderServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			var record = new PurchaseOrderHeader();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			ApiPurchaseOrderHeaderServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PurchaseOrderHeader>(null));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			ApiPurchaseOrderHeaderServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			var model = new ApiPurchaseOrderHeaderServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PurchaseOrderHeader>())).Returns(Task.FromResult(new PurchaseOrderHeader()));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			CreateResponse<ApiPurchaseOrderHeaderServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PurchaseOrderHeader>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			var model = new ApiPurchaseOrderHeaderServerRequestModel();
			var validatorMock = new Mock<IApiPurchaseOrderHeaderServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			CreateResponse<ApiPurchaseOrderHeaderServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			var model = new ApiPurchaseOrderHeaderServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PurchaseOrderHeader>())).Returns(Task.FromResult(new PurchaseOrderHeader()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PurchaseOrderHeader()));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			UpdateResponse<ApiPurchaseOrderHeaderServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PurchaseOrderHeader>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			var model = new ApiPurchaseOrderHeaderServerRequestModel();
			var validatorMock = new Mock<IApiPurchaseOrderHeaderServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PurchaseOrderHeader()));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			UpdateResponse<ApiPurchaseOrderHeaderServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			var model = new ApiPurchaseOrderHeaderServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			var model = new ApiPurchaseOrderHeaderServerRequestModel();
			var validatorMock = new Mock<IApiPurchaseOrderHeaderServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByEmployeeID_Exists()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			var records = new List<PurchaseOrderHeader>();
			records.Add(new PurchaseOrderHeader());
			mock.RepositoryMock.Setup(x => x.ByEmployeeID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			List<ApiPurchaseOrderHeaderServerResponseModel> response = await service.ByEmployeeID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByEmployeeID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByEmployeeID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			mock.RepositoryMock.Setup(x => x.ByEmployeeID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PurchaseOrderHeader>>(new List<PurchaseOrderHeader>()));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			List<ApiPurchaseOrderHeaderServerResponseModel> response = await service.ByEmployeeID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByEmployeeID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByVendorID_Exists()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			var records = new List<PurchaseOrderHeader>();
			records.Add(new PurchaseOrderHeader());
			mock.RepositoryMock.Setup(x => x.ByVendorID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			List<ApiPurchaseOrderHeaderServerResponseModel> response = await service.ByVendorID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByVendorID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByVendorID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPurchaseOrderHeaderRepository>();
			mock.RepositoryMock.Setup(x => x.ByVendorID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PurchaseOrderHeader>>(new List<PurchaseOrderHeader>()));
			var service = new PurchaseOrderHeaderService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.PurchaseOrderHeaderModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                             mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			List<ApiPurchaseOrderHeaderServerResponseModel> response = await service.ByVendorID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByVendorID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>1ea748905fc763dc60b65214aca914c8</Hash>
</Codenesium>*/