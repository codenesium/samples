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
	[Trait("Table", "CountryRequirement")]
	[Trait("Area", "Services")]
	public partial class CountryRequirementServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ICountryRequirementRepository>();
			var records = new List<CountryRequirement>();
			records.Add(new CountryRequirement());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CountryRequirementService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.CountryRequirementModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
			                                            mock.DALMapperMockFactory.DALCountryRequirementMapperMock);

			List<ApiCountryRequirementServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ICountryRequirementRepository>();
			var record = new CountryRequirement();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CountryRequirementService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.CountryRequirementModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
			                                            mock.DALMapperMockFactory.DALCountryRequirementMapperMock);

			ApiCountryRequirementServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ICountryRequirementRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<CountryRequirement>(null));
			var service = new CountryRequirementService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.CountryRequirementModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
			                                            mock.DALMapperMockFactory.DALCountryRequirementMapperMock);

			ApiCountryRequirementServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ICountryRequirementRepository>();
			var model = new ApiCountryRequirementServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CountryRequirement>())).Returns(Task.FromResult(new CountryRequirement()));
			var service = new CountryRequirementService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.CountryRequirementModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
			                                            mock.DALMapperMockFactory.DALCountryRequirementMapperMock);

			CreateResponse<ApiCountryRequirementServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.CountryRequirementModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCountryRequirementServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<CountryRequirement>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ICountryRequirementRepository>();
			var model = new ApiCountryRequirementServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CountryRequirement>())).Returns(Task.FromResult(new CountryRequirement()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CountryRequirement()));
			var service = new CountryRequirementService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.CountryRequirementModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
			                                            mock.DALMapperMockFactory.DALCountryRequirementMapperMock);

			UpdateResponse<ApiCountryRequirementServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.CountryRequirementModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCountryRequirementServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<CountryRequirement>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ICountryRequirementRepository>();
			var model = new ApiCountryRequirementServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CountryRequirementService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.CountryRequirementModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
			                                            mock.DALMapperMockFactory.DALCountryRequirementMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CountryRequirementModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>28b671304b8f90ea37e907e4979709b2</Hash>
</Codenesium>*/