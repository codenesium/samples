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
	[Trait("Table", "ColumnSameAsFKTable")]
	[Trait("Area", "Services")]
	public partial class ColumnSameAsFKTableServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableRepository>();
			var records = new List<ColumnSameAsFKTable>();
			records.Add(new ColumnSameAsFKTable());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			List<ApiColumnSameAsFKTableServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableRepository>();
			var record = new ColumnSameAsFKTable();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			ApiColumnSameAsFKTableServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ColumnSameAsFKTable>(null));
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			ApiColumnSameAsFKTableServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableRepository>();
			var model = new ApiColumnSameAsFKTableServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ColumnSameAsFKTable>())).Returns(Task.FromResult(new ColumnSameAsFKTable()));
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			CreateResponse<ApiColumnSameAsFKTableServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiColumnSameAsFKTableServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ColumnSameAsFKTable>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableRepository>();
			var model = new ApiColumnSameAsFKTableServerRequestModel();
			var validatorMock = new Mock<IApiColumnSameAsFKTableServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiColumnSameAsFKTableServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			CreateResponse<ApiColumnSameAsFKTableServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiColumnSameAsFKTableServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableRepository>();
			var model = new ApiColumnSameAsFKTableServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ColumnSameAsFKTable>())).Returns(Task.FromResult(new ColumnSameAsFKTable()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ColumnSameAsFKTable()));
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			UpdateResponse<ApiColumnSameAsFKTableServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiColumnSameAsFKTableServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ColumnSameAsFKTable>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableRepository>();
			var model = new ApiColumnSameAsFKTableServerRequestModel();
			var validatorMock = new Mock<IApiColumnSameAsFKTableServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiColumnSameAsFKTableServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ColumnSameAsFKTable()));
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			UpdateResponse<ApiColumnSameAsFKTableServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiColumnSameAsFKTableServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableRepository>();
			var model = new ApiColumnSameAsFKTableServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableRepository>();
			var model = new ApiColumnSameAsFKTableServerRequestModel();
			var validatorMock = new Mock<IApiColumnSameAsFKTableServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>89d355d7bdb8e63e41a3c5be82a08b97</Hash>
</Codenesium>*/