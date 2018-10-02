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
	[Trait("Table", "VProductAndDescription")]
	[Trait("Area", "Services")]
	public partial class VProductAndDescriptionServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IVProductAndDescriptionRepository>();
			var records = new List<VProductAndDescription>();
			records.Add(new VProductAndDescription());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VProductAndDescriptionService(mock.LoggerMock.Object,
			                                                mock.RepositoryMock.Object,
			                                                mock.ModelValidatorMockFactory.VProductAndDescriptionModelValidatorMock.Object,
			                                                mock.BOLMapperMockFactory.BOLVProductAndDescriptionMapperMock,
			                                                mock.DALMapperMockFactory.DALVProductAndDescriptionMapperMock);

			List<ApiVProductAndDescriptionResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IVProductAndDescriptionRepository>();
			var record = new VProductAndDescription();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new VProductAndDescriptionService(mock.LoggerMock.Object,
			                                                mock.RepositoryMock.Object,
			                                                mock.ModelValidatorMockFactory.VProductAndDescriptionModelValidatorMock.Object,
			                                                mock.BOLMapperMockFactory.BOLVProductAndDescriptionMapperMock,
			                                                mock.DALMapperMockFactory.DALVProductAndDescriptionMapperMock);

			ApiVProductAndDescriptionResponseModel response = await service.Get(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IVProductAndDescriptionRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<VProductAndDescription>(null));
			var service = new VProductAndDescriptionService(mock.LoggerMock.Object,
			                                                mock.RepositoryMock.Object,
			                                                mock.ModelValidatorMockFactory.VProductAndDescriptionModelValidatorMock.Object,
			                                                mock.BOLMapperMockFactory.BOLVProductAndDescriptionMapperMock,
			                                                mock.DALMapperMockFactory.DALVProductAndDescriptionMapperMock);

			ApiVProductAndDescriptionResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IVProductAndDescriptionRepository>();
			var model = new ApiVProductAndDescriptionRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VProductAndDescription>())).Returns(Task.FromResult(new VProductAndDescription()));
			var service = new VProductAndDescriptionService(mock.LoggerMock.Object,
			                                                mock.RepositoryMock.Object,
			                                                mock.ModelValidatorMockFactory.VProductAndDescriptionModelValidatorMock.Object,
			                                                mock.BOLMapperMockFactory.BOLVProductAndDescriptionMapperMock,
			                                                mock.DALMapperMockFactory.DALVProductAndDescriptionMapperMock);

			CreateResponse<ApiVProductAndDescriptionResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.VProductAndDescriptionModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVProductAndDescriptionRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<VProductAndDescription>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IVProductAndDescriptionRepository>();
			var model = new ApiVProductAndDescriptionRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VProductAndDescription>())).Returns(Task.FromResult(new VProductAndDescription()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new VProductAndDescription()));
			var service = new VProductAndDescriptionService(mock.LoggerMock.Object,
			                                                mock.RepositoryMock.Object,
			                                                mock.ModelValidatorMockFactory.VProductAndDescriptionModelValidatorMock.Object,
			                                                mock.BOLMapperMockFactory.BOLVProductAndDescriptionMapperMock,
			                                                mock.DALMapperMockFactory.DALVProductAndDescriptionMapperMock);

			UpdateResponse<ApiVProductAndDescriptionResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.VProductAndDescriptionModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiVProductAndDescriptionRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<VProductAndDescription>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IVProductAndDescriptionRepository>();
			var model = new ApiVProductAndDescriptionRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
			var service = new VProductAndDescriptionService(mock.LoggerMock.Object,
			                                                mock.RepositoryMock.Object,
			                                                mock.ModelValidatorMockFactory.VProductAndDescriptionModelValidatorMock.Object,
			                                                mock.BOLMapperMockFactory.BOLVProductAndDescriptionMapperMock,
			                                                mock.DALMapperMockFactory.DALVProductAndDescriptionMapperMock);

			ActionResponse response = await service.Delete(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
			mock.ModelValidatorMockFactory.VProductAndDescriptionModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
		}

		[Fact]
		public async void ByCultureIDProductID_Exists()
		{
			var mock = new ServiceMockFacade<IVProductAndDescriptionRepository>();
			var record = new VProductAndDescription();
			mock.RepositoryMock.Setup(x => x.ByCultureIDProductID(It.IsAny<string>(), It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VProductAndDescriptionService(mock.LoggerMock.Object,
			                                                mock.RepositoryMock.Object,
			                                                mock.ModelValidatorMockFactory.VProductAndDescriptionModelValidatorMock.Object,
			                                                mock.BOLMapperMockFactory.BOLVProductAndDescriptionMapperMock,
			                                                mock.DALMapperMockFactory.DALVProductAndDescriptionMapperMock);

			ApiVProductAndDescriptionResponseModel response = await service.ByCultureIDProductID(default(string), default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByCultureIDProductID(It.IsAny<string>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByCultureIDProductID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVProductAndDescriptionRepository>();
			mock.RepositoryMock.Setup(x => x.ByCultureIDProductID(It.IsAny<string>(), It.IsAny<int>())).Returns(Task.FromResult<VProductAndDescription>(null));
			var service = new VProductAndDescriptionService(mock.LoggerMock.Object,
			                                                mock.RepositoryMock.Object,
			                                                mock.ModelValidatorMockFactory.VProductAndDescriptionModelValidatorMock.Object,
			                                                mock.BOLMapperMockFactory.BOLVProductAndDescriptionMapperMock,
			                                                mock.DALMapperMockFactory.DALVProductAndDescriptionMapperMock);

			ApiVProductAndDescriptionResponseModel response = await service.ByCultureIDProductID(default(string), default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByCultureIDProductID(It.IsAny<string>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>6cd2ac162957764e5ac5900938c492d0</Hash>
</Codenesium>*/