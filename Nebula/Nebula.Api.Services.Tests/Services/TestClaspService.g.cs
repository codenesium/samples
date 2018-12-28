using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Clasp")]
	[Trait("Area", "Services")]
	public partial class ClaspServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IClaspRepository>();
			var records = new List<Clasp>();
			records.Add(new Clasp());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ClaspService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ClaspModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock);

			List<ApiClaspServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IClaspRepository>();
			var record = new Clasp();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ClaspService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ClaspModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock);

			ApiClaspServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IClaspRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Clasp>(null));
			var service = new ClaspService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ClaspModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock);

			ApiClaspServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IClaspRepository>();
			var model = new ApiClaspServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Clasp>())).Returns(Task.FromResult(new Clasp()));
			var service = new ClaspService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ClaspModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock);

			CreateResponse<ApiClaspServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ClaspModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiClaspServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Clasp>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ClaspCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IClaspRepository>();
			var model = new ApiClaspServerRequestModel();
			var validatorMock = new Mock<IApiClaspServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiClaspServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ClaspService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock);

			CreateResponse<ApiClaspServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiClaspServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ClaspCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IClaspRepository>();
			var model = new ApiClaspServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Clasp>())).Returns(Task.FromResult(new Clasp()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Clasp()));
			var service = new ClaspService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ClaspModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock);

			UpdateResponse<ApiClaspServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ClaspModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiClaspServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Clasp>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ClaspUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IClaspRepository>();
			var model = new ApiClaspServerRequestModel();
			var validatorMock = new Mock<IApiClaspServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiClaspServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Clasp()));
			var service = new ClaspService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock);

			UpdateResponse<ApiClaspServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiClaspServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ClaspUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IClaspRepository>();
			var model = new ApiClaspServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ClaspService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ClaspModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ClaspModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ClaspDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IClaspRepository>();
			var model = new ApiClaspServerRequestModel();
			var validatorMock = new Mock<IApiClaspServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ClaspService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ClaspDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>1f1bc927b7e36a28f94be61959f7ce8b</Hash>
</Codenesium>*/