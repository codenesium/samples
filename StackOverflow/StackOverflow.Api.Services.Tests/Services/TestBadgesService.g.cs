using FluentAssertions;
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
	[Trait("Table", "Badges")]
	[Trait("Area", "Services")]
	public partial class BadgesServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IBadgesRepository>();
			var records = new List<Badges>();
			records.Add(new Badges());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new BadgesService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.BadgesModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLBadgesMapperMock,
			                                mock.DALMapperMockFactory.DALBadgesMapperMock);

			List<ApiBadgesResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IBadgesRepository>();
			var record = new Badges();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new BadgesService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.BadgesModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLBadgesMapperMock,
			                                mock.DALMapperMockFactory.DALBadgesMapperMock);

			ApiBadgesResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IBadgesRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Badges>(null));
			var service = new BadgesService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.BadgesModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLBadgesMapperMock,
			                                mock.DALMapperMockFactory.DALBadgesMapperMock);

			ApiBadgesResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IBadgesRepository>();
			var model = new ApiBadgesRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Badges>())).Returns(Task.FromResult(new Badges()));
			var service = new BadgesService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.BadgesModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLBadgesMapperMock,
			                                mock.DALMapperMockFactory.DALBadgesMapperMock);

			CreateResponse<ApiBadgesResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.BadgesModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiBadgesRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Badges>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IBadgesRepository>();
			var model = new ApiBadgesRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Badges>())).Returns(Task.FromResult(new Badges()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Badges()));
			var service = new BadgesService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.BadgesModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLBadgesMapperMock,
			                                mock.DALMapperMockFactory.DALBadgesMapperMock);

			UpdateResponse<ApiBadgesResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.BadgesModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBadgesRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Badges>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IBadgesRepository>();
			var model = new ApiBadgesRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new BadgesService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.BadgesModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLBadgesMapperMock,
			                                mock.DALMapperMockFactory.DALBadgesMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.BadgesModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>3e5bf486117aa5701da7bfe5122e4a88</Hash>
</Codenesium>*/