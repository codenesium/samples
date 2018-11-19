using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Studio")]
	[Trait("Area", "Services")]
	public partial class StudioServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var records = new List<Studio>();
			records.Add(new Studio());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock);

			List<ApiStudioServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var record = new Studio();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock);

			ApiStudioServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock);

			ApiStudioServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var model = new ApiStudioServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Studio>())).Returns(Task.FromResult(new Studio()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock);

			CreateResponse<ApiStudioServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.StudioModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiStudioServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Studio>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var model = new ApiStudioServerRequestModel();
			var validatorMock = new Mock<IApiStudioServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiStudioServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock);

			CreateResponse<ApiStudioServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiStudioServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var model = new ApiStudioServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Studio>())).Returns(Task.FromResult(new Studio()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock);

			UpdateResponse<ApiStudioServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.StudioModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStudioServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Studio>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var model = new ApiStudioServerRequestModel();
			var validatorMock = new Mock<IApiStudioServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStudioServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock);

			UpdateResponse<ApiStudioServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStudioServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var model = new ApiStudioServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.StudioModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IStudioRepository>();
			var model = new ApiStudioServerRequestModel();
			var validatorMock = new Mock<IApiStudioServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                                mock.DALMapperMockFactory.DALStudioMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>6961b26cd05705b92819e0cc3bf6af17</Hash>
</Codenesium>*/