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
	[Trait("Table", "Password")]
	[Trait("Area", "Services")]
	public partial class PasswordServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPasswordRepository>();
			var records = new List<Password>();
			records.Add(new Password());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PasswordService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PasswordModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                  mock.DALMapperMockFactory.DALPasswordMapperMock);

			List<ApiPasswordServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPasswordRepository>();
			var record = new Password();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PasswordService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PasswordModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                  mock.DALMapperMockFactory.DALPasswordMapperMock);

			ApiPasswordServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPasswordRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Password>(null));
			var service = new PasswordService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PasswordModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                  mock.DALMapperMockFactory.DALPasswordMapperMock);

			ApiPasswordServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IPasswordRepository>();
			var model = new ApiPasswordServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Password>())).Returns(Task.FromResult(new Password()));
			var service = new PasswordService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PasswordModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                  mock.DALMapperMockFactory.DALPasswordMapperMock);

			CreateResponse<ApiPasswordServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PasswordModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPasswordServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Password>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IPasswordRepository>();
			var model = new ApiPasswordServerRequestModel();
			var validatorMock = new Mock<IApiPasswordServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPasswordServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PasswordService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                  mock.DALMapperMockFactory.DALPasswordMapperMock);

			CreateResponse<ApiPasswordServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPasswordServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IPasswordRepository>();
			var model = new ApiPasswordServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Password>())).Returns(Task.FromResult(new Password()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Password()));
			var service = new PasswordService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PasswordModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                  mock.DALMapperMockFactory.DALPasswordMapperMock);

			UpdateResponse<ApiPasswordServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PasswordModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPasswordServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Password>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IPasswordRepository>();
			var model = new ApiPasswordServerRequestModel();
			var validatorMock = new Mock<IApiPasswordServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPasswordServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Password()));
			var service = new PasswordService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                  mock.DALMapperMockFactory.DALPasswordMapperMock);

			UpdateResponse<ApiPasswordServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPasswordServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IPasswordRepository>();
			var model = new ApiPasswordServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PasswordService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PasswordModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                  mock.DALMapperMockFactory.DALPasswordMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PasswordModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IPasswordRepository>();
			var model = new ApiPasswordServerRequestModel();
			var validatorMock = new Mock<IApiPasswordServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PasswordService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPasswordMapperMock,
			                                  mock.DALMapperMockFactory.DALPasswordMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>b4156bc273587cd071b0f1f93022055c</Hash>
</Codenesium>*/