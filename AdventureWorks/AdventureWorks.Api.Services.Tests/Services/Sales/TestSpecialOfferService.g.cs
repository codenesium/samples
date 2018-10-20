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
	[Trait("Table", "SpecialOffer")]
	[Trait("Area", "Services")]
	public partial class SpecialOfferServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISpecialOfferRepository>();
			var records = new List<SpecialOffer>();
			records.Add(new SpecialOffer());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SpecialOfferService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SpecialOfferModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSpecialOfferMapperMock,
			                                      mock.DALMapperMockFactory.DALSpecialOfferMapperMock);

			List<ApiSpecialOfferResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISpecialOfferRepository>();
			var record = new SpecialOffer();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SpecialOfferService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SpecialOfferModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSpecialOfferMapperMock,
			                                      mock.DALMapperMockFactory.DALSpecialOfferMapperMock);

			ApiSpecialOfferResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISpecialOfferRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SpecialOffer>(null));
			var service = new SpecialOfferService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SpecialOfferModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSpecialOfferMapperMock,
			                                      mock.DALMapperMockFactory.DALSpecialOfferMapperMock);

			ApiSpecialOfferResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ISpecialOfferRepository>();
			var model = new ApiSpecialOfferRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SpecialOffer>())).Returns(Task.FromResult(new SpecialOffer()));
			var service = new SpecialOfferService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SpecialOfferModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSpecialOfferMapperMock,
			                                      mock.DALMapperMockFactory.DALSpecialOfferMapperMock);

			CreateResponse<ApiSpecialOfferResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SpecialOfferModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSpecialOfferRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SpecialOffer>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ISpecialOfferRepository>();
			var model = new ApiSpecialOfferRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SpecialOffer>())).Returns(Task.FromResult(new SpecialOffer()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));
			var service = new SpecialOfferService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SpecialOfferModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSpecialOfferMapperMock,
			                                      mock.DALMapperMockFactory.DALSpecialOfferMapperMock);

			UpdateResponse<ApiSpecialOfferResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SpecialOfferModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpecialOfferRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SpecialOffer>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ISpecialOfferRepository>();
			var model = new ApiSpecialOfferRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SpecialOfferService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SpecialOfferModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSpecialOfferMapperMock,
			                                      mock.DALMapperMockFactory.DALSpecialOfferMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SpecialOfferModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>25db8811df9fc944c9d7db2cbda7e31b</Hash>
</Codenesium>*/