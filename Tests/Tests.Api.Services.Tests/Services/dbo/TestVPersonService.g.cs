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

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IVPersonRepository>();
			var model = new ApiVPersonRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VPerson>())).Returns(Task.FromResult(new VPerson()));
			var service = new VPersonService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VPersonModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLVPersonMapperMock,
			                                 mock.DALMapperMockFactory.DALVPersonMapperMock);

			CreateResponse<ApiVPersonResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.VPersonModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVPersonRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<VPerson>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IVPersonRepository>();
			var model = new ApiVPersonRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<VPerson>())).Returns(Task.FromResult(new VPerson()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VPerson()));
			var service = new VPersonService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VPersonModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLVPersonMapperMock,
			                                 mock.DALMapperMockFactory.DALVPersonMapperMock);

			UpdateResponse<ApiVPersonResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.VPersonModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVPersonRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<VPerson>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IVPersonRepository>();
			var model = new ApiVPersonRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VPersonService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VPersonModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLVPersonMapperMock,
			                                 mock.DALMapperMockFactory.DALVPersonMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VPersonModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByPersonId_Exists()
		{
			var mock = new ServiceMockFacade<IVPersonRepository>();
			var record = new VPerson();
			mock.RepositoryMock.Setup(x => x.ByPersonId(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VPersonService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VPersonModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLVPersonMapperMock,
			                                 mock.DALMapperMockFactory.DALVPersonMapperMock);

			ApiVPersonResponseModel response = await service.ByPersonId(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByPersonId(It.IsAny<int>()));
		}

		[Fact]
		public async void ByPersonId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVPersonRepository>();
			mock.RepositoryMock.Setup(x => x.ByPersonId(It.IsAny<int>())).Returns(Task.FromResult<VPerson>(null));
			var service = new VPersonService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.VPersonModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLVPersonMapperMock,
			                                 mock.DALMapperMockFactory.DALVPersonMapperMock);

			ApiVPersonResponseModel response = await service.ByPersonId(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByPersonId(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>5ceda353bd0cf0d0530a11bbf2282df1</Hash>
</Codenesium>*/