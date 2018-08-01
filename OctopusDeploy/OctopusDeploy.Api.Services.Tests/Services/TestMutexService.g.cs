using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Mutex")]
	[Trait("Area", "Services")]
	public partial class MutexServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IMutexRepository>();
			var records = new List<Mutex>();
			records.Add(new Mutex());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new MutexService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.MutexModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLMutexMapperMock,
			                               mock.DALMapperMockFactory.DALMutexMapperMock);

			List<ApiMutexResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IMutexRepository>();
			var record = new Mutex();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new MutexService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.MutexModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLMutexMapperMock,
			                               mock.DALMapperMockFactory.DALMutexMapperMock);

			ApiMutexResponseModel response = await service.Get(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IMutexRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Mutex>(null));
			var service = new MutexService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.MutexModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLMutexMapperMock,
			                               mock.DALMapperMockFactory.DALMutexMapperMock);

			ApiMutexResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IMutexRepository>();
			var model = new ApiMutexRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Mutex>())).Returns(Task.FromResult(new Mutex()));
			var service = new MutexService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.MutexModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLMutexMapperMock,
			                               mock.DALMapperMockFactory.DALMutexMapperMock);

			CreateResponse<ApiMutexResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.MutexModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiMutexRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Mutex>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IMutexRepository>();
			var model = new ApiMutexRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Mutex>())).Returns(Task.FromResult(new Mutex()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Mutex()));
			var service = new MutexService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.MutexModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLMutexMapperMock,
			                               mock.DALMapperMockFactory.DALMutexMapperMock);

			UpdateResponse<ApiMutexResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.MutexModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiMutexRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Mutex>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IMutexRepository>();
			var model = new ApiMutexRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
			var service = new MutexService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.MutexModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLMutexMapperMock,
			                               mock.DALMapperMockFactory.DALMutexMapperMock);

			ActionResponse response = await service.Delete(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
			mock.ModelValidatorMockFactory.MutexModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>6a6e91341316ce1d8ee91043e9010a2f</Hash>
</Codenesium>*/