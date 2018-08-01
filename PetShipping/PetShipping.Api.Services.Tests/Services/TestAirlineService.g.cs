using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Airline")]
	[Trait("Area", "Services")]
	public partial class AirlineServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IAirlineRepository>();
			var records = new List<Airline>();
			records.Add(new Airline());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new AirlineService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AirlineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAirlineMapperMock,
			                                 mock.DALMapperMockFactory.DALAirlineMapperMock);

			List<ApiAirlineResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IAirlineRepository>();
			var record = new Airline();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new AirlineService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AirlineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAirlineMapperMock,
			                                 mock.DALMapperMockFactory.DALAirlineMapperMock);

			ApiAirlineResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IAirlineRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Airline>(null));
			var service = new AirlineService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AirlineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAirlineMapperMock,
			                                 mock.DALMapperMockFactory.DALAirlineMapperMock);

			ApiAirlineResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IAirlineRepository>();
			var model = new ApiAirlineRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Airline>())).Returns(Task.FromResult(new Airline()));
			var service = new AirlineService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AirlineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAirlineMapperMock,
			                                 mock.DALMapperMockFactory.DALAirlineMapperMock);

			CreateResponse<ApiAirlineResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.AirlineModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiAirlineRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Airline>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IAirlineRepository>();
			var model = new ApiAirlineRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Airline>())).Returns(Task.FromResult(new Airline()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Airline()));
			var service = new AirlineService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AirlineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAirlineMapperMock,
			                                 mock.DALMapperMockFactory.DALAirlineMapperMock);

			UpdateResponse<ApiAirlineResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.AirlineModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAirlineRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Airline>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IAirlineRepository>();
			var model = new ApiAirlineRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new AirlineService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AirlineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAirlineMapperMock,
			                                 mock.DALMapperMockFactory.DALAirlineMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.AirlineModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>f7b4d1ddfa3dfabbd020579896f92a84</Hash>
</Codenesium>*/