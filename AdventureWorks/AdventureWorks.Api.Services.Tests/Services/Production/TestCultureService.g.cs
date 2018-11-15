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
	[Trait("Table", "Culture")]
	[Trait("Area", "Services")]
	public partial class CultureServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ICultureRepository>();
			var records = new List<Culture>();
			records.Add(new Culture());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CultureService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CultureModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCultureMapperMock,
			                                 mock.DALMapperMockFactory.DALCultureMapperMock);

			List<ApiCultureServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ICultureRepository>();
			var record = new Culture();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new CultureService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CultureModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCultureMapperMock,
			                                 mock.DALMapperMockFactory.DALCultureMapperMock);

			ApiCultureServerResponseModel response = await service.Get(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ICultureRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Culture>(null));
			var service = new CultureService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CultureModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCultureMapperMock,
			                                 mock.DALMapperMockFactory.DALCultureMapperMock);

			ApiCultureServerResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ICultureRepository>();
			var model = new ApiCultureServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Culture>())).Returns(Task.FromResult(new Culture()));
			var service = new CultureService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CultureModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCultureMapperMock,
			                                 mock.DALMapperMockFactory.DALCultureMapperMock);

			CreateResponse<ApiCultureServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.CultureModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCultureServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Culture>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ICultureRepository>();
			var model = new ApiCultureServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Culture>())).Returns(Task.FromResult(new Culture()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Culture()));
			var service = new CultureService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CultureModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCultureMapperMock,
			                                 mock.DALMapperMockFactory.DALCultureMapperMock);

			UpdateResponse<ApiCultureServerResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.CultureModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiCultureServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Culture>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ICultureRepository>();
			var model = new ApiCultureServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
			var service = new CultureService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CultureModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCultureMapperMock,
			                                 mock.DALMapperMockFactory.DALCultureMapperMock);

			ActionResponse response = await service.Delete(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
			mock.ModelValidatorMockFactory.CultureModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<ICultureRepository>();
			var record = new Culture();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new CultureService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CultureModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCultureMapperMock,
			                                 mock.DALMapperMockFactory.DALCultureMapperMock);

			ApiCultureServerResponseModel response = await service.ByName("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICultureRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Culture>(null));
			var service = new CultureService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CultureModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCultureMapperMock,
			                                 mock.DALMapperMockFactory.DALCultureMapperMock);

			ApiCultureServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>29c8ee64d123fdb292711181a6659099</Hash>
</Codenesium>*/