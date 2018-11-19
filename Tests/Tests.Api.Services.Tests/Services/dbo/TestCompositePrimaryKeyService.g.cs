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
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CompositePrimaryKey")]
	[Trait("Area", "Services")]
	public partial class CompositePrimaryKeyServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ICompositePrimaryKeyRepository>();
			var records = new List<CompositePrimaryKey>();
			records.Add(new CompositePrimaryKey());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CompositePrimaryKeyService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.CompositePrimaryKeyModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLCompositePrimaryKeyMapperMock,
			                                             mock.DALMapperMockFactory.DALCompositePrimaryKeyMapperMock);

			List<ApiCompositePrimaryKeyServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ICompositePrimaryKeyRepository>();
			var record = new CompositePrimaryKey();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CompositePrimaryKeyService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.CompositePrimaryKeyModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLCompositePrimaryKeyMapperMock,
			                                             mock.DALMapperMockFactory.DALCompositePrimaryKeyMapperMock);

			ApiCompositePrimaryKeyServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ICompositePrimaryKeyRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<CompositePrimaryKey>(null));
			var service = new CompositePrimaryKeyService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.CompositePrimaryKeyModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLCompositePrimaryKeyMapperMock,
			                                             mock.DALMapperMockFactory.DALCompositePrimaryKeyMapperMock);

			ApiCompositePrimaryKeyServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ICompositePrimaryKeyRepository>();
			var model = new ApiCompositePrimaryKeyServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CompositePrimaryKey>())).Returns(Task.FromResult(new CompositePrimaryKey()));
			var service = new CompositePrimaryKeyService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.CompositePrimaryKeyModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLCompositePrimaryKeyMapperMock,
			                                             mock.DALMapperMockFactory.DALCompositePrimaryKeyMapperMock);

			CreateResponse<ApiCompositePrimaryKeyServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CompositePrimaryKeyModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCompositePrimaryKeyServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<CompositePrimaryKey>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ICompositePrimaryKeyRepository>();
			var model = new ApiCompositePrimaryKeyServerRequestModel();
			var validatorMock = new Mock<IApiCompositePrimaryKeyServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCompositePrimaryKeyServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CompositePrimaryKeyService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLCompositePrimaryKeyMapperMock,
			                                             mock.DALMapperMockFactory.DALCompositePrimaryKeyMapperMock);

			CreateResponse<ApiCompositePrimaryKeyServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCompositePrimaryKeyServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ICompositePrimaryKeyRepository>();
			var model = new ApiCompositePrimaryKeyServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CompositePrimaryKey>())).Returns(Task.FromResult(new CompositePrimaryKey()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CompositePrimaryKey()));
			var service = new CompositePrimaryKeyService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.CompositePrimaryKeyModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLCompositePrimaryKeyMapperMock,
			                                             mock.DALMapperMockFactory.DALCompositePrimaryKeyMapperMock);

			UpdateResponse<ApiCompositePrimaryKeyServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CompositePrimaryKeyModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCompositePrimaryKeyServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<CompositePrimaryKey>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ICompositePrimaryKeyRepository>();
			var model = new ApiCompositePrimaryKeyServerRequestModel();
			var validatorMock = new Mock<IApiCompositePrimaryKeyServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCompositePrimaryKeyServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CompositePrimaryKey()));
			var service = new CompositePrimaryKeyService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLCompositePrimaryKeyMapperMock,
			                                             mock.DALMapperMockFactory.DALCompositePrimaryKeyMapperMock);

			UpdateResponse<ApiCompositePrimaryKeyServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCompositePrimaryKeyServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ICompositePrimaryKeyRepository>();
			var model = new ApiCompositePrimaryKeyServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CompositePrimaryKeyService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.CompositePrimaryKeyModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLCompositePrimaryKeyMapperMock,
			                                             mock.DALMapperMockFactory.DALCompositePrimaryKeyMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CompositePrimaryKeyModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ICompositePrimaryKeyRepository>();
			var model = new ApiCompositePrimaryKeyServerRequestModel();
			var validatorMock = new Mock<IApiCompositePrimaryKeyServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CompositePrimaryKeyService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLCompositePrimaryKeyMapperMock,
			                                             mock.DALMapperMockFactory.DALCompositePrimaryKeyMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>cde52433558987f1bbd7ddcebbfe4b36</Hash>
</Codenesium>*/