using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VProductAndDescription")]
	[Trait("Area", "Services")]
	public partial class VProductAndDescriptionServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IVProductAndDescriptionRepository>();
			var records = new List<VProductAndDescription>();
			records.Add(new VProductAndDescription());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VProductAndDescriptionService(mock.LoggerMock.Object,
			                                                mock.RepositoryMock.Object,
			                                                mock.ModelValidatorMockFactory.VProductAndDescriptionModelValidatorMock.Object,
			                                                mock.BOLMapperMockFactory.BOLVProductAndDescriptionMapperMock,
			                                                mock.DALMapperMockFactory.DALVProductAndDescriptionMapperMock);

			List<ApiVProductAndDescriptionResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IVProductAndDescriptionRepository>();
			var record = new VProductAndDescription();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new VProductAndDescriptionService(mock.LoggerMock.Object,
			                                                mock.RepositoryMock.Object,
			                                                mock.ModelValidatorMockFactory.VProductAndDescriptionModelValidatorMock.Object,
			                                                mock.BOLMapperMockFactory.BOLVProductAndDescriptionMapperMock,
			                                                mock.DALMapperMockFactory.DALVProductAndDescriptionMapperMock);

			ApiVProductAndDescriptionResponseModel response = await service.Get(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IVProductAndDescriptionRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<VProductAndDescription>(null));
			var service = new VProductAndDescriptionService(mock.LoggerMock.Object,
			                                                mock.RepositoryMock.Object,
			                                                mock.ModelValidatorMockFactory.VProductAndDescriptionModelValidatorMock.Object,
			                                                mock.BOLMapperMockFactory.BOLVProductAndDescriptionMapperMock,
			                                                mock.DALMapperMockFactory.DALVProductAndDescriptionMapperMock);

			ApiVProductAndDescriptionResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>a6aa9a0b175e76281ae91136c167684f</Hash>
</Codenesium>*/