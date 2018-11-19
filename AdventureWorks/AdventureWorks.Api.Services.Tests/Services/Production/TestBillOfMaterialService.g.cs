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
	[Trait("Table", "BillOfMaterial")]
	[Trait("Area", "Services")]
	public partial class BillOfMaterialServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IBillOfMaterialRepository>();
			var records = new List<BillOfMaterial>();
			records.Add(new BillOfMaterial());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new BillOfMaterialService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.BillOfMaterialModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                        mock.DALMapperMockFactory.DALBillOfMaterialMapperMock);

			List<ApiBillOfMaterialServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IBillOfMaterialRepository>();
			var record = new BillOfMaterial();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new BillOfMaterialService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.BillOfMaterialModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                        mock.DALMapperMockFactory.DALBillOfMaterialMapperMock);

			ApiBillOfMaterialServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IBillOfMaterialRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<BillOfMaterial>(null));
			var service = new BillOfMaterialService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.BillOfMaterialModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                        mock.DALMapperMockFactory.DALBillOfMaterialMapperMock);

			ApiBillOfMaterialServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IBillOfMaterialRepository>();
			var model = new ApiBillOfMaterialServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<BillOfMaterial>())).Returns(Task.FromResult(new BillOfMaterial()));
			var service = new BillOfMaterialService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.BillOfMaterialModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                        mock.DALMapperMockFactory.DALBillOfMaterialMapperMock);

			CreateResponse<ApiBillOfMaterialServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.BillOfMaterialModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiBillOfMaterialServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<BillOfMaterial>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IBillOfMaterialRepository>();
			var model = new ApiBillOfMaterialServerRequestModel();
			var validatorMock = new Mock<IApiBillOfMaterialServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiBillOfMaterialServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new BillOfMaterialService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                        mock.DALMapperMockFactory.DALBillOfMaterialMapperMock);

			CreateResponse<ApiBillOfMaterialServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiBillOfMaterialServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IBillOfMaterialRepository>();
			var model = new ApiBillOfMaterialServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<BillOfMaterial>())).Returns(Task.FromResult(new BillOfMaterial()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new BillOfMaterial()));
			var service = new BillOfMaterialService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.BillOfMaterialModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                        mock.DALMapperMockFactory.DALBillOfMaterialMapperMock);

			UpdateResponse<ApiBillOfMaterialServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.BillOfMaterialModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBillOfMaterialServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<BillOfMaterial>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IBillOfMaterialRepository>();
			var model = new ApiBillOfMaterialServerRequestModel();
			var validatorMock = new Mock<IApiBillOfMaterialServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBillOfMaterialServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new BillOfMaterial()));
			var service = new BillOfMaterialService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                        mock.DALMapperMockFactory.DALBillOfMaterialMapperMock);

			UpdateResponse<ApiBillOfMaterialServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBillOfMaterialServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IBillOfMaterialRepository>();
			var model = new ApiBillOfMaterialServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new BillOfMaterialService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.BillOfMaterialModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                        mock.DALMapperMockFactory.DALBillOfMaterialMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.BillOfMaterialModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IBillOfMaterialRepository>();
			var model = new ApiBillOfMaterialServerRequestModel();
			var validatorMock = new Mock<IApiBillOfMaterialServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new BillOfMaterialService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                        mock.DALMapperMockFactory.DALBillOfMaterialMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByUnitMeasureCode_Exists()
		{
			var mock = new ServiceMockFacade<IBillOfMaterialRepository>();
			var records = new List<BillOfMaterial>();
			records.Add(new BillOfMaterial());
			mock.RepositoryMock.Setup(x => x.ByUnitMeasureCode(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new BillOfMaterialService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.BillOfMaterialModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                        mock.DALMapperMockFactory.DALBillOfMaterialMapperMock);

			List<ApiBillOfMaterialServerResponseModel> response = await service.ByUnitMeasureCode("test_value");

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUnitMeasureCode(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByUnitMeasureCode_Not_Exists()
		{
			var mock = new ServiceMockFacade<IBillOfMaterialRepository>();
			mock.RepositoryMock.Setup(x => x.ByUnitMeasureCode(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<BillOfMaterial>>(new List<BillOfMaterial>()));
			var service = new BillOfMaterialService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.BillOfMaterialModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                        mock.DALMapperMockFactory.DALBillOfMaterialMapperMock);

			List<ApiBillOfMaterialServerResponseModel> response = await service.ByUnitMeasureCode("test_value");

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUnitMeasureCode(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>1fd2a2bd23ded1cc013eb93fd784618a</Hash>
</Codenesium>*/