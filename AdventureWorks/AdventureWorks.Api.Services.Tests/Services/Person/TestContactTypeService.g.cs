using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ContactType")]
	[Trait("Area", "Services")]
	public partial class ContactTypeServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IContactTypeRepository>();
			var records = new List<ContactType>();
			records.Add(new ContactType());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ContactTypeService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLContactTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALContactTypeMapperMock);

			List<ApiContactTypeServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IContactTypeRepository>();
			var record = new ContactType();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ContactTypeService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLContactTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALContactTypeMapperMock);

			ApiContactTypeServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IContactTypeRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ContactType>(null));
			var service = new ContactTypeService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLContactTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALContactTypeMapperMock);

			ApiContactTypeServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IContactTypeRepository>();
			var model = new ApiContactTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ContactType>())).Returns(Task.FromResult(new ContactType()));
			var service = new ContactTypeService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLContactTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALContactTypeMapperMock);

			CreateResponse<ApiContactTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiContactTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ContactType>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ContactTypeCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IContactTypeRepository>();
			var model = new ApiContactTypeServerRequestModel();
			var validatorMock = new Mock<IApiContactTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiContactTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ContactTypeService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLContactTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALContactTypeMapperMock);

			CreateResponse<ApiContactTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiContactTypeServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ContactTypeCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IContactTypeRepository>();
			var model = new ApiContactTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ContactType>())).Returns(Task.FromResult(new ContactType()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ContactType()));
			var service = new ContactTypeService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLContactTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALContactTypeMapperMock);

			UpdateResponse<ApiContactTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiContactTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ContactType>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ContactTypeUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IContactTypeRepository>();
			var model = new ApiContactTypeServerRequestModel();
			var validatorMock = new Mock<IApiContactTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiContactTypeServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ContactType()));
			var service = new ContactTypeService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLContactTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALContactTypeMapperMock);

			UpdateResponse<ApiContactTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiContactTypeServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ContactTypeUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IContactTypeRepository>();
			var model = new ApiContactTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ContactTypeService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLContactTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALContactTypeMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ContactTypeDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IContactTypeRepository>();
			var model = new ApiContactTypeServerRequestModel();
			var validatorMock = new Mock<IApiContactTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ContactTypeService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLContactTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALContactTypeMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ContactTypeDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IContactTypeRepository>();
			var record = new ContactType();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ContactTypeService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLContactTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALContactTypeMapperMock);

			ApiContactTypeServerResponseModel response = await service.ByName("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IContactTypeRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ContactType>(null));
			var service = new ContactTypeService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ContactTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLContactTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALContactTypeMapperMock);

			ApiContactTypeServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>7e70288a68eb8b10a56121e2bc202ba5</Hash>
</Codenesium>*/