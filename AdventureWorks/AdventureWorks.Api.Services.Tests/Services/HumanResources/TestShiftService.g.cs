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
	[Trait("Table", "Shift")]
	[Trait("Area", "Services")]
	public partial class ShiftServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IShiftRepository>();
			var records = new List<Shift>();
			records.Add(new Shift());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ShiftService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLShiftMapperMock,
			                               mock.DALMapperMockFactory.DALShiftMapperMock);

			List<ApiShiftServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IShiftRepository>();
			var record = new Shift();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ShiftService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLShiftMapperMock,
			                               mock.DALMapperMockFactory.DALShiftMapperMock);

			ApiShiftServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IShiftRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Shift>(null));
			var service = new ShiftService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLShiftMapperMock,
			                               mock.DALMapperMockFactory.DALShiftMapperMock);

			ApiShiftServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IShiftRepository>();
			var model = new ApiShiftServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Shift>())).Returns(Task.FromResult(new Shift()));
			var service = new ShiftService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLShiftMapperMock,
			                               mock.DALMapperMockFactory.DALShiftMapperMock);

			CreateResponse<ApiShiftServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiShiftServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Shift>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IShiftRepository>();
			var model = new ApiShiftServerRequestModel();
			var validatorMock = new Mock<IApiShiftServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiShiftServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ShiftService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLShiftMapperMock,
			                               mock.DALMapperMockFactory.DALShiftMapperMock);

			CreateResponse<ApiShiftServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiShiftServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IShiftRepository>();
			var model = new ApiShiftServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Shift>())).Returns(Task.FromResult(new Shift()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Shift()));
			var service = new ShiftService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLShiftMapperMock,
			                               mock.DALMapperMockFactory.DALShiftMapperMock);

			UpdateResponse<ApiShiftServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiShiftServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Shift>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IShiftRepository>();
			var model = new ApiShiftServerRequestModel();
			var validatorMock = new Mock<IApiShiftServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiShiftServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Shift()));
			var service = new ShiftService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLShiftMapperMock,
			                               mock.DALMapperMockFactory.DALShiftMapperMock);

			UpdateResponse<ApiShiftServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiShiftServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IShiftRepository>();
			var model = new ApiShiftServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ShiftService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLShiftMapperMock,
			                               mock.DALMapperMockFactory.DALShiftMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IShiftRepository>();
			var model = new ApiShiftServerRequestModel();
			var validatorMock = new Mock<IApiShiftServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ShiftService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLShiftMapperMock,
			                               mock.DALMapperMockFactory.DALShiftMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IShiftRepository>();
			var record = new Shift();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ShiftService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLShiftMapperMock,
			                               mock.DALMapperMockFactory.DALShiftMapperMock);

			ApiShiftServerResponseModel response = await service.ByName("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IShiftRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Shift>(null));
			var service = new ShiftService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLShiftMapperMock,
			                               mock.DALMapperMockFactory.DALShiftMapperMock);

			ApiShiftServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByStartTimeEndTime_Exists()
		{
			var mock = new ServiceMockFacade<IShiftRepository>();
			var record = new Shift();
			mock.RepositoryMock.Setup(x => x.ByStartTimeEndTime(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Returns(Task.FromResult(record));
			var service = new ShiftService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLShiftMapperMock,
			                               mock.DALMapperMockFactory.DALShiftMapperMock);

			ApiShiftServerResponseModel response = await service.ByStartTimeEndTime(default(TimeSpan), default(TimeSpan));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByStartTimeEndTime(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>()));
		}

		[Fact]
		public async void ByStartTimeEndTime_Not_Exists()
		{
			var mock = new ServiceMockFacade<IShiftRepository>();
			mock.RepositoryMock.Setup(x => x.ByStartTimeEndTime(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Returns(Task.FromResult<Shift>(null));
			var service = new ShiftService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLShiftMapperMock,
			                               mock.DALMapperMockFactory.DALShiftMapperMock);

			ApiShiftServerResponseModel response = await service.ByStartTimeEndTime(default(TimeSpan), default(TimeSpan));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByStartTimeEndTime(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>()));
		}
	}
}

/*<Codenesium>
    <Hash>e98e676048161d196b91861e138ba471</Hash>
</Codenesium>*/