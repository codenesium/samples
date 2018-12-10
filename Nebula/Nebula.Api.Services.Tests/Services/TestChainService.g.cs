using FluentAssertions;
using FluentValidation.Results;
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
	[Trait("Table", "Chain")]
	[Trait("Area", "Services")]
	public partial class ChainServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			var records = new List<Chain>();
			records.Add(new Chain());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiChainServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			var record = new Chain();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiChainServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Chain>(null));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiChainServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			var model = new ApiChainServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Chain>())).Returns(Task.FromResult(new Chain()));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			CreateResponse<ApiChainServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ChainModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiChainServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Chain>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			var model = new ApiChainServerRequestModel();
			var validatorMock = new Mock<IApiChainServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiChainServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			CreateResponse<ApiChainServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiChainServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			var model = new ApiChainServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Chain>())).Returns(Task.FromResult(new Chain()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Chain()));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			UpdateResponse<ApiChainServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ChainModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiChainServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Chain>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			var model = new ApiChainServerRequestModel();
			var validatorMock = new Mock<IApiChainServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiChainServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Chain()));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			UpdateResponse<ApiChainServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiChainServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			var model = new ApiChainServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ChainModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			var model = new ApiChainServerRequestModel();
			var validatorMock = new Mock<IApiChainServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByExternalId_Exists()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			var record = new Chain();
			mock.RepositoryMock.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiChainServerResponseModel response = await service.ByExternalId(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByExternalId(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByExternalId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			mock.RepositoryMock.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<Chain>(null));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiChainServerResponseModel response = await service.ByExternalId(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByExternalId(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ClaspsByNextChainId_Exists()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			var records = new List<Clasp>();
			records.Add(new Clasp());
			mock.RepositoryMock.Setup(x => x.ClaspsByNextChainId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiClaspServerResponseModel> response = await service.ClaspsByNextChainId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ClaspsByNextChainId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ClaspsByNextChainId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			mock.RepositoryMock.Setup(x => x.ClaspsByNextChainId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Clasp>>(new List<Clasp>()));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiClaspServerResponseModel> response = await service.ClaspsByNextChainId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ClaspsByNextChainId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ClaspsByPreviousChainId_Exists()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			var records = new List<Clasp>();
			records.Add(new Clasp());
			mock.RepositoryMock.Setup(x => x.ClaspsByPreviousChainId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiClaspServerResponseModel> response = await service.ClaspsByPreviousChainId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ClaspsByPreviousChainId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ClaspsByPreviousChainId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			mock.RepositoryMock.Setup(x => x.ClaspsByPreviousChainId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Clasp>>(new List<Clasp>()));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiClaspServerResponseModel> response = await service.ClaspsByPreviousChainId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ClaspsByPreviousChainId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void LinksByChainId_Exists()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			var records = new List<Link>();
			records.Add(new Link());
			mock.RepositoryMock.Setup(x => x.LinksByChainId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiLinkServerResponseModel> response = await service.LinksByChainId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.LinksByChainId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void LinksByChainId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IChainRepository>();
			mock.RepositoryMock.Setup(x => x.LinksByChainId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Link>>(new List<Link>()));
			var service = new ChainService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ChainModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLChainMapperMock,
			                               mock.DALMapperMockFactory.DALChainMapperMock,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock,
			                               mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                               mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiLinkServerResponseModel> response = await service.LinksByChainId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.LinksByChainId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>8ac09094c7c5ea0cc3e819716ed2dbee</Hash>
</Codenesium>*/