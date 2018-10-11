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
	[Trait("Table", "SelfReference")]
	[Trait("Area", "Services")]
	public partial class SelfReferenceServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISelfReferenceRepository>();
			var records = new List<SelfReference>();
			records.Add(new SelfReference());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SelfReferenceService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSelfReferenceMapperMock,
			                                       mock.DALMapperMockFactory.DALSelfReferenceMapperMock);

			List<ApiSelfReferenceResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISelfReferenceRepository>();
			var record = new SelfReference();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SelfReferenceService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSelfReferenceMapperMock,
			                                       mock.DALMapperMockFactory.DALSelfReferenceMapperMock);

			ApiSelfReferenceResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISelfReferenceRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SelfReference>(null));
			var service = new SelfReferenceService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSelfReferenceMapperMock,
			                                       mock.DALMapperMockFactory.DALSelfReferenceMapperMock);

			ApiSelfReferenceResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ISelfReferenceRepository>();
			var model = new ApiSelfReferenceRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SelfReference>())).Returns(Task.FromResult(new SelfReference()));
			var service = new SelfReferenceService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSelfReferenceMapperMock,
			                                       mock.DALMapperMockFactory.DALSelfReferenceMapperMock);

			CreateResponse<ApiSelfReferenceResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSelfReferenceRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SelfReference>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ISelfReferenceRepository>();
			var model = new ApiSelfReferenceRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SelfReference>())).Returns(Task.FromResult(new SelfReference()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SelfReference()));
			var service = new SelfReferenceService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSelfReferenceMapperMock,
			                                       mock.DALMapperMockFactory.DALSelfReferenceMapperMock);

			UpdateResponse<ApiSelfReferenceResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSelfReferenceRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SelfReference>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ISelfReferenceRepository>();
			var model = new ApiSelfReferenceRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SelfReferenceService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSelfReferenceMapperMock,
			                                       mock.DALMapperMockFactory.DALSelfReferenceMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>69e93f0b1093d78a77454e6b0cad8293</Hash>
</Codenesium>*/