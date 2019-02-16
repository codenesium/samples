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
	[Trait("Table", "AWBuildVersion")]
	[Trait("Area", "Services")]
	public partial class AWBuildVersionServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IAWBuildVersionRepository>();
			var records = new List<AWBuildVersion>();
			records.Add(new AWBuildVersion());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new AWBuildVersionService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.AWBuildVersionModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALAWBuildVersionMapperMock);

			List<ApiAWBuildVersionServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IAWBuildVersionRepository>();
			var record = new AWBuildVersion();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new AWBuildVersionService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.AWBuildVersionModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALAWBuildVersionMapperMock);

			ApiAWBuildVersionServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IAWBuildVersionRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<AWBuildVersion>(null));
			var service = new AWBuildVersionService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.AWBuildVersionModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALAWBuildVersionMapperMock);

			ApiAWBuildVersionServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IAWBuildVersionRepository>();
			var model = new ApiAWBuildVersionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<AWBuildVersion>())).Returns(Task.FromResult(new AWBuildVersion()));
			var service = new AWBuildVersionService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.AWBuildVersionModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALAWBuildVersionMapperMock);

			CreateResponse<ApiAWBuildVersionServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.AWBuildVersionModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiAWBuildVersionServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<AWBuildVersion>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AWBuildVersionCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IAWBuildVersionRepository>();
			var model = new ApiAWBuildVersionServerRequestModel();
			var validatorMock = new Mock<IApiAWBuildVersionServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAWBuildVersionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new AWBuildVersionService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.DALMapperMockFactory.DALAWBuildVersionMapperMock);

			CreateResponse<ApiAWBuildVersionServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiAWBuildVersionServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AWBuildVersionCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IAWBuildVersionRepository>();
			var model = new ApiAWBuildVersionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<AWBuildVersion>())).Returns(Task.FromResult(new AWBuildVersion()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AWBuildVersion()));
			var service = new AWBuildVersionService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.AWBuildVersionModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALAWBuildVersionMapperMock);

			UpdateResponse<ApiAWBuildVersionServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.AWBuildVersionModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAWBuildVersionServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<AWBuildVersion>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AWBuildVersionUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IAWBuildVersionRepository>();
			var model = new ApiAWBuildVersionServerRequestModel();
			var validatorMock = new Mock<IApiAWBuildVersionServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAWBuildVersionServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AWBuildVersion()));
			var service = new AWBuildVersionService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.DALMapperMockFactory.DALAWBuildVersionMapperMock);

			UpdateResponse<ApiAWBuildVersionServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAWBuildVersionServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AWBuildVersionUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IAWBuildVersionRepository>();
			var model = new ApiAWBuildVersionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new AWBuildVersionService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.AWBuildVersionModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALAWBuildVersionMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.AWBuildVersionModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AWBuildVersionDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IAWBuildVersionRepository>();
			var model = new ApiAWBuildVersionServerRequestModel();
			var validatorMock = new Mock<IApiAWBuildVersionServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new AWBuildVersionService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.DALMapperMockFactory.DALAWBuildVersionMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AWBuildVersionDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>328a73c7410617010d83e159c25d932b</Hash>
</Codenesium>*/