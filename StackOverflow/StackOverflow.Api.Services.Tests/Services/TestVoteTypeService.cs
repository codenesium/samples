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
	[Trait("Table", "VoteType")]
	[Trait("Area", "Services")]
	public partial class VoteTypeServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IVoteTypeService, IVoteTypeRepository>();
			var records = new List<VoteType>();
			records.Add(new VoteType());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new VoteTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.VoteTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALVoteTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALVoteMapperMock);

			List<ApiVoteTypeServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IVoteTypeService, IVoteTypeRepository>();
			var record = new VoteType();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VoteTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.VoteTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALVoteTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALVoteMapperMock);

			ApiVoteTypeServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IVoteTypeService, IVoteTypeRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<VoteType>(null));
			var service = new VoteTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.VoteTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALVoteTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALVoteMapperMock);

			ApiVoteTypeServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IVoteTypeService, IVoteTypeRepository>();

			var model = new ApiVoteTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VoteType>())).Returns(Task.FromResult(new VoteType()));
			var service = new VoteTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.VoteTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALVoteTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALVoteMapperMock);

			CreateResponse<ApiVoteTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VoteTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVoteTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<VoteType>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VoteTypeCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IVoteTypeService, IVoteTypeRepository>();
			var model = new ApiVoteTypeServerRequestModel();
			var validatorMock = new Mock<IApiVoteTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVoteTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VoteTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALVoteTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALVoteMapperMock);

			CreateResponse<ApiVoteTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVoteTypeServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VoteTypeCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IVoteTypeService, IVoteTypeRepository>();
			var model = new ApiVoteTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VoteType>())).Returns(Task.FromResult(new VoteType()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VoteType()));
			var service = new VoteTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.VoteTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALVoteTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALVoteMapperMock);

			UpdateResponse<ApiVoteTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.VoteTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVoteTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<VoteType>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VoteTypeUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IVoteTypeService, IVoteTypeRepository>();
			var model = new ApiVoteTypeServerRequestModel();
			var validatorMock = new Mock<IApiVoteTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVoteTypeServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VoteType()));
			var service = new VoteTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALVoteTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALVoteMapperMock);

			UpdateResponse<ApiVoteTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVoteTypeServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VoteTypeUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IVoteTypeService, IVoteTypeRepository>();
			var model = new ApiVoteTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VoteTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.VoteTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALVoteTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALVoteMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VoteTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VoteTypeDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IVoteTypeService, IVoteTypeRepository>();
			var model = new ApiVoteTypeServerRequestModel();
			var validatorMock = new Mock<IApiVoteTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new VoteTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALVoteTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALVoteMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<VoteTypeDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void VotesByVoteTypeId_Exists()
		{
			var mock = new ServiceMockFacade<IVoteTypeService, IVoteTypeRepository>();
			var records = new List<Vote>();
			records.Add(new Vote());
			mock.RepositoryMock.Setup(x => x.VotesByVoteTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VoteTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.VoteTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALVoteTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALVoteMapperMock);

			List<ApiVoteServerResponseModel> response = await service.VotesByVoteTypeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.VotesByVoteTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void VotesByVoteTypeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVoteTypeService, IVoteTypeRepository>();
			mock.RepositoryMock.Setup(x => x.VotesByVoteTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Vote>>(new List<Vote>()));
			var service = new VoteTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.VoteTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALVoteTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALVoteMapperMock);

			List<ApiVoteServerResponseModel> response = await service.VotesByVoteTypeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.VotesByVoteTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>72442a78855ed40c8e85ff0ea5234f1d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/