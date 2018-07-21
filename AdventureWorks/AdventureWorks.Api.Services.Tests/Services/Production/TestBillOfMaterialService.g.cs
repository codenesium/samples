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

                        List<ApiBillOfMaterialResponseModel> response = await service.All();

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

                        ApiBillOfMaterialResponseModel response = await service.Get(default(int));

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

                        ApiBillOfMaterialResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IBillOfMaterialRepository>();
                        var model = new ApiBillOfMaterialRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<BillOfMaterial>())).Returns(Task.FromResult(new BillOfMaterial()));
                        var service = new BillOfMaterialService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.BillOfMaterialModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
                                                                mock.DALMapperMockFactory.DALBillOfMaterialMapperMock);

                        CreateResponse<ApiBillOfMaterialResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.BillOfMaterialModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiBillOfMaterialRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<BillOfMaterial>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IBillOfMaterialRepository>();
                        var model = new ApiBillOfMaterialRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<BillOfMaterial>())).Returns(Task.FromResult(new BillOfMaterial()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new BillOfMaterial()));
                        var service = new BillOfMaterialService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.BillOfMaterialModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
                                                                mock.DALMapperMockFactory.DALBillOfMaterialMapperMock);

                        UpdateResponse<ApiBillOfMaterialResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.BillOfMaterialModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBillOfMaterialRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<BillOfMaterial>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IBillOfMaterialRepository>();
                        var model = new ApiBillOfMaterialRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new BillOfMaterialService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.BillOfMaterialModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
                                                                mock.DALMapperMockFactory.DALBillOfMaterialMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.BillOfMaterialModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByProductAssemblyIDComponentIDStartDate_Exists()
                {
                        var mock = new ServiceMockFacade<IBillOfMaterialRepository>();
                        var record = new BillOfMaterial();
                        mock.RepositoryMock.Setup(x => x.ByProductAssemblyIDComponentIDStartDate(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<DateTime>())).Returns(Task.FromResult(record));
                        var service = new BillOfMaterialService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.BillOfMaterialModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
                                                                mock.DALMapperMockFactory.DALBillOfMaterialMapperMock);

                        ApiBillOfMaterialResponseModel response = await service.ByProductAssemblyIDComponentIDStartDate(default(int?), default(int), default(DateTime));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByProductAssemblyIDComponentIDStartDate(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<DateTime>()));
                }

                [Fact]
                public async void ByProductAssemblyIDComponentIDStartDate_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IBillOfMaterialRepository>();
                        mock.RepositoryMock.Setup(x => x.ByProductAssemblyIDComponentIDStartDate(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<DateTime>())).Returns(Task.FromResult<BillOfMaterial>(null));
                        var service = new BillOfMaterialService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.BillOfMaterialModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
                                                                mock.DALMapperMockFactory.DALBillOfMaterialMapperMock);

                        ApiBillOfMaterialResponseModel response = await service.ByProductAssemblyIDComponentIDStartDate(default(int?), default(int), default(DateTime));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByProductAssemblyIDComponentIDStartDate(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<DateTime>()));
                }

                [Fact]
                public async void ByUnitMeasureCode_Exists()
                {
                        var mock = new ServiceMockFacade<IBillOfMaterialRepository>();
                        var records = new List<BillOfMaterial>();
                        records.Add(new BillOfMaterial());
                        mock.RepositoryMock.Setup(x => x.ByUnitMeasureCode(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new BillOfMaterialService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.BillOfMaterialModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
                                                                mock.DALMapperMockFactory.DALBillOfMaterialMapperMock);

                        List<ApiBillOfMaterialResponseModel> response = await service.ByUnitMeasureCode(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByUnitMeasureCode(It.IsAny<string>()));
                }

                [Fact]
                public async void ByUnitMeasureCode_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IBillOfMaterialRepository>();
                        mock.RepositoryMock.Setup(x => x.ByUnitMeasureCode(It.IsAny<string>())).Returns(Task.FromResult<List<BillOfMaterial>>(new List<BillOfMaterial>()));
                        var service = new BillOfMaterialService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.BillOfMaterialModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLBillOfMaterialMapperMock,
                                                                mock.DALMapperMockFactory.DALBillOfMaterialMapperMock);

                        List<ApiBillOfMaterialResponseModel> response = await service.ByUnitMeasureCode(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByUnitMeasureCode(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>565a3f0a86686cec2018f0a739605464</Hash>
</Codenesium>*/