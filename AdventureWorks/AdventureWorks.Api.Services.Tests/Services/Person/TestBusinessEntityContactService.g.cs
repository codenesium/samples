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
        [Trait("Table", "BusinessEntityContact")]
        [Trait("Area", "Services")]
        public partial class BusinessEntityContactServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityContactRepository>();
                        var records = new List<BusinessEntityContact>();
                        records.Add(new BusinessEntityContact());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new BusinessEntityContactService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.BusinessEntityContactModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                       mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock);

                        List<ApiBusinessEntityContactResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityContactRepository>();
                        var record = new BusinessEntityContact();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new BusinessEntityContactService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.BusinessEntityContactModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                       mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock);

                        ApiBusinessEntityContactResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityContactRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<BusinessEntityContact>(null));
                        var service = new BusinessEntityContactService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.BusinessEntityContactModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                       mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock);

                        ApiBusinessEntityContactResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityContactRepository>();
                        var model = new ApiBusinessEntityContactRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<BusinessEntityContact>())).Returns(Task.FromResult(new BusinessEntityContact()));
                        var service = new BusinessEntityContactService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.BusinessEntityContactModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                       mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock);

                        CreateResponse<ApiBusinessEntityContactResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.BusinessEntityContactModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiBusinessEntityContactRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<BusinessEntityContact>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityContactRepository>();
                        var model = new ApiBusinessEntityContactRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<BusinessEntityContact>())).Returns(Task.FromResult(new BusinessEntityContact()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new BusinessEntityContact()));
                        var service = new BusinessEntityContactService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.BusinessEntityContactModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                       mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock);

                        UpdateResponse<ApiBusinessEntityContactResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.BusinessEntityContactModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBusinessEntityContactRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<BusinessEntityContact>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityContactRepository>();
                        var model = new ApiBusinessEntityContactRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new BusinessEntityContactService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.BusinessEntityContactModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                       mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.BusinessEntityContactModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByContactTypeID_Exists()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityContactRepository>();
                        var records = new List<BusinessEntityContact>();
                        records.Add(new BusinessEntityContact());
                        mock.RepositoryMock.Setup(x => x.ByContactTypeID(It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new BusinessEntityContactService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.BusinessEntityContactModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                       mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock);

                        List<ApiBusinessEntityContactResponseModel> response = await service.ByContactTypeID(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByContactTypeID(It.IsAny<int>()));
                }

                [Fact]
                public async void ByContactTypeID_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityContactRepository>();
                        mock.RepositoryMock.Setup(x => x.ByContactTypeID(It.IsAny<int>())).Returns(Task.FromResult<List<BusinessEntityContact>>(new List<BusinessEntityContact>()));
                        var service = new BusinessEntityContactService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.BusinessEntityContactModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                       mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock);

                        List<ApiBusinessEntityContactResponseModel> response = await service.ByContactTypeID(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByContactTypeID(It.IsAny<int>()));
                }

                [Fact]
                public async void ByPersonID_Exists()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityContactRepository>();
                        var records = new List<BusinessEntityContact>();
                        records.Add(new BusinessEntityContact());
                        mock.RepositoryMock.Setup(x => x.ByPersonID(It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new BusinessEntityContactService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.BusinessEntityContactModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                       mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock);

                        List<ApiBusinessEntityContactResponseModel> response = await service.ByPersonID(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByPersonID(It.IsAny<int>()));
                }

                [Fact]
                public async void ByPersonID_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityContactRepository>();
                        mock.RepositoryMock.Setup(x => x.ByPersonID(It.IsAny<int>())).Returns(Task.FromResult<List<BusinessEntityContact>>(new List<BusinessEntityContact>()));
                        var service = new BusinessEntityContactService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.BusinessEntityContactModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                       mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock);

                        List<ApiBusinessEntityContactResponseModel> response = await service.ByPersonID(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByPersonID(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>e8033f3031b6db4f2d76fcd65969533a</Hash>
</Codenesium>*/