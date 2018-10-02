using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ChainStatu")]
	[Trait("Area", "Services")]
	public partial class ChainStatuServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IChainStatuRepository>();
			var records = new List<ChainStatu>();
			records.Add(new ChainStatu());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ChainStatuService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ChainStatuModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLChainStatuMapperMock,
			                                    mock.DALMapperMockFactory.DALChainStatuMapperMock,
			                                    mock.BOLMapperMockFactory.BOLChainMapperMock,
			                                    mock.DALMapperMockFactory.DALChainMapperMock);

			List<ApiChainStatuResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IChainStatuRepository>();
			var record = new ChainStatu();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ChainStatuService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ChainStatuModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLChainStatuMapperMock,
			                                    mock.DALMapperMockFactory.DALChainStatuMapperMock,
			                                    mock.BOLMapperMockFactory.BOLChainMapperMock,
			                                    mock.DALMapperMockFactory.DALChainMapperMock);

			ApiChainStatuResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IChainStatuRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ChainStatu>(null));
			var service = new ChainStatuService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ChainStatuModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLChainStatuMapperMock,
			                                    mock.DALMapperMockFactory.DALChainStatuMapperMock,
			                                    mock.BOLMapperMockFactory.BOLChainMapperMock,
			                                    mock.DALMapperMockFactory.DALChainMapperMock);

			ApiChainStatuResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IChainStatuRepository>();
			var model = new ApiChainStatuRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ChainStatu>())).Returns(Task.FromResult(new ChainStatu()));
			var service = new ChainStatuService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ChainStatuModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLChainStatuMapperMock,
			                                    mock.DALMapperMockFactory.DALChainStatuMapperMock,
			                                    mock.BOLMapperMockFactory.BOLChainMapperMock,
			                                    mock.DALMapperMockFactory.DALChainMapperMock);

			CreateResponse<ApiChainStatuResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ChainStatuModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiChainStatuRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ChainStatu>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IChainStatuRepository>();
			var model = new ApiChainStatuRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ChainStatu>())).Returns(Task.FromResult(new ChainStatu()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatu()));
			var service = new ChainStatuService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ChainStatuModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLChainStatuMapperMock,
			                                    mock.DALMapperMockFactory.DALChainStatuMapperMock,
			                                    mock.BOLMapperMockFactory.BOLChainMapperMock,
			                                    mock.DALMapperMockFactory.DALChainMapperMock);

			UpdateResponse<ApiChainStatuResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ChainStatuModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiChainStatuRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ChainStatu>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IChainStatuRepository>();
			var model = new ApiChainStatuRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ChainStatuService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ChainStatuModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLChainStatuMapperMock,
			                                    mock.DALMapperMockFactory.DALChainStatuMapperMock,
			                                    mock.BOLMapperMockFactory.BOLChainMapperMock,
			                                    mock.DALMapperMockFactory.DALChainMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ChainStatuModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IChainStatuRepository>();
			var record = new ChainStatu();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ChainStatuService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ChainStatuModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLChainStatuMapperMock,
			                                    mock.DALMapperMockFactory.DALChainStatuMapperMock,
			                                    mock.BOLMapperMockFactory.BOLChainMapperMock,
			                                    mock.DALMapperMockFactory.DALChainMapperMock);

			ApiChainStatuResponseModel response = await service.ByName(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IChainStatuRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ChainStatu>(null));
			var service = new ChainStatuService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ChainStatuModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLChainStatuMapperMock,
			                                    mock.DALMapperMockFactory.DALChainStatuMapperMock,
			                                    mock.BOLMapperMockFactory.BOLChainMapperMock,
			                                    mock.DALMapperMockFactory.DALChainMapperMock);

			ApiChainStatuResponseModel response = await service.ByName(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void Chains_Exists()
		{
			var mock = new ServiceMockFacade<IChainStatuRepository>();
			var records = new List<Chain>();
			records.Add(new Chain());
			mock.RepositoryMock.Setup(x => x.Chains(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ChainStatuService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ChainStatuModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLChainStatuMapperMock,
			                                    mock.DALMapperMockFactory.DALChainStatuMapperMock,
			                                    mock.BOLMapperMockFactory.BOLChainMapperMock,
			                                    mock.DALMapperMockFactory.DALChainMapperMock);

			List<ApiChainResponseModel> response = await service.Chains(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Chains(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Chains_Not_Exists()
		{
			var mock = new ServiceMockFacade<IChainStatuRepository>();
			mock.RepositoryMock.Setup(x => x.Chains(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Chain>>(new List<Chain>()));
			var service = new ChainStatuService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.ChainStatuModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLChainStatuMapperMock,
			                                    mock.DALMapperMockFactory.DALChainStatuMapperMock,
			                                    mock.BOLMapperMockFactory.BOLChainMapperMock,
			                                    mock.DALMapperMockFactory.DALChainMapperMock);

			List<ApiChainResponseModel> response = await service.Chains(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Chains(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>a2b1b519edfd9c318eb4d92aa34a1917</Hash>
</Codenesium>*/