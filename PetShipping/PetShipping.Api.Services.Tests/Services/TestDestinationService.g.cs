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
	[Trait("Table", "Destination")]
	[Trait("Area", "Services")]
	public partial class DestinationServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IDestinationRepository>();
			var records = new List<Destination>();
			records.Add(new Destination());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new DestinationService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DestinationModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDestinationMapperMock,
			                                     mock.DALMapperMockFactory.DALDestinationMapperMock);

			List<ApiDestinationResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IDestinationRepository>();
			var record = new Destination();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new DestinationService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DestinationModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDestinationMapperMock,
			                                     mock.DALMapperMockFactory.DALDestinationMapperMock);

			ApiDestinationResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IDestinationRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Destination>(null));
			var service = new DestinationService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DestinationModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDestinationMapperMock,
			                                     mock.DALMapperMockFactory.DALDestinationMapperMock);

			ApiDestinationResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IDestinationRepository>();
			var model = new ApiDestinationRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Destination>())).Returns(Task.FromResult(new Destination()));
			var service = new DestinationService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DestinationModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDestinationMapperMock,
			                                     mock.DALMapperMockFactory.DALDestinationMapperMock);

			CreateResponse<ApiDestinationResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.DestinationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDestinationRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Destination>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IDestinationRepository>();
			var model = new ApiDestinationRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Destination>())).Returns(Task.FromResult(new Destination()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Destination()));
			var service = new DestinationService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DestinationModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDestinationMapperMock,
			                                     mock.DALMapperMockFactory.DALDestinationMapperMock);

			UpdateResponse<ApiDestinationResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.DestinationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDestinationRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Destination>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IDestinationRepository>();
			var model = new ApiDestinationRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new DestinationService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DestinationModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDestinationMapperMock,
			                                     mock.DALMapperMockFactory.DALDestinationMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.DestinationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>5e547323b0fa6f1f8c24f0ec5ccc79c1</Hash>
</Codenesium>*/