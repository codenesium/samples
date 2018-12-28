using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
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
			                                            mock.MediatorMock.Object,
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
			                                            mock.MediatorMock.Object,
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
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.CountryRequirementModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
			                                            mock.DALMapperMockFactory.DALCountryRequirementMapperMock);

			ApiCountryRequirementServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ICountryRequirementRepository>();
			var model = new ApiCountryRequirementServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CountryRequirement>())).Returns(Task.FromResult(new CountryRequirement()));
			var service = new CountryRequirementService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.CountryRequirementModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
			                                            mock.DALMapperMockFactory.DALCountryRequirementMapperMock);

			CreateResponse<ApiCountryRequirementServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CountryRequirementModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCountryRequirementServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<CountryRequirement>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CountryRequirementCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ICountryRequirementRepository>();
			var model = new ApiCountryRequirementServerRequestModel();
			var validatorMock = new Mock<IApiCountryRequirementServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCountryRequirementServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CountryRequirementService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            validatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
			                                            mock.DALMapperMockFactory.DALCountryRequirementMapperMock);

			CreateResponse<ApiCountryRequirementServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCountryRequirementServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CountryRequirementCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ICountryRequirementRepository>();
			var model = new ApiCountryRequirementServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CountryRequirement>())).Returns(Task.FromResult(new CountryRequirement()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CountryRequirement()));
			var service = new CountryRequirementService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.CountryRequirementModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
			                                            mock.DALMapperMockFactory.DALCountryRequirementMapperMock);

			UpdateResponse<ApiCountryRequirementServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CountryRequirementModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCountryRequirementServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<CountryRequirement>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CountryRequirementUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ICountryRequirementRepository>();
			var model = new ApiCountryRequirementServerRequestModel();
			var validatorMock = new Mock<IApiCountryRequirementServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCountryRequirementServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CountryRequirement()));
			var service = new CountryRequirementService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            validatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
			                                            mock.DALMapperMockFactory.DALCountryRequirementMapperMock);

			UpdateResponse<ApiCountryRequirementServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCountryRequirementServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CountryRequirementUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ICountryRequirementRepository>();
			var model = new ApiCountryRequirementServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CountryRequirementService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.CountryRequirementModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
			                                            mock.DALMapperMockFactory.DALCountryRequirementMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CountryRequirementModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CountryRequirementDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ICountryRequirementRepository>();
			var model = new ApiCountryRequirementServerRequestModel();
			var validatorMock = new Mock<IApiCountryRequirementServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CountryRequirementService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            validatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
			                                            mock.DALMapperMockFactory.DALCountryRequirementMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CountryRequirementDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>ffa7714f7632e9f2991b7fd8337cbb6e</Hash>
</Codenesium>*/