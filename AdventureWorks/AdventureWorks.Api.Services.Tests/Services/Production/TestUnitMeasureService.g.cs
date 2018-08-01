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

			List<ApiUnitMeasureResponseModel> response = await service.All();

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

			ApiUnitMeasureResponseModel response = await service.Get(default(string));

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

			ApiUnitMeasureResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IUnitMeasureRepository>();
			var model = new ApiUnitMeasureRequestModel();
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

			CreateResponse<ApiUnitMeasureResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiUnitMeasureRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<UnitMeasure>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IUnitMeasureRepository>();
			var model = new ApiUnitMeasureRequestModel();
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

			UpdateResponse<ApiUnitMeasureResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiUnitMeasureRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<UnitMeasure>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IUnitMeasureRepository>();
			var model = new ApiUnitMeasureRequestModel();
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

			ApiUnitMeasureResponseModel response = await service.ByName(default(string));

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

			ApiUnitMeasureResponseModel response = await service.ByName(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void BillOfMaterials_Exists()
		{
			var mock = new ServiceMockFacade<IUnitMeasureRepository>();
			var records = new List<BillOfMaterial>();
			records.Add(new BillOfMaterial());
			mock.RepositoryMock.Setup(x => x.BillOfMaterials(default(string), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UnitMeasureService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLUnitMeasureMapperMock,
			                                     mock.DALMapperMockFactory.DALUnitMeasureMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                     mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                     mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                     mock.DALMapperMockFactory.DALProductMapperMock);

			List<ApiBillOfMaterialResponseModel> response = await service.BillOfMaterials(default(string));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.BillOfMaterials(default(string), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void BillOfMaterials_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUnitMeasureRepository>();
			mock.RepositoryMock.Setup(x => x.BillOfMaterials(default(string), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<BillOfMaterial>>(new List<BillOfMaterial>()));
			var service = new UnitMeasureService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLUnitMeasureMapperMock,
			                                     mock.DALMapperMockFactory.DALUnitMeasureMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                     mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                     mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                     mock.DALMapperMockFactory.DALProductMapperMock);

			List<ApiBillOfMaterialResponseModel> response = await service.BillOfMaterials(default(string));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.BillOfMaterials(default(string), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Products_Exists()
		{
			var mock = new ServiceMockFacade<IUnitMeasureRepository>();
			var records = new List<Product>();
			records.Add(new Product());
			mock.RepositoryMock.Setup(x => x.Products(default(string), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UnitMeasureService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLUnitMeasureMapperMock,
			                                     mock.DALMapperMockFactory.DALUnitMeasureMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                     mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                     mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                     mock.DALMapperMockFactory.DALProductMapperMock);

			List<ApiProductResponseModel> response = await service.Products(default(string));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Products(default(string), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Products_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUnitMeasureRepository>();
			mock.RepositoryMock.Setup(x => x.Products(default(string), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Product>>(new List<Product>()));
			var service = new UnitMeasureService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitMeasureModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLUnitMeasureMapperMock,
			                                     mock.DALMapperMockFactory.DALUnitMeasureMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
			                                     mock.DALMapperMockFactory.DALBillOfMaterialMapperMock,
			                                     mock.BOLMapperMockFactory.BOLProductMapperMock,
			                                     mock.DALMapperMockFactory.DALProductMapperMock);

			List<ApiProductResponseModel> response = await service.Products(default(string));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Products(default(string), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>659e35689db937a55b14a647460ecbf8</Hash>
</Codenesium>*/