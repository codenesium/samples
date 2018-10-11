using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VPerson")]
	[Trait("Area", "Services")]
	public partial class VPersonServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IVPersonRepository>();
			var records = new List<VPerson>();
			records.Add(new VPerson());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VPersonService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VPersonModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLVPersonMapperMock,
			                                 mock.DALMapperMockFactory.DALVPersonMapperMock);

			List<ApiVPersonResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IVPersonRepository>();
			var record = new VPerson();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VPersonService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VPersonModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLVPersonMapperMock,
			                                 mock.DALMapperMockFactory.DALVPersonMapperMock);

			ApiVPersonResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IVPersonRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<VPerson>(null));
			var service = new VPersonService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VPersonModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLVPersonMapperMock,
			                                 mock.DALMapperMockFactory.DALVPersonMapperMock);

			ApiVPersonResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>62dbd62f2ccd91a317cf59469064df41</Hash>
</Codenesium>*/