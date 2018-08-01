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
	[Trait("Table", "VoteTypes")]
	[Trait("Area", "Services")]
	public partial class VoteTypesServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IVoteTypesRepository>();
			var records = new List<VoteTypes>();
			records.Add(new VoteTypes());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VoteTypesService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.VoteTypesModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLVoteTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALVoteTypesMapperMock);

			List<ApiVoteTypesResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IVoteTypesRepository>();
			var record = new VoteTypes();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VoteTypesService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.VoteTypesModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLVoteTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALVoteTypesMapperMock);

			ApiVoteTypesResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IVoteTypesRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<VoteTypes>(null));
			var service = new VoteTypesService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.VoteTypesModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLVoteTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALVoteTypesMapperMock);

			ApiVoteTypesResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IVoteTypesRepository>();
			var model = new ApiVoteTypesRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VoteTypes>())).Returns(Task.FromResult(new VoteTypes()));
			var service = new VoteTypesService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.VoteTypesModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLVoteTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALVoteTypesMapperMock);

			CreateResponse<ApiVoteTypesResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.VoteTypesModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVoteTypesRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<VoteTypes>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IVoteTypesRepository>();
			var model = new ApiVoteTypesRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VoteTypes>())).Returns(Task.FromResult(new VoteTypes()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VoteTypes()));
			var service = new VoteTypesService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.VoteTypesModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLVoteTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALVoteTypesMapperMock);

			UpdateResponse<ApiVoteTypesResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.VoteTypesModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVoteTypesRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<VoteTypes>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IVoteTypesRepository>();
			var model = new ApiVoteTypesRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VoteTypesService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.VoteTypesModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLVoteTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALVoteTypesMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VoteTypesModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>192b58f334e3bfa4d912ac5251eaa615</Hash>
</Codenesium>*/