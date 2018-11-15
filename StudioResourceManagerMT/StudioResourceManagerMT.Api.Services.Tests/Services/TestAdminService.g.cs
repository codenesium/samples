using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Admin")]
	[Trait("Area", "Services")]
	public partial class AdminServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IAdminRepository>();
			var records = new List<Admin>();
			records.Add(new Admin());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new AdminService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                               mock.DALMapperMockFactory.DALAdminMapperMock);

			List<ApiAdminServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IAdminRepository>();
			var record = new Admin();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new AdminService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                               mock.DALMapperMockFactory.DALAdminMapperMock);

			ApiAdminServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IAdminRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Admin>(null));
			var service = new AdminService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                               mock.DALMapperMockFactory.DALAdminMapperMock);

			ApiAdminServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IAdminRepository>();
			var model = new ApiAdminServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Admin>())).Returns(Task.FromResult(new Admin()));
			var service = new AdminService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                               mock.DALMapperMockFactory.DALAdminMapperMock);

			CreateResponse<ApiAdminServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.AdminModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiAdminServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Admin>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IAdminRepository>();
			var model = new ApiAdminServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Admin>())).Returns(Task.FromResult(new Admin()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));
			var service = new AdminService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                               mock.DALMapperMockFactory.DALAdminMapperMock);

			UpdateResponse<ApiAdminServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.AdminModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAdminServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Admin>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IAdminRepository>();
			var model = new ApiAdminServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new AdminService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                               mock.DALMapperMockFactory.DALAdminMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.AdminModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByUserId_Exists()
		{
			var mock = new ServiceMockFacade<IAdminRepository>();
			var records = new List<Admin>();
			records.Add(new Admin());
			mock.RepositoryMock.Setup(x => x.ByUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new AdminService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                               mock.DALMapperMockFactory.DALAdminMapperMock);

			List<ApiAdminServerResponseModel> response = await service.ByUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IAdminRepository>();
			mock.RepositoryMock.Setup(x => x.ByUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Admin>>(new List<Admin>()));
			var service = new AdminService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLAdminMapperMock,
			                               mock.DALMapperMockFactory.DALAdminMapperMock);

			List<ApiAdminServerResponseModel> response = await service.ByUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>6c88d8fe00df7c46b916b89b1598f7cd</Hash>
</Codenesium>*/