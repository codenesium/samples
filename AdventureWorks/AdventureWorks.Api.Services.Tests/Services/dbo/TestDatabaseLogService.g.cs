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
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "DatabaseLog")]
	[Trait("Area", "Services")]
	public partial class DatabaseLogServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IDatabaseLogRepository>();
			var records = new List<DatabaseLog>();
			records.Add(new DatabaseLog());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new DatabaseLogService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DatabaseLogModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDatabaseLogMapperMock,
			                                     mock.DALMapperMockFactory.DALDatabaseLogMapperMock);

			List<ApiDatabaseLogServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IDatabaseLogRepository>();
			var record = new DatabaseLog();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new DatabaseLogService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DatabaseLogModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDatabaseLogMapperMock,
			                                     mock.DALMapperMockFactory.DALDatabaseLogMapperMock);

			ApiDatabaseLogServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IDatabaseLogRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<DatabaseLog>(null));
			var service = new DatabaseLogService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DatabaseLogModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDatabaseLogMapperMock,
			                                     mock.DALMapperMockFactory.DALDatabaseLogMapperMock);

			ApiDatabaseLogServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IDatabaseLogRepository>();
			var model = new ApiDatabaseLogServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DatabaseLog>())).Returns(Task.FromResult(new DatabaseLog()));
			var service = new DatabaseLogService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DatabaseLogModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDatabaseLogMapperMock,
			                                     mock.DALMapperMockFactory.DALDatabaseLogMapperMock);

			CreateResponse<ApiDatabaseLogServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.DatabaseLogModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDatabaseLogServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<DatabaseLog>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IDatabaseLogRepository>();
			var model = new ApiDatabaseLogServerRequestModel();
			var validatorMock = new Mock<IApiDatabaseLogServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDatabaseLogServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new DatabaseLogService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDatabaseLogMapperMock,
			                                     mock.DALMapperMockFactory.DALDatabaseLogMapperMock);

			CreateResponse<ApiDatabaseLogServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDatabaseLogServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IDatabaseLogRepository>();
			var model = new ApiDatabaseLogServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DatabaseLog>())).Returns(Task.FromResult(new DatabaseLog()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));
			var service = new DatabaseLogService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DatabaseLogModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDatabaseLogMapperMock,
			                                     mock.DALMapperMockFactory.DALDatabaseLogMapperMock);

			UpdateResponse<ApiDatabaseLogServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.DatabaseLogModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDatabaseLogServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<DatabaseLog>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IDatabaseLogRepository>();
			var model = new ApiDatabaseLogServerRequestModel();
			var validatorMock = new Mock<IApiDatabaseLogServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDatabaseLogServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DatabaseLog()));
			var service = new DatabaseLogService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDatabaseLogMapperMock,
			                                     mock.DALMapperMockFactory.DALDatabaseLogMapperMock);

			UpdateResponse<ApiDatabaseLogServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDatabaseLogServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IDatabaseLogRepository>();
			var model = new ApiDatabaseLogServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new DatabaseLogService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DatabaseLogModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDatabaseLogMapperMock,
			                                     mock.DALMapperMockFactory.DALDatabaseLogMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.DatabaseLogModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IDatabaseLogRepository>();
			var model = new ApiDatabaseLogServerRequestModel();
			var validatorMock = new Mock<IApiDatabaseLogServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new DatabaseLogService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLDatabaseLogMapperMock,
			                                     mock.DALMapperMockFactory.DALDatabaseLogMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>65d23f464c279f44d71b883a4933db52</Hash>
</Codenesium>*/