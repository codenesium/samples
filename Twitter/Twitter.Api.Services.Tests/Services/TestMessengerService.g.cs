using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Messenger")]
	[Trait("Area", "Services")]
	public partial class MessengerServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IMessengerRepository>();
			var records = new List<Messenger>();
			records.Add(new Messenger());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			List<ApiMessengerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IMessengerRepository>();
			var record = new Messenger();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			ApiMessengerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IMessengerRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Messenger>(null));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			ApiMessengerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IMessengerRepository>();
			var model = new ApiMessengerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Messenger>())).Returns(Task.FromResult(new Messenger()));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			CreateResponse<ApiMessengerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiMessengerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Messenger>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IMessengerRepository>();
			var model = new ApiMessengerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Messenger>())).Returns(Task.FromResult(new Messenger()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Messenger()));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			UpdateResponse<ApiMessengerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMessengerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Messenger>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IMessengerRepository>();
			var model = new ApiMessengerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByMessageId_Exists()
		{
			var mock = new ServiceMockFacade<IMessengerRepository>();
			var records = new List<Messenger>();
			records.Add(new Messenger());
			mock.RepositoryMock.Setup(x => x.ByMessageId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			List<ApiMessengerResponseModel> response = await service.ByMessageId(default(int?));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByMessageId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByMessageId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IMessengerRepository>();
			mock.RepositoryMock.Setup(x => x.ByMessageId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Messenger>>(new List<Messenger>()));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			List<ApiMessengerResponseModel> response = await service.ByMessageId(default(int?));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByMessageId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByToUserId_Exists()
		{
			var mock = new ServiceMockFacade<IMessengerRepository>();
			var records = new List<Messenger>();
			records.Add(new Messenger());
			mock.RepositoryMock.Setup(x => x.ByToUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			List<ApiMessengerResponseModel> response = await service.ByToUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByToUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByToUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IMessengerRepository>();
			mock.RepositoryMock.Setup(x => x.ByToUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Messenger>>(new List<Messenger>()));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			List<ApiMessengerResponseModel> response = await service.ByToUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByToUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByUserId_Exists()
		{
			var mock = new ServiceMockFacade<IMessengerRepository>();
			var records = new List<Messenger>();
			records.Add(new Messenger());
			mock.RepositoryMock.Setup(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			List<ApiMessengerResponseModel> response = await service.ByUserId(default(int?));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IMessengerRepository>();
			mock.RepositoryMock.Setup(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Messenger>>(new List<Messenger>()));
			var service = new MessengerService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.MessengerModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLMessengerMapperMock,
			                                   mock.DALMapperMockFactory.DALMessengerMapperMock);

			List<ApiMessengerResponseModel> response = await service.ByUserId(default(int?));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>53797fc1a174d814776a350ebcca34bf</Hash>
</Codenesium>*/