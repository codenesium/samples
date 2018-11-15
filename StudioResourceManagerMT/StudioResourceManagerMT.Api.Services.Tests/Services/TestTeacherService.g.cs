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
	[Trait("Table", "Teacher")]
	[Trait("Area", "Services")]
	public partial class TeacherServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			var records = new List<Teacher>();
			records.Add(new Teacher());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock);

			List<ApiTeacherServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			var record = new Teacher();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock);

			ApiTeacherServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(null));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock);

			ApiTeacherServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			var model = new ApiTeacherServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Teacher>())).Returns(Task.FromResult(new Teacher()));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock);

			CreateResponse<ApiTeacherServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Teacher>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			var model = new ApiTeacherServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Teacher>())).Returns(Task.FromResult(new Teacher()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock);

			UpdateResponse<ApiTeacherServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Teacher>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			var model = new ApiTeacherServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByUserId_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			var records = new List<Teacher>();
			records.Add(new Teacher());
			mock.RepositoryMock.Setup(x => x.ByUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock);

			List<ApiTeacherServerResponseModel> response = await service.ByUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			mock.RepositoryMock.Setup(x => x.ByUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Teacher>>(new List<Teacher>()));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock);

			List<ApiTeacherServerResponseModel> response = await service.ByUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void RatesByTeacherId_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			var records = new List<Rate>();
			records.Add(new Rate());
			mock.RepositoryMock.Setup(x => x.RatesByTeacherId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock);

			List<ApiRateServerResponseModel> response = await service.RatesByTeacherId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.RatesByTeacherId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void RatesByTeacherId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITeacherRepository>();
			mock.RepositoryMock.Setup(x => x.RatesByTeacherId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Rate>>(new List<Rate>()));
			var service = new TeacherService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.TeacherModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLTeacherMapperMock,
			                                 mock.DALMapperMockFactory.DALTeacherMapperMock,
			                                 mock.BOLMapperMockFactory.BOLRateMapperMock,
			                                 mock.DALMapperMockFactory.DALRateMapperMock);

			List<ApiRateServerResponseModel> response = await service.RatesByTeacherId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.RatesByTeacherId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>b37ef775ab4ecc7170260bb6af4fa4ee</Hash>
</Codenesium>*/