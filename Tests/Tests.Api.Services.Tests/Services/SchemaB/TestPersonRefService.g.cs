using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PersonRef")]
	[Trait("Area", "Services")]
	public partial class PersonRefServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPersonRefRepository>();
			var records = new List<PersonRef>();
			records.Add(new PersonRef());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PersonRefService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PersonRefModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                   mock.DALMapperMockFactory.DALPersonRefMapperMock);

			List<ApiPersonRefServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPersonRefRepository>();
			var record = new PersonRef();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PersonRefService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PersonRefModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                   mock.DALMapperMockFactory.DALPersonRefMapperMock);

			ApiPersonRefServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPersonRefRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PersonRef>(null));
			var service = new PersonRefService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PersonRefModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                   mock.DALMapperMockFactory.DALPersonRefMapperMock);

			ApiPersonRefServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IPersonRefRepository>();
			var model = new ApiPersonRefServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PersonRef>())).Returns(Task.FromResult(new PersonRef()));
			var service = new PersonRefService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PersonRefModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                   mock.DALMapperMockFactory.DALPersonRefMapperMock);

			CreateResponse<ApiPersonRefServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PersonRefModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPersonRefServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PersonRef>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonRefCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IPersonRefRepository>();
			var model = new ApiPersonRefServerRequestModel();
			var validatorMock = new Mock<IApiPersonRefServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPersonRefServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PersonRefService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                   mock.DALMapperMockFactory.DALPersonRefMapperMock);

			CreateResponse<ApiPersonRefServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPersonRefServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonRefCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IPersonRefRepository>();
			var model = new ApiPersonRefServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PersonRef>())).Returns(Task.FromResult(new PersonRef()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PersonRef()));
			var service = new PersonRefService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PersonRefModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                   mock.DALMapperMockFactory.DALPersonRefMapperMock);

			UpdateResponse<ApiPersonRefServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PersonRefModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonRefServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PersonRef>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonRefUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IPersonRefRepository>();
			var model = new ApiPersonRefServerRequestModel();
			var validatorMock = new Mock<IApiPersonRefServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonRefServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PersonRef()));
			var service = new PersonRefService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                   mock.DALMapperMockFactory.DALPersonRefMapperMock);

			UpdateResponse<ApiPersonRefServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonRefServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonRefUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IPersonRefRepository>();
			var model = new ApiPersonRefServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PersonRefService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PersonRefModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                   mock.DALMapperMockFactory.DALPersonRefMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PersonRefModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonRefDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IPersonRefRepository>();
			var model = new ApiPersonRefServerRequestModel();
			var validatorMock = new Mock<IApiPersonRefServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PersonRefService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                   mock.DALMapperMockFactory.DALPersonRefMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonRefDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>2471f2ebb8a525c6c709a3f785aa5b9d</Hash>
</Codenesium>*/