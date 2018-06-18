using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "BillOfMaterials")]
        [Trait("Area", "Services")]
        public partial class BillOfMaterialsServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IBillOfMaterialsRepository>();
                        var records = new List<BillOfMaterials>();
                        records.Add(new BillOfMaterials());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new BillOfMaterialsService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.BillOfMaterialsModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLBillOfMaterialsMapperMock,
                                                                 mock.DALMapperMockFactory.DALBillOfMaterialsMapperMock);

                        List<ApiBillOfMaterialsResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IBillOfMaterialsRepository>();
                        var record = new BillOfMaterials();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new BillOfMaterialsService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.BillOfMaterialsModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLBillOfMaterialsMapperMock,
                                                                 mock.DALMapperMockFactory.DALBillOfMaterialsMapperMock);

                        ApiBillOfMaterialsResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IBillOfMaterialsRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<BillOfMaterials>(null));
                        var service = new BillOfMaterialsService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.BillOfMaterialsModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLBillOfMaterialsMapperMock,
                                                                 mock.DALMapperMockFactory.DALBillOfMaterialsMapperMock);

                        ApiBillOfMaterialsResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IBillOfMaterialsRepository>();
                        var model = new ApiBillOfMaterialsRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<BillOfMaterials>())).Returns(Task.FromResult(new BillOfMaterials()));
                        var service = new BillOfMaterialsService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.BillOfMaterialsModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLBillOfMaterialsMapperMock,
                                                                 mock.DALMapperMockFactory.DALBillOfMaterialsMapperMock);

                        CreateResponse<ApiBillOfMaterialsResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.BillOfMaterialsModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiBillOfMaterialsRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<BillOfMaterials>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IBillOfMaterialsRepository>();
                        var model = new ApiBillOfMaterialsRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<BillOfMaterials>())).Returns(Task.FromResult(new BillOfMaterials()));
                        var service = new BillOfMaterialsService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.BillOfMaterialsModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLBillOfMaterialsMapperMock,
                                                                 mock.DALMapperMockFactory.DALBillOfMaterialsMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.BillOfMaterialsModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBillOfMaterialsRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<BillOfMaterials>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IBillOfMaterialsRepository>();
                        var model = new ApiBillOfMaterialsRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new BillOfMaterialsService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.BillOfMaterialsModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLBillOfMaterialsMapperMock,
                                                                 mock.DALMapperMockFactory.DALBillOfMaterialsMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.BillOfMaterialsModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByProductAssemblyIDComponentIDStartDate_Exists()
                {
                        var mock = new ServiceMockFacade<IBillOfMaterialsRepository>();
                        var record = new BillOfMaterials();

                        mock.RepositoryMock.Setup(x => x.ByProductAssemblyIDComponentIDStartDate(It.IsAny<Nullable<int>>(), It.IsAny<int>(), It.IsAny<DateTime>())).Returns(Task.FromResult(record));
                        var service = new BillOfMaterialsService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.BillOfMaterialsModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLBillOfMaterialsMapperMock,
                                                                 mock.DALMapperMockFactory.DALBillOfMaterialsMapperMock);

                        ApiBillOfMaterialsResponseModel response = await service.ByProductAssemblyIDComponentIDStartDate(default (Nullable<int>), default (int), default (DateTime));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByProductAssemblyIDComponentIDStartDate(It.IsAny<Nullable<int>>(), It.IsAny<int>(), It.IsAny<DateTime>()));
                }

                [Fact]
                public async void ByProductAssemblyIDComponentIDStartDate_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IBillOfMaterialsRepository>();
                        mock.RepositoryMock.Setup(x => x.ByProductAssemblyIDComponentIDStartDate(It.IsAny<Nullable<int>>(), It.IsAny<int>(), It.IsAny<DateTime>())).Returns(Task.FromResult<BillOfMaterials>(null));
                        var service = new BillOfMaterialsService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.BillOfMaterialsModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLBillOfMaterialsMapperMock,
                                                                 mock.DALMapperMockFactory.DALBillOfMaterialsMapperMock);

                        ApiBillOfMaterialsResponseModel response = await service.ByProductAssemblyIDComponentIDStartDate(default (Nullable<int>), default (int), default (DateTime));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByProductAssemblyIDComponentIDStartDate(It.IsAny<Nullable<int>>(), It.IsAny<int>(), It.IsAny<DateTime>()));
                }

                [Fact]
                public async void ByUnitMeasureCode_Exists()
                {
                        var mock = new ServiceMockFacade<IBillOfMaterialsRepository>();
                        var records = new List<BillOfMaterials>();
                        records.Add(new BillOfMaterials());
                        mock.RepositoryMock.Setup(x => x.ByUnitMeasureCode(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new BillOfMaterialsService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.BillOfMaterialsModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLBillOfMaterialsMapperMock,
                                                                 mock.DALMapperMockFactory.DALBillOfMaterialsMapperMock);

                        List<ApiBillOfMaterialsResponseModel> response = await service.ByUnitMeasureCode(default (string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByUnitMeasureCode(It.IsAny<string>()));
                }

                [Fact]
                public async void ByUnitMeasureCode_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IBillOfMaterialsRepository>();
                        mock.RepositoryMock.Setup(x => x.ByUnitMeasureCode(It.IsAny<string>())).Returns(Task.FromResult<List<BillOfMaterials>>(new List<BillOfMaterials>()));
                        var service = new BillOfMaterialsService(mock.LoggerMock.Object,
                                                                 mock.RepositoryMock.Object,
                                                                 mock.ModelValidatorMockFactory.BillOfMaterialsModelValidatorMock.Object,
                                                                 mock.BOLMapperMockFactory.BOLBillOfMaterialsMapperMock,
                                                                 mock.DALMapperMockFactory.DALBillOfMaterialsMapperMock);

                        List<ApiBillOfMaterialsResponseModel> response = await service.ByUnitMeasureCode(default (string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByUnitMeasureCode(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>8d0b934f896830fcdc8289e68ee7a1c6</Hash>
</Codenesium>*/