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
	[Trait("Table", "LinkType")]
	[Trait("Area", "Services")]
	public partial class LinkTypeServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ILinkTypeRepository>();
			var records = new List<LinkType>();
			records.Add(new LinkType());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock);

			List<ApiLinkTypeServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ILinkTypeRepository>();
			var record = new LinkType();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock);

			ApiLinkTypeServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ILinkTypeRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<LinkType>(null));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock);

			ApiLinkTypeServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ILinkTypeRepository>();
			var model = new ApiLinkTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkType>())).Returns(Task.FromResult(new LinkType()));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock);

			CreateResponse<ApiLinkTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLinkTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<LinkType>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ILinkTypeRepository>();
			var model = new ApiLinkTypeServerRequestModel();
			var validatorMock = new Mock<IApiLinkTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLinkTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock);

			CreateResponse<ApiLinkTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLinkTypeServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ILinkTypeRepository>();
			var model = new ApiLinkTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkType>())).Returns(Task.FromResult(new LinkType()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkType()));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock);

			UpdateResponse<ApiLinkTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<LinkType>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ILinkTypeRepository>();
			var model = new ApiLinkTypeServerRequestModel();
			var validatorMock = new Mock<IApiLinkTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkTypeServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkType()));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock);

			UpdateResponse<ApiLinkTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkTypeServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ILinkTypeRepository>();
			var model = new ApiLinkTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ILinkTypeRepository>();
			var model = new ApiLinkTypeServerRequestModel();
			var validatorMock = new Mock<IApiLinkTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>8f927111d3ddb4b0b2604a1fcec410d6</Hash>
</Codenesium>*/