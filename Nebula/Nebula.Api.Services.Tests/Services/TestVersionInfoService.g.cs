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
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VersionInfo")]
	[Trait("Area", "Services")]
	public partial class VersionInfoServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IVersionInfoRepository>();
			var records = new List<VersionInfo>();
			records.Add(new VersionInfo());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VersionInfoService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
			                                     mock.DALMapperMockFactory.DALVersionInfoMapperMock);

			List<ApiVersionInfoServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IVersionInfoRepository>();
			var record = new VersionInfo();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult(record));
			var service = new VersionInfoService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
			                                     mock.DALMapperMockFactory.DALVersionInfoMapperMock);

			ApiVersionInfoServerResponseModel response = await service.Get(default(long));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<long>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IVersionInfoRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult<VersionInfo>(null));
			var service = new VersionInfoService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
			                                     mock.DALMapperMockFactory.DALVersionInfoMapperMock);

			ApiVersionInfoServerResponseModel response = await service.Get(default(long));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<long>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IVersionInfoRepository>();
			var model = new ApiVersionInfoServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VersionInfo>())).Returns(Task.FromResult(new VersionInfo()));
			var service = new VersionInfoService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
			                                     mock.DALMapperMockFactory.DALVersionInfoMapperMock);

			CreateResponse<ApiVersionInfoServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVersionInfoServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<VersionInfo>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IVersionInfoRepository>();
			var model = new ApiVersionInfoServerRequestModel();
			var validatorMock = new Mock<IApiVersionInfoServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVersionInfoServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VersionInfoService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
			                                     mock.DALMapperMockFactory.DALVersionInfoMapperMock);

			CreateResponse<ApiVersionInfoServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVersionInfoServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IVersionInfoRepository>();
			var model = new ApiVersionInfoServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VersionInfo>())).Returns(Task.FromResult(new VersionInfo()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult(new VersionInfo()));
			var service = new VersionInfoService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
			                                     mock.DALMapperMockFactory.DALVersionInfoMapperMock);

			UpdateResponse<ApiVersionInfoServerResponseModel> response = await service.Update(default(long), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<long>(), It.IsAny<ApiVersionInfoServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<VersionInfo>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IVersionInfoRepository>();
			var model = new ApiVersionInfoServerRequestModel();
			var validatorMock = new Mock<IApiVersionInfoServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<long>(), It.IsAny<ApiVersionInfoServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult(new VersionInfo()));
			var service = new VersionInfoService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
			                                     mock.DALMapperMockFactory.DALVersionInfoMapperMock);

			UpdateResponse<ApiVersionInfoServerResponseModel> response = await service.Update(default(long), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<long>(), It.IsAny<ApiVersionInfoServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IVersionInfoRepository>();
			var model = new ApiVersionInfoServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<long>())).Returns(Task.CompletedTask);
			var service = new VersionInfoService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
			                                     mock.DALMapperMockFactory.DALVersionInfoMapperMock);

			ActionResponse response = await service.Delete(default(long));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<long>()));
			mock.ModelValidatorMockFactory.VersionInfoModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<long>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IVersionInfoRepository>();
			var model = new ApiVersionInfoServerRequestModel();
			var validatorMock = new Mock<IApiVersionInfoServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<long>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VersionInfoService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLVersionInfoMapperMock,
			                                     mock.DALMapperMockFactory.DALVersionInfoMapperMock);

			ActionResponse response = await service.Delete(default(long));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<long>()));
		}
	}
}

/*<Codenesium>
    <Hash>42aa9d1d5297da38c59a1648d479b4d0</Hash>
</Codenesium>*/