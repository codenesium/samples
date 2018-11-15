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
	[Trait("Table", "Badge")]
	[Trait("Area", "Services")]
	public partial class BadgeServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IBadgeRepository>();
			var records = new List<Badge>();
			records.Add(new Badge());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new BadgeService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BadgeModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLBadgeMapperMock,
			                               mock.DALMapperMockFactory.DALBadgeMapperMock);

			List<ApiBadgeServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IBadgeRepository>();
			var record = new Badge();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new BadgeService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BadgeModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLBadgeMapperMock,
			                               mock.DALMapperMockFactory.DALBadgeMapperMock);

			ApiBadgeServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IBadgeRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Badge>(null));
			var service = new BadgeService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BadgeModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLBadgeMapperMock,
			                               mock.DALMapperMockFactory.DALBadgeMapperMock);

			ApiBadgeServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IBadgeRepository>();
			var model = new ApiBadgeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Badge>())).Returns(Task.FromResult(new Badge()));
			var service = new BadgeService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BadgeModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLBadgeMapperMock,
			                               mock.DALMapperMockFactory.DALBadgeMapperMock);

			CreateResponse<ApiBadgeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.BadgeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiBadgeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Badge>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IBadgeRepository>();
			var model = new ApiBadgeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Badge>())).Returns(Task.FromResult(new Badge()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Badge()));
			var service = new BadgeService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BadgeModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLBadgeMapperMock,
			                               mock.DALMapperMockFactory.DALBadgeMapperMock);

			UpdateResponse<ApiBadgeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.BadgeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBadgeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Badge>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IBadgeRepository>();
			var model = new ApiBadgeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new BadgeService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BadgeModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLBadgeMapperMock,
			                               mock.DALMapperMockFactory.DALBadgeMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.BadgeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>5ae008434479ed58be5581144976f642</Hash>
</Codenesium>*/