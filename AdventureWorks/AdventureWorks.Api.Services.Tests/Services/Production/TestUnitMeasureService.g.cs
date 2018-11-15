using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
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
	[Trait("Table", "UnitMeasure")]
	[Trait("Area", "Services")]
	public partial class UnitMeasureServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IUnitMeasureRepository>();
			var records = new List<UnitMeasure>();
			records.Add(new UnitMeasure());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UnitMeasureService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLUnitMeasureMapperMock,
			                                     mock.DALMapperMockFactory.DALUnitMeasureMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                     mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                     mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                     mock.DALMapperMockFactory.DALProductMapperMock);

			List<ApiUnitMeasureServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IUnitMeasureRepository>();
			var record = new UnitMeasure();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new UnitMeasureService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLUnitMeasureMapperMock,
			                                     mock.DALMapperMockFactory.DALUnitMeasureMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                     mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                     mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                     mock.DALMapperMockFactory.DALProductMapperMock);

			ApiUnitMeasureServerResponseModel response = await service.Get(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IUnitMeasureRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<UnitMeasure>(null));
			var service = new UnitMeasureService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLUnitMeasureMapperMock,
			                                     mock.DALMapperMockFactory.DALUnitMeasureMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                     mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                     mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                     mock.DALMapperMockFactory.DALProductMapperMock);

			ApiUnitMeasureServerResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IUnitMeasureRepository>();
			var model = new ApiUnitMeasureServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<UnitMeasure>())).Returns(Task.FromResult(new UnitMeasure()));
			var service = new UnitMeasureService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLUnitMeasureMapperMock,
			                                     mock.DALMapperMockFactory.DALUnitMeasureMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                     mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                     mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                     mock.DALMapperMockFactory.DALProductMapperMock);

			CreateResponse<ApiUnitMeasureServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiUnitMeasureServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<UnitMeasure>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IUnitMeasureRepository>();
			var model = new ApiUnitMeasureServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<UnitMeasure>())).Returns(Task.FromResult(new UnitMeasure()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new UnitMeasure()));
			var service = new UnitMeasureService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLUnitMeasureMapperMock,
			                                     mock.DALMapperMockFactory.DALUnitMeasureMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                     mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                     mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                     mock.DALMapperMockFactory.DALProductMapperMock);

			UpdateResponse<ApiUnitMeasureServerResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiUnitMeasureServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<UnitMeasure>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IUnitMeasureRepository>();
			var model = new ApiUnitMeasureServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
			var service = new UnitMeasureService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLUnitMeasureMapperMock,
			                                     mock.DALMapperMockFactory.DALUnitMeasureMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                     mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                     mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                     mock.DALMapperMockFactory.DALProductMapperMock);

			ActionResponse response = await service.Delete(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
			mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IUnitMeasureRepository>();
			var record = new UnitMeasure();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new UnitMeasureService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLUnitMeasureMapperMock,
			                                     mock.DALMapperMockFactory.DALUnitMeasureMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                     mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                     mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                     mock.DALMapperMockFactory.DALProductMapperMock);

			ApiUnitMeasureServerResponseModel response = await service.ByName("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUnitMeasureRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<UnitMeasure>(null));
			var service = new UnitMeasureService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLUnitMeasureMapperMock,
			                                     mock.DALMapperMockFactory.DALUnitMeasureMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                     mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                     mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                     mock.DALMapperMockFactory.DALProductMapperMock);

			ApiUnitMeasureServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void BillOfMaterialsByUnitMeasureCode_Exists()
		{
			var mock = new ServiceMockFacade<IUnitMeasureRepository>();
			var records = new List<BillOfMaterial>();
			records.Add(new BillOfMaterial());
			mock.RepositoryMock.Setup(x => x.BillOfMaterialsByUnitMeasureCode(default(string), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UnitMeasureService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLUnitMeasureMapperMock,
			                                     mock.DALMapperMockFactory.DALUnitMeasureMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                     mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                     mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                     mock.DALMapperMockFactory.DALProductMapperMock);

			List<ApiBillOfMaterialServerResponseModel> response = await service.BillOfMaterialsByUnitMeasureCode(default(string));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.BillOfMaterialsByUnitMeasureCode(default(string), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void BillOfMaterialsByUnitMeasureCode_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUnitMeasureRepository>();
			mock.RepositoryMock.Setup(x => x.BillOfMaterialsByUnitMeasureCode(default(string), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<BillOfMaterial>>(new List<BillOfMaterial>()));
			var service = new UnitMeasureService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLUnitMeasureMapperMock,
			                                     mock.DALMapperMockFactory.DALUnitMeasureMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                     mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                     mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                     mock.DALMapperMockFactory.DALProductMapperMock);

			List<ApiBillOfMaterialServerResponseModel> response = await service.BillOfMaterialsByUnitMeasureCode(default(string));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.BillOfMaterialsByUnitMeasureCode(default(string), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductsBySizeUnitMeasureCode_Exists()
		{
			var mock = new ServiceMockFacade<IUnitMeasureRepository>();
			var records = new List<Product>();
			records.Add(new Product());
			mock.RepositoryMock.Setup(x => x.ProductsBySizeUnitMeasureCode(default(string), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UnitMeasureService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLUnitMeasureMapperMock,
			                                     mock.DALMapperMockFactory.DALUnitMeasureMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                     mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                     mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                     mock.DALMapperMockFactory.DALProductMapperMock);

			List<ApiProductServerResponseModel> response = await service.ProductsBySizeUnitMeasureCode(default(string));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductsBySizeUnitMeasureCode(default(string), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductsBySizeUnitMeasureCode_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUnitMeasureRepository>();
			mock.RepositoryMock.Setup(x => x.ProductsBySizeUnitMeasureCode(default(string), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Product>>(new List<Product>()));
			var service = new UnitMeasureService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLUnitMeasureMapperMock,
			                                     mock.DALMapperMockFactory.DALUnitMeasureMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                     mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                     mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                     mock.DALMapperMockFactory.DALProductMapperMock);

			List<ApiProductServerResponseModel> response = await service.ProductsBySizeUnitMeasureCode(default(string));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductsBySizeUnitMeasureCode(default(string), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductsByWeightUnitMeasureCode_Exists()
		{
			var mock = new ServiceMockFacade<IUnitMeasureRepository>();
			var records = new List<Product>();
			records.Add(new Product());
			mock.RepositoryMock.Setup(x => x.ProductsByWeightUnitMeasureCode(default(string), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UnitMeasureService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLUnitMeasureMapperMock,
			                                     mock.DALMapperMockFactory.DALUnitMeasureMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                     mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                     mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                     mock.DALMapperMockFactory.DALProductMapperMock);

			List<ApiProductServerResponseModel> response = await service.ProductsByWeightUnitMeasureCode(default(string));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductsByWeightUnitMeasureCode(default(string), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductsByWeightUnitMeasureCode_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUnitMeasureRepository>();
			mock.RepositoryMock.Setup(x => x.ProductsByWeightUnitMeasureCode(default(string), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Product>>(new List<Product>()));
			var service = new UnitMeasureService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLUnitMeasureMapperMock,
			                                     mock.DALMapperMockFactory.DALUnitMeasureMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                     mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                     mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                     mock.DALMapperMockFactory.DALProductMapperMock);

			List<ApiProductServerResponseModel> response = await service.ProductsByWeightUnitMeasureCode(default(string));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductsByWeightUnitMeasureCode(default(string), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>70ee6cd15fafd9a9a035c855dbd44063</Hash>
</Codenesium>*/