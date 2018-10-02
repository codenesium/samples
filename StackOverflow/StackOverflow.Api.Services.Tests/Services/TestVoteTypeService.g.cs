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
	[Trait("Table", "VoteType")]
	[Trait("Area", "Services")]
	public partial class VoteTypeServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IVoteTypeRepository>();
			var records = new List<VoteType>();
			records.Add(new VoteType());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VoteTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.VoteTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLVoteTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALVoteTypeMapperMock);

			List<ApiVoteTypeResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IVoteTypeRepository>();
			var record = new VoteType();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VoteTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.VoteTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLVoteTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALVoteTypeMapperMock);

			ApiVoteTypeResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IVoteTypeRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<VoteType>(null));
			var service = new VoteTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.VoteTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLVoteTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALVoteTypeMapperMock);

			ApiVoteTypeResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IVoteTypeRepository>();
			var model = new ApiVoteTypeRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VoteType>())).Returns(Task.FromResult(new VoteType()));
			var service = new VoteTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.VoteTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLVoteTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALVoteTypeMapperMock);

			CreateResponse<ApiVoteTypeResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.VoteTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVoteTypeRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<VoteType>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IVoteTypeRepository>();
			var model = new ApiVoteTypeRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VoteType>())).Returns(Task.FromResult(new VoteType()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VoteType()));
			var service = new VoteTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.VoteTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLVoteTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALVoteTypeMapperMock);

			UpdateResponse<ApiVoteTypeResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.VoteTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVoteTypeRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<VoteType>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IVoteTypeRepository>();
			var model = new ApiVoteTypeRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VoteTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.VoteTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLVoteTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALVoteTypeMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VoteTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>ad2be0b89cd403e9a7d780f86c960aa7</Hash>
</Codenesium>*/