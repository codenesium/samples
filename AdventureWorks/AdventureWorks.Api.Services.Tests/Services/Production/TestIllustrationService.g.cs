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
	[Trait("Table", "Illustration")]
	[Trait("Area", "Services")]
	public partial class IllustrationServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IIllustrationRepository>();
			var records = new List<Illustration>();
			records.Add(new Illustration());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new IllustrationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.IllustrationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLIllustrationMapperMock,
			                                      mock.DALMapperMockFactory.DALIllustrationMapperMock);

			List<ApiIllustrationServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IIllustrationRepository>();
			var record = new Illustration();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new IllustrationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.IllustrationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLIllustrationMapperMock,
			                                      mock.DALMapperMockFactory.DALIllustrationMapperMock);

			ApiIllustrationServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IIllustrationRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Illustration>(null));
			var service = new IllustrationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.IllustrationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLIllustrationMapperMock,
			                                      mock.DALMapperMockFactory.DALIllustrationMapperMock);

			ApiIllustrationServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IIllustrationRepository>();
			var model = new ApiIllustrationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Illustration>())).Returns(Task.FromResult(new Illustration()));
			var service = new IllustrationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.IllustrationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLIllustrationMapperMock,
			                                      mock.DALMapperMockFactory.DALIllustrationMapperMock);

			CreateResponse<ApiIllustrationServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.IllustrationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiIllustrationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Illustration>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<IllustrationCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IIllustrationRepository>();
			var model = new ApiIllustrationServerRequestModel();
			var validatorMock = new Mock<IApiIllustrationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiIllustrationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new IllustrationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLIllustrationMapperMock,
			                                      mock.DALMapperMockFactory.DALIllustrationMapperMock);

			CreateResponse<ApiIllustrationServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiIllustrationServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<IllustrationCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IIllustrationRepository>();
			var model = new ApiIllustrationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Illustration>())).Returns(Task.FromResult(new Illustration()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Illustration()));
			var service = new IllustrationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.IllustrationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLIllustrationMapperMock,
			                                      mock.DALMapperMockFactory.DALIllustrationMapperMock);

			UpdateResponse<ApiIllustrationServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.IllustrationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiIllustrationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Illustration>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<IllustrationUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IIllustrationRepository>();
			var model = new ApiIllustrationServerRequestModel();
			var validatorMock = new Mock<IApiIllustrationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiIllustrationServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Illustration()));
			var service = new IllustrationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLIllustrationMapperMock,
			                                      mock.DALMapperMockFactory.DALIllustrationMapperMock);

			UpdateResponse<ApiIllustrationServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiIllustrationServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<IllustrationUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IIllustrationRepository>();
			var model = new ApiIllustrationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new IllustrationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.IllustrationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLIllustrationMapperMock,
			                                      mock.DALMapperMockFactory.DALIllustrationMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.IllustrationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<IllustrationDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IIllustrationRepository>();
			var model = new ApiIllustrationServerRequestModel();
			var validatorMock = new Mock<IApiIllustrationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new IllustrationService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLIllustrationMapperMock,
			                                      mock.DALMapperMockFactory.DALIllustrationMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<IllustrationDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>1b3c78add270e1aa6b2c2989c37f103c</Hash>
</Codenesium>*/