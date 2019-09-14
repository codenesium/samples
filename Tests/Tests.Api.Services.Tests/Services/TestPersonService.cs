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
	[Trait("Table", "Person")]
	[Trait("Area", "Services")]
	public partial class PersonServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IPersonService, IPersonRepository>();
			var records = new List<Person>();
			records.Add(new Person());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			List<ApiPersonServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IPersonService, IPersonRepository>();
			var record = new Person();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			ApiPersonServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IPersonService, IPersonRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Person>(null));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			ApiPersonServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPersonService, IPersonRepository>();

			var model = new ApiPersonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Person>())).Returns(Task.FromResult(new Person()));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			CreateResponse<ApiPersonServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PersonModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPersonServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Person>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPersonService, IPersonRepository>();
			var model = new ApiPersonServerRequestModel();
			var validatorMock = new Mock<IApiPersonServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPersonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			CreateResponse<ApiPersonServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPersonServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPersonService, IPersonRepository>();
			var model = new ApiPersonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Person>())).Returns(Task.FromResult(new Person()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			UpdateResponse<ApiPersonServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PersonModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Person>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPersonService, IPersonRepository>();
			var model = new ApiPersonServerRequestModel();
			var validatorMock = new Mock<IApiPersonServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			UpdateResponse<ApiPersonServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPersonService, IPersonRepository>();
			var model = new ApiPersonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PersonModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPersonService, IPersonRepository>();
			var model = new ApiPersonServerRequestModel();
			var validatorMock = new Mock<IApiPersonServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PersonDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ColumnSameAsFKTablesByPerson_Exists()
		{
			var mock = new ServiceMockFacade<IPersonService, IPersonRepository>();
			var records = new List<ColumnSameAsFKTable>();
			records.Add(new ColumnSameAsFKTable());
			mock.RepositoryMock.Setup(x => x.ColumnSameAsFKTablesByPerson(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			List<ApiColumnSameAsFKTableServerResponseModel> response = await service.ColumnSameAsFKTablesByPerson(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ColumnSameAsFKTablesByPerson(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ColumnSameAsFKTablesByPerson_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPersonService, IPersonRepository>();
			mock.RepositoryMock.Setup(x => x.ColumnSameAsFKTablesByPerson(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ColumnSameAsFKTable>>(new List<ColumnSameAsFKTable>()));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			List<ApiColumnSameAsFKTableServerResponseModel> response = await service.ColumnSameAsFKTablesByPerson(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ColumnSameAsFKTablesByPerson(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ColumnSameAsFKTablesByPersonId_Exists()
		{
			var mock = new ServiceMockFacade<IPersonService, IPersonRepository>();
			var records = new List<ColumnSameAsFKTable>();
			records.Add(new ColumnSameAsFKTable());
			mock.RepositoryMock.Setup(x => x.ColumnSameAsFKTablesByPersonId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			List<ApiColumnSameAsFKTableServerResponseModel> response = await service.ColumnSameAsFKTablesByPersonId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ColumnSameAsFKTablesByPersonId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ColumnSameAsFKTablesByPersonId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPersonService, IPersonRepository>();
			mock.RepositoryMock.Setup(x => x.ColumnSameAsFKTablesByPersonId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ColumnSameAsFKTable>>(new List<ColumnSameAsFKTable>()));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			List<ApiColumnSameAsFKTableServerResponseModel> response = await service.ColumnSameAsFKTablesByPersonId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ColumnSameAsFKTablesByPersonId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>9a01c042dbfd5e3bede275ddaf38adf4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/