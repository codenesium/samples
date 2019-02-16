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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TicketStatu")]
	[Trait("Area", "Services")]
	public partial class TicketStatuServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITicketStatuRepository>();
			var records = new List<TicketStatu>();
			records.Add(new TicketStatu());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new TicketStatuService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTicketStatuMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketMapperMock);

			List<ApiTicketStatuServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITicketStatuRepository>();
			var record = new TicketStatu();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TicketStatuService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTicketStatuMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketMapperMock);

			ApiTicketStatuServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITicketStatuRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TicketStatu>(null));
			var service = new TicketStatuService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTicketStatuMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketMapperMock);

			ApiTicketStatuServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ITicketStatuRepository>();
			var model = new ApiTicketStatuServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TicketStatu>())).Returns(Task.FromResult(new TicketStatu()));
			var service = new TicketStatuService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTicketStatuMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketMapperMock);

			CreateResponse<ApiTicketStatuServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTicketStatuServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TicketStatu>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TicketStatuCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ITicketStatuRepository>();
			var model = new ApiTicketStatuServerRequestModel();
			var validatorMock = new Mock<IApiTicketStatuServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTicketStatuServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TicketStatuService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTicketStatuMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketMapperMock);

			CreateResponse<ApiTicketStatuServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTicketStatuServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TicketStatuCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ITicketStatuRepository>();
			var model = new ApiTicketStatuServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TicketStatu>())).Returns(Task.FromResult(new TicketStatu()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TicketStatu()));
			var service = new TicketStatuService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTicketStatuMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketMapperMock);

			UpdateResponse<ApiTicketStatuServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTicketStatuServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TicketStatu>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TicketStatuUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ITicketStatuRepository>();
			var model = new ApiTicketStatuServerRequestModel();
			var validatorMock = new Mock<IApiTicketStatuServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTicketStatuServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TicketStatu()));
			var service = new TicketStatuService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTicketStatuMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketMapperMock);

			UpdateResponse<ApiTicketStatuServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTicketStatuServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TicketStatuUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ITicketStatuRepository>();
			var model = new ApiTicketStatuServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TicketStatuService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTicketStatuMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TicketStatuDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ITicketStatuRepository>();
			var model = new ApiTicketStatuServerRequestModel();
			var validatorMock = new Mock<IApiTicketStatuServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TicketStatuService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTicketStatuMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TicketStatuDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void TicketsByTicketStatusId_Exists()
		{
			var mock = new ServiceMockFacade<ITicketStatuRepository>();
			var records = new List<Ticket>();
			records.Add(new Ticket());
			mock.RepositoryMock.Setup(x => x.TicketsByTicketStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TicketStatuService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTicketStatuMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketMapperMock);

			List<ApiTicketServerResponseModel> response = await service.TicketsByTicketStatusId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TicketsByTicketStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TicketsByTicketStatusId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITicketStatuRepository>();
			mock.RepositoryMock.Setup(x => x.TicketsByTicketStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Ticket>>(new List<Ticket>()));
			var service = new TicketStatuService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTicketStatuMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketMapperMock);

			List<ApiTicketServerResponseModel> response = await service.TicketsByTicketStatusId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TicketsByTicketStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>bf64f07e19823ba2e2a4af1a28647f1a</Hash>
</Codenesium>*/