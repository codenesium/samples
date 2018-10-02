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
	[Trait("Table", "VStateProvinceCountryRegion")]
	[Trait("Area", "Services")]
	public partial class VStateProvinceCountryRegionServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IVStateProvinceCountryRegionRepository>();
			var records = new List<VStateProvinceCountryRegion>();
			records.Add(new VStateProvinceCountryRegion());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VStateProvinceCountryRegionService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     mock.ModelValidatorMockFactory.VStateProvinceCountryRegionModelValidatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLVStateProvinceCountryRegionMapperMock,
			                                                     mock.DALMapperMockFactory.DALVStateProvinceCountryRegionMapperMock);

			List<ApiVStateProvinceCountryRegionResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IVStateProvinceCountryRegionRepository>();
			var record = new VStateProvinceCountryRegion();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VStateProvinceCountryRegionService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     mock.ModelValidatorMockFactory.VStateProvinceCountryRegionModelValidatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLVStateProvinceCountryRegionMapperMock,
			                                                     mock.DALMapperMockFactory.DALVStateProvinceCountryRegionMapperMock);

			ApiVStateProvinceCountryRegionResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IVStateProvinceCountryRegionRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<VStateProvinceCountryRegion>(null));
			var service = new VStateProvinceCountryRegionService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     mock.ModelValidatorMockFactory.VStateProvinceCountryRegionModelValidatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLVStateProvinceCountryRegionMapperMock,
			                                                     mock.DALMapperMockFactory.DALVStateProvinceCountryRegionMapperMock);

			ApiVStateProvinceCountryRegionResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IVStateProvinceCountryRegionRepository>();
			var model = new ApiVStateProvinceCountryRegionRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VStateProvinceCountryRegion>())).Returns(Task.FromResult(new VStateProvinceCountryRegion()));
			var service = new VStateProvinceCountryRegionService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     mock.ModelValidatorMockFactory.VStateProvinceCountryRegionModelValidatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLVStateProvinceCountryRegionMapperMock,
			                                                     mock.DALMapperMockFactory.DALVStateProvinceCountryRegionMapperMock);

			CreateResponse<ApiVStateProvinceCountryRegionResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.VStateProvinceCountryRegionModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVStateProvinceCountryRegionRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<VStateProvinceCountryRegion>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IVStateProvinceCountryRegionRepository>();
			var model = new ApiVStateProvinceCountryRegionRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VStateProvinceCountryRegion>())).Returns(Task.FromResult(new VStateProvinceCountryRegion()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VStateProvinceCountryRegion()));
			var service = new VStateProvinceCountryRegionService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     mock.ModelValidatorMockFactory.VStateProvinceCountryRegionModelValidatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLVStateProvinceCountryRegionMapperMock,
			                                                     mock.DALMapperMockFactory.DALVStateProvinceCountryRegionMapperMock);

			UpdateResponse<ApiVStateProvinceCountryRegionResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.VStateProvinceCountryRegionModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVStateProvinceCountryRegionRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<VStateProvinceCountryRegion>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IVStateProvinceCountryRegionRepository>();
			var model = new ApiVStateProvinceCountryRegionRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VStateProvinceCountryRegionService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     mock.ModelValidatorMockFactory.VStateProvinceCountryRegionModelValidatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLVStateProvinceCountryRegionMapperMock,
			                                                     mock.DALMapperMockFactory.DALVStateProvinceCountryRegionMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VStateProvinceCountryRegionModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByStateProvinceIDCountryRegionCode_Exists()
		{
			var mock = new ServiceMockFacade<IVStateProvinceCountryRegionRepository>();
			var record = new VStateProvinceCountryRegion();
			mock.RepositoryMock.Setup(x => x.ByStateProvinceIDCountryRegionCode(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new VStateProvinceCountryRegionService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     mock.ModelValidatorMockFactory.VStateProvinceCountryRegionModelValidatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLVStateProvinceCountryRegionMapperMock,
			                                                     mock.DALMapperMockFactory.DALVStateProvinceCountryRegionMapperMock);

			ApiVStateProvinceCountryRegionResponseModel response = await service.ByStateProvinceIDCountryRegionCode(default(int), default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByStateProvinceIDCountryRegionCode(It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ByStateProvinceIDCountryRegionCode_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVStateProvinceCountryRegionRepository>();
			mock.RepositoryMock.Setup(x => x.ByStateProvinceIDCountryRegionCode(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<VStateProvinceCountryRegion>(null));
			var service = new VStateProvinceCountryRegionService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     mock.ModelValidatorMockFactory.VStateProvinceCountryRegionModelValidatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLVStateProvinceCountryRegionMapperMock,
			                                                     mock.DALMapperMockFactory.DALVStateProvinceCountryRegionMapperMock);

			ApiVStateProvinceCountryRegionResponseModel response = await service.ByStateProvinceIDCountryRegionCode(default(int), default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByStateProvinceIDCountryRegionCode(It.IsAny<int>(), It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>28faf24acacc48e3e8d9ce404a94d774</Hash>
</Codenesium>*/