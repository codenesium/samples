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
	[Trait("Table", "KeyAllocation")]
	[Trait("Area", "Services")]
	public partial class KeyAllocationServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IKeyAllocationRepository>();
			var records = new List<KeyAllocation>();
			records.Add(new KeyAllocation());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new KeyAllocationService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.KeyAllocationModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLKeyAllocationMapperMock,
			                                       mock.DALMapperMockFactory.DALKeyAllocationMapperMock);

			List<ApiKeyAllocationResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IKeyAllocationRepository>();
			var record = new KeyAllocation();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new KeyAllocationService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.KeyAllocationModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLKeyAllocationMapperMock,
			                                       mock.DALMapperMockFactory.DALKeyAllocationMapperMock);

			ApiKeyAllocationResponseModel response = await service.Get(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IKeyAllocationRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<KeyAllocation>(null));
			var service = new KeyAllocationService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.KeyAllocationModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLKeyAllocationMapperMock,
			                                       mock.DALMapperMockFactory.DALKeyAllocationMapperMock);

			ApiKeyAllocationResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IKeyAllocationRepository>();
			var model = new ApiKeyAllocationRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<KeyAllocation>())).Returns(Task.FromResult(new KeyAllocation()));
			var service = new KeyAllocationService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.KeyAllocationModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLKeyAllocationMapperMock,
			                                       mock.DALMapperMockFactory.DALKeyAllocationMapperMock);

			CreateResponse<ApiKeyAllocationResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.KeyAllocationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiKeyAllocationRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<KeyAllocation>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IKeyAllocationRepository>();
			var model = new ApiKeyAllocationRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<KeyAllocation>())).Returns(Task.FromResult(new KeyAllocation()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new KeyAllocation()));
			var service = new KeyAllocationService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.KeyAllocationModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLKeyAllocationMapperMock,
			                                       mock.DALMapperMockFactory.DALKeyAllocationMapperMock);

			UpdateResponse<ApiKeyAllocationResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.KeyAllocationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiKeyAllocationRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<KeyAllocation>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IKeyAllocationRepository>();
			var model = new ApiKeyAllocationRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
			var service = new KeyAllocationService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.KeyAllocationModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLKeyAllocationMapperMock,
			                                       mock.DALMapperMockFactory.DALKeyAllocationMapperMock);

			ActionResponse response = await service.Delete(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
			mock.ModelValidatorMockFactory.KeyAllocationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>46b3eccb21df945c35f0017f8d2f353a</Hash>
</Codenesium>*/