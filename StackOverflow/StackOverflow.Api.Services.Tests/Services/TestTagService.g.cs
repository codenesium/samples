using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tag")]
	[Trait("Area", "Services")]
	public partial class TagServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITagRepository>();
			var records = new List<Tag>();
			records.Add(new Tag());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TagService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.TagModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLTagMapperMock,
			                             mock.DALMapperMockFactory.DALTagMapperMock);

			List<ApiTagServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITagRepository>();
			var record = new Tag();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TagService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.TagModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLTagMapperMock,
			                             mock.DALMapperMockFactory.DALTagMapperMock);

			ApiTagServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITagRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Tag>(null));
			var service = new TagService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.TagModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLTagMapperMock,
			                             mock.DALMapperMockFactory.DALTagMapperMock);

			ApiTagServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ITagRepository>();
			var model = new ApiTagServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Tag>())).Returns(Task.FromResult(new Tag()));
			var service = new TagService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.TagModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLTagMapperMock,
			                             mock.DALMapperMockFactory.DALTagMapperMock);

			CreateResponse<ApiTagServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TagModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTagServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Tag>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ITagRepository>();
			var model = new ApiTagServerRequestModel();
			var validatorMock = new Mock<IApiTagServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTagServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TagService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             validatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLTagMapperMock,
			                             mock.DALMapperMockFactory.DALTagMapperMock);

			CreateResponse<ApiTagServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTagServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ITagRepository>();
			var model = new ApiTagServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Tag>())).Returns(Task.FromResult(new Tag()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tag()));
			var service = new TagService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.TagModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLTagMapperMock,
			                             mock.DALMapperMockFactory.DALTagMapperMock);

			UpdateResponse<ApiTagServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TagModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTagServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Tag>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ITagRepository>();
			var model = new ApiTagServerRequestModel();
			var validatorMock = new Mock<IApiTagServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTagServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tag()));
			var service = new TagService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             validatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLTagMapperMock,
			                             mock.DALMapperMockFactory.DALTagMapperMock);

			UpdateResponse<ApiTagServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTagServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ITagRepository>();
			var model = new ApiTagServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TagService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.TagModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLTagMapperMock,
			                             mock.DALMapperMockFactory.DALTagMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TagModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ITagRepository>();
			var model = new ApiTagServerRequestModel();
			var validatorMock = new Mock<IApiTagServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TagService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             validatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLTagMapperMock,
			                             mock.DALMapperMockFactory.DALTagMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>cfed75a346e127b683b0687c3a487d84</Hash>
</Codenesium>*/