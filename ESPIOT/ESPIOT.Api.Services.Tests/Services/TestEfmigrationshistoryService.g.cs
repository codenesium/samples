using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
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

namespace ESPIOTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Efmigrationshistory")]
	[Trait("Area", "Services")]
	public partial class EfmigrationshistoryServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IEfmigrationshistoryRepository>();
			var records = new List<Efmigrationshistory>();
			records.Add(new Efmigrationshistory());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EfmigrationshistoryService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.EfmigrationshistoryModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLEfmigrationshistoryMapperMock,
			                                             mock.DALMapperMockFactory.DALEfmigrationshistoryMapperMock);

			List<ApiEfmigrationshistoryServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IEfmigrationshistoryRepository>();
			var record = new Efmigrationshistory();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new EfmigrationshistoryService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.EfmigrationshistoryModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLEfmigrationshistoryMapperMock,
			                                             mock.DALMapperMockFactory.DALEfmigrationshistoryMapperMock);

			ApiEfmigrationshistoryServerResponseModel response = await service.Get(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IEfmigrationshistoryRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Efmigrationshistory>(null));
			var service = new EfmigrationshistoryService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.EfmigrationshistoryModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLEfmigrationshistoryMapperMock,
			                                             mock.DALMapperMockFactory.DALEfmigrationshistoryMapperMock);

			ApiEfmigrationshistoryServerResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IEfmigrationshistoryRepository>();
			var model = new ApiEfmigrationshistoryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Efmigrationshistory>())).Returns(Task.FromResult(new Efmigrationshistory()));
			var service = new EfmigrationshistoryService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.EfmigrationshistoryModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLEfmigrationshistoryMapperMock,
			                                             mock.DALMapperMockFactory.DALEfmigrationshistoryMapperMock);

			CreateResponse<ApiEfmigrationshistoryServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.EfmigrationshistoryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEfmigrationshistoryServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Efmigrationshistory>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IEfmigrationshistoryRepository>();
			var model = new ApiEfmigrationshistoryServerRequestModel();
			var validatorMock = new Mock<IApiEfmigrationshistoryServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEfmigrationshistoryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new EfmigrationshistoryService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLEfmigrationshistoryMapperMock,
			                                             mock.DALMapperMockFactory.DALEfmigrationshistoryMapperMock);

			CreateResponse<ApiEfmigrationshistoryServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEfmigrationshistoryServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IEfmigrationshistoryRepository>();
			var model = new ApiEfmigrationshistoryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Efmigrationshistory>())).Returns(Task.FromResult(new Efmigrationshistory()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Efmigrationshistory()));
			var service = new EfmigrationshistoryService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.EfmigrationshistoryModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLEfmigrationshistoryMapperMock,
			                                             mock.DALMapperMockFactory.DALEfmigrationshistoryMapperMock);

			UpdateResponse<ApiEfmigrationshistoryServerResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.EfmigrationshistoryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiEfmigrationshistoryServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Efmigrationshistory>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IEfmigrationshistoryRepository>();
			var model = new ApiEfmigrationshistoryServerRequestModel();
			var validatorMock = new Mock<IApiEfmigrationshistoryServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiEfmigrationshistoryServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Efmigrationshistory()));
			var service = new EfmigrationshistoryService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLEfmigrationshistoryMapperMock,
			                                             mock.DALMapperMockFactory.DALEfmigrationshistoryMapperMock);

			UpdateResponse<ApiEfmigrationshistoryServerResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiEfmigrationshistoryServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IEfmigrationshistoryRepository>();
			var model = new ApiEfmigrationshistoryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
			var service = new EfmigrationshistoryService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.EfmigrationshistoryModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLEfmigrationshistoryMapperMock,
			                                             mock.DALMapperMockFactory.DALEfmigrationshistoryMapperMock);

			ActionResponse response = await service.Delete(default(string));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
			mock.ModelValidatorMockFactory.EfmigrationshistoryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IEfmigrationshistoryRepository>();
			var model = new ApiEfmigrationshistoryServerRequestModel();
			var validatorMock = new Mock<IApiEfmigrationshistoryServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new EfmigrationshistoryService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLEfmigrationshistoryMapperMock,
			                                             mock.DALMapperMockFactory.DALEfmigrationshistoryMapperMock);

			ActionResponse response = await service.Delete(default(string));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>816e417b7ceae2d02d04d0ddb2eb147a</Hash>
</Codenesium>*/