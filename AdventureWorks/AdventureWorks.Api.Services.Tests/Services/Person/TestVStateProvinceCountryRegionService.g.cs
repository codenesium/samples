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
	}
}

/*<Codenesium>
    <Hash>68d4fcc066c26e682b401f3071611ab1</Hash>
</Codenesium>*/