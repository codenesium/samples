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
	[Trait("Table", "Table")]
	[Trait("Area", "Services")]
	public partial class TableServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITableRepository>();
			var records = new List<Table>();
			records.Add(new Table());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TableService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TableModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLTableMapperMock,
			                               mock.DALMapperMockFactory.DALTableMapperMock);

			List<ApiTableServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITableRepository>();
			var record = new Table();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TableService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TableModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLTableMapperMock,
			                               mock.DALMapperMockFactory.DALTableMapperMock);

			ApiTableServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITableRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Table>(null));
			var service = new TableService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TableModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLTableMapperMock,
			                               mock.DALMapperMockFactory.DALTableMapperMock);

			ApiTableServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ITableRepository>();
			var model = new ApiTableServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Table>())).Returns(Task.FromResult(new Table()));
			var service = new TableService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TableModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLTableMapperMock,
			                               mock.DALMapperMockFactory.DALTableMapperMock);

			CreateResponse<ApiTableServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TableModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTableServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Table>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ITableRepository>();
			var model = new ApiTableServerRequestModel();
			var validatorMock = new Mock<IApiTableServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTableServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TableService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLTableMapperMock,
			                               mock.DALMapperMockFactory.DALTableMapperMock);

			CreateResponse<ApiTableServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTableServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ITableRepository>();
			var model = new ApiTableServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Table>())).Returns(Task.FromResult(new Table()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Table()));
			var service = new TableService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TableModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLTableMapperMock,
			                               mock.DALMapperMockFactory.DALTableMapperMock);

			UpdateResponse<ApiTableServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TableModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTableServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Table>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ITableRepository>();
			var model = new ApiTableServerRequestModel();
			var validatorMock = new Mock<IApiTableServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTableServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Table()));
			var service = new TableService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLTableMapperMock,
			                               mock.DALMapperMockFactory.DALTableMapperMock);

			UpdateResponse<ApiTableServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTableServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ITableRepository>();
			var model = new ApiTableServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TableService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TableModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLTableMapperMock,
			                               mock.DALMapperMockFactory.DALTableMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TableModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ITableRepository>();
			var model = new ApiTableServerRequestModel();
			var validatorMock = new Mock<IApiTableServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TableService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLTableMapperMock,
			                               mock.DALMapperMockFactory.DALTableMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>5f3793af16ccf6e5ea0a2ee13c87cde3</Hash>
</Codenesium>*/