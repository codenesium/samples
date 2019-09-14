using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Organization")]
	[Trait("Area", "Services")]
	public partial class OrganizationServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IOrganizationService, IOrganizationRepository>();
			var records = new List<Organization>();
			records.Add(new Organization());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			List<ApiOrganizationServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IOrganizationService, IOrganizationRepository>();
			var record = new Organization();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			ApiOrganizationServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IOrganizationService, IOrganizationRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Organization>(null));
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			ApiOrganizationServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IOrganizationService, IOrganizationRepository>();

			var model = new ApiOrganizationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Organization>())).Returns(Task.FromResult(new Organization()));
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			CreateResponse<ApiOrganizationServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiOrganizationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Organization>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OrganizationCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IOrganizationService, IOrganizationRepository>();
			var model = new ApiOrganizationServerRequestModel();
			var validatorMock = new Mock<IApiOrganizationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiOrganizationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			CreateResponse<ApiOrganizationServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiOrganizationServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OrganizationCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IOrganizationService, IOrganizationRepository>();
			var model = new ApiOrganizationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Organization>())).Returns(Task.FromResult(new Organization()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Organization()));
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			UpdateResponse<ApiOrganizationServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOrganizationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Organization>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OrganizationUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IOrganizationService, IOrganizationRepository>();
			var model = new ApiOrganizationServerRequestModel();
			var validatorMock = new Mock<IApiOrganizationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOrganizationServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Organization()));
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			UpdateResponse<ApiOrganizationServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOrganizationServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OrganizationUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IOrganizationService, IOrganizationRepository>();
			var model = new ApiOrganizationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OrganizationDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IOrganizationService, IOrganizationRepository>();
			var model = new ApiOrganizationServerRequestModel();
			var validatorMock = new Mock<IApiOrganizationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OrganizationDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IOrganizationService, IOrganizationRepository>();
			var record = new Organization();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			ApiOrganizationServerResponseModel response = await service.ByName("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IOrganizationService, IOrganizationRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Organization>(null));
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			ApiOrganizationServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void TeamsByOrganizationId_Exists()
		{
			var mock = new ServiceMockFacade<IOrganizationService, IOrganizationRepository>();
			var records = new List<Team>();
			records.Add(new Team());
			mock.RepositoryMock.Setup(x => x.TeamsByOrganizationId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			List<ApiTeamServerResponseModel> response = await service.TeamsByOrganizationId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TeamsByOrganizationId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeamsByOrganizationId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IOrganizationService, IOrganizationRepository>();
			mock.RepositoryMock.Setup(x => x.TeamsByOrganizationId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Team>>(new List<Team>()));
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			List<ApiTeamServerResponseModel> response = await service.TeamsByOrganizationId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TeamsByOrganizationId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>b6cce14c4f57256e8a7e4e0c54fc9c0d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/