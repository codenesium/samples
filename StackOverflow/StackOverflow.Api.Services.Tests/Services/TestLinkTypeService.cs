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
using System.Threading;
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
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ILinkTypeService, ILinkTypeRepository>();
			var records = new List<LinkType>();
			records.Add(new LinkType());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiLinkTypeServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ILinkTypeService, ILinkTypeRepository>();
			var record = new LinkType();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			ApiLinkTypeServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ILinkTypeService, ILinkTypeRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<LinkType>(null));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			ApiLinkTypeServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ILinkTypeService, ILinkTypeRepository>();

			var model = new ApiLinkTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkType>())).Returns(Task.FromResult(new LinkType()));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			CreateResponse<ApiLinkTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLinkTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<LinkType>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkTypeCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ILinkTypeService, ILinkTypeRepository>();
			var model = new ApiLinkTypeServerRequestModel();
			var validatorMock = new Mock<IApiLinkTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLinkTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			CreateResponse<ApiLinkTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLinkTypeServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkTypeCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ILinkTypeService, ILinkTypeRepository>();
			var model = new ApiLinkTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkType>())).Returns(Task.FromResult(new LinkType()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkType()));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			UpdateResponse<ApiLinkTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<LinkType>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkTypeUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ILinkTypeService, ILinkTypeRepository>();
			var model = new ApiLinkTypeServerRequestModel();
			var validatorMock = new Mock<IApiLinkTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkTypeServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkType()));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			UpdateResponse<ApiLinkTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkTypeServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkTypeUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ILinkTypeService, ILinkTypeRepository>();
			var model = new ApiLinkTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkTypeDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ILinkTypeService, ILinkTypeRepository>();
			var model = new ApiLinkTypeServerRequestModel();
			var validatorMock = new Mock<IApiLinkTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkTypeDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void PostLinksByLinkTypeId_Exists()
		{
			var mock = new ServiceMockFacade<ILinkTypeService, ILinkTypeRepository>();
			var records = new List<PostLink>();
			records.Add(new PostLink());
			mock.RepositoryMock.Setup(x => x.PostLinksByLinkTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostLinkServerResponseModel> response = await service.PostLinksByLinkTypeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PostLinksByLinkTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostLinksByLinkTypeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ILinkTypeService, ILinkTypeRepository>();
			mock.RepositoryMock.Setup(x => x.PostLinksByLinkTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PostLink>>(new List<PostLink>()));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostLinkServerResponseModel> response = await service.PostLinksByLinkTypeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PostLinksByLinkTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>7f75944802ce654eabbd51c921457ff9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/