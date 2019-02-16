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
	[Trait("Table", "IncludedColumnTest")]
	[Trait("Area", "Services")]
	public partial class IncludedColumnTestServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IIncludedColumnTestRepository>();
			var records = new List<IncludedColumnTest>();
			records.Add(new IncludedColumnTest());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new IncludedColumnTestService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.IncludedColumnTestModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALIncludedColumnTestMapperMock);

			List<ApiIncludedColumnTestServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IIncludedColumnTestRepository>();
			var record = new IncludedColumnTest();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new IncludedColumnTestService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.IncludedColumnTestModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALIncludedColumnTestMapperMock);

			ApiIncludedColumnTestServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IIncludedColumnTestRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<IncludedColumnTest>(null));
			var service = new IncludedColumnTestService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.IncludedColumnTestModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALIncludedColumnTestMapperMock);

			ApiIncludedColumnTestServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IIncludedColumnTestRepository>();
			var model = new ApiIncludedColumnTestServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<IncludedColumnTest>())).Returns(Task.FromResult(new IncludedColumnTest()));
			var service = new IncludedColumnTestService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.IncludedColumnTestModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALIncludedColumnTestMapperMock);

			CreateResponse<ApiIncludedColumnTestServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.IncludedColumnTestModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiIncludedColumnTestServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<IncludedColumnTest>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<IncludedColumnTestCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IIncludedColumnTestRepository>();
			var model = new ApiIncludedColumnTestServerRequestModel();
			var validatorMock = new Mock<IApiIncludedColumnTestServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiIncludedColumnTestServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new IncludedColumnTestService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            validatorMock.Object,
			                                            mock.DALMapperMockFactory.DALIncludedColumnTestMapperMock);

			CreateResponse<ApiIncludedColumnTestServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiIncludedColumnTestServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<IncludedColumnTestCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IIncludedColumnTestRepository>();
			var model = new ApiIncludedColumnTestServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<IncludedColumnTest>())).Returns(Task.FromResult(new IncludedColumnTest()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new IncludedColumnTest()));
			var service = new IncludedColumnTestService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.IncludedColumnTestModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALIncludedColumnTestMapperMock);

			UpdateResponse<ApiIncludedColumnTestServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.IncludedColumnTestModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiIncludedColumnTestServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<IncludedColumnTest>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<IncludedColumnTestUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IIncludedColumnTestRepository>();
			var model = new ApiIncludedColumnTestServerRequestModel();
			var validatorMock = new Mock<IApiIncludedColumnTestServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiIncludedColumnTestServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new IncludedColumnTest()));
			var service = new IncludedColumnTestService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            validatorMock.Object,
			                                            mock.DALMapperMockFactory.DALIncludedColumnTestMapperMock);

			UpdateResponse<ApiIncludedColumnTestServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiIncludedColumnTestServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<IncludedColumnTestUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IIncludedColumnTestRepository>();
			var model = new ApiIncludedColumnTestServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new IncludedColumnTestService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.IncludedColumnTestModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALIncludedColumnTestMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.IncludedColumnTestModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<IncludedColumnTestDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IIncludedColumnTestRepository>();
			var model = new ApiIncludedColumnTestServerRequestModel();
			var validatorMock = new Mock<IApiIncludedColumnTestServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new IncludedColumnTestService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            validatorMock.Object,
			                                            mock.DALMapperMockFactory.DALIncludedColumnTestMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<IncludedColumnTestDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>70afc65ca728a9f67523df8df9095fac</Hash>
</Codenesium>*/