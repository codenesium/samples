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
	[Trait("Table", "Votes")]
	[Trait("Area", "Services")]
	public partial class VotesServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IVotesRepository>();
			var records = new List<Votes>();
			records.Add(new Votes());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VotesService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VotesModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLVotesMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock);

			List<ApiVotesResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IVotesRepository>();
			var record = new Votes();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VotesService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VotesModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLVotesMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock);

			ApiVotesResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IVotesRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Votes>(null));
			var service = new VotesService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VotesModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLVotesMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock);

			ApiVotesResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IVotesRepository>();
			var model = new ApiVotesRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Votes>())).Returns(Task.FromResult(new Votes()));
			var service = new VotesService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VotesModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLVotesMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock);

			CreateResponse<ApiVotesResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.VotesModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVotesRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Votes>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IVotesRepository>();
			var model = new ApiVotesRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Votes>())).Returns(Task.FromResult(new Votes()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Votes()));
			var service = new VotesService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VotesModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLVotesMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock);

			UpdateResponse<ApiVotesResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.VotesModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVotesRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Votes>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IVotesRepository>();
			var model = new ApiVotesRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VotesService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.VotesModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLVotesMapperMock,
			                               mock.DALMapperMockFactory.DALVotesMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VotesModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>31e88b047a51841dcc011c66d4e532ad</Hash>
</Codenesium>*/