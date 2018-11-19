using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceFeature")]
	[Trait("Area", "Services")]
	public partial class SpaceFeatureServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISpaceFeatureRepository>();
			var records = new List<SpaceFeature>();
			records.Add(new SpaceFeature());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SpaceFeatureService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                      mock.DALMapperMockFactory.DALSpaceFeatureMapperMock);

			List<ApiSpaceFeatureServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISpaceFeatureRepository>();
			var record = new SpaceFeature();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SpaceFeatureService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                      mock.DALMapperMockFactory.DALSpaceFeatureMapperMock);

			ApiSpaceFeatureServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISpaceFeatureRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SpaceFeature>(null));
			var service = new SpaceFeatureService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                      mock.DALMapperMockFactory.DALSpaceFeatureMapperMock);

			ApiSpaceFeatureServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ISpaceFeatureRepository>();
			var model = new ApiSpaceFeatureServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SpaceFeature>())).Returns(Task.FromResult(new SpaceFeature()));
			var service = new SpaceFeatureService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                      mock.DALMapperMockFactory.DALSpaceFeatureMapperMock);

			CreateResponse<ApiSpaceFeatureServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceFeatureServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SpaceFeature>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ISpaceFeatureRepository>();
			var model = new ApiSpaceFeatureServerRequestModel();
			var validatorMock = new Mock<IApiSpaceFeatureServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceFeatureServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SpaceFeatureService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                      mock.DALMapperMockFactory.DALSpaceFeatureMapperMock);

			CreateResponse<ApiSpaceFeatureServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceFeatureServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ISpaceFeatureRepository>();
			var model = new ApiSpaceFeatureServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SpaceFeature>())).Returns(Task.FromResult(new SpaceFeature()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpaceFeature()));
			var service = new SpaceFeatureService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                      mock.DALMapperMockFactory.DALSpaceFeatureMapperMock);

			UpdateResponse<ApiSpaceFeatureServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceFeatureServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SpaceFeature>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ISpaceFeatureRepository>();
			var model = new ApiSpaceFeatureServerRequestModel();
			var validatorMock = new Mock<IApiSpaceFeatureServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceFeatureServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpaceFeature()));
			var service = new SpaceFeatureService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                      mock.DALMapperMockFactory.DALSpaceFeatureMapperMock);

			UpdateResponse<ApiSpaceFeatureServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceFeatureServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ISpaceFeatureRepository>();
			var model = new ApiSpaceFeatureServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SpaceFeatureService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                      mock.DALMapperMockFactory.DALSpaceFeatureMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ISpaceFeatureRepository>();
			var model = new ApiSpaceFeatureServerRequestModel();
			var validatorMock = new Mock<IApiSpaceFeatureServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SpaceFeatureService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
			                                      mock.DALMapperMockFactory.DALSpaceFeatureMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>28f294d47a21def3f65d96e52af17f87</Hash>
</Codenesium>*/