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
	[Trait("Table", "IncludedColumnTest")]
	[Trait("Area", "Services")]
	public partial class IncludedColumnTestServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IIncludedColumnTestRepository>();
			var records = new List<IncludedColumnTest>();
			records.Add(new IncludedColumnTest());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new IncludedColumnTestService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.IncludedColumnTestModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLIncludedColumnTestMapperMock,
			                                            mock.DALMapperMockFactory.DALIncludedColumnTestMapperMock);

			List<ApiIncludedColumnTestResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IIncludedColumnTestRepository>();
			var record = new IncludedColumnTest();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new IncludedColumnTestService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.IncludedColumnTestModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLIncludedColumnTestMapperMock,
			                                            mock.DALMapperMockFactory.DALIncludedColumnTestMapperMock);

			ApiIncludedColumnTestResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IIncludedColumnTestRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<IncludedColumnTest>(null));
			var service = new IncludedColumnTestService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.IncludedColumnTestModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLIncludedColumnTestMapperMock,
			                                            mock.DALMapperMockFactory.DALIncludedColumnTestMapperMock);

			ApiIncludedColumnTestResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IIncludedColumnTestRepository>();
			var model = new ApiIncludedColumnTestRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<IncludedColumnTest>())).Returns(Task.FromResult(new IncludedColumnTest()));
			var service = new IncludedColumnTestService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.IncludedColumnTestModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLIncludedColumnTestMapperMock,
			                                            mock.DALMapperMockFactory.DALIncludedColumnTestMapperMock);

			CreateResponse<ApiIncludedColumnTestResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.IncludedColumnTestModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiIncludedColumnTestRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<IncludedColumnTest>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IIncludedColumnTestRepository>();
			var model = new ApiIncludedColumnTestRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<IncludedColumnTest>())).Returns(Task.FromResult(new IncludedColumnTest()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new IncludedColumnTest()));
			var service = new IncludedColumnTestService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.IncludedColumnTestModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLIncludedColumnTestMapperMock,
			                                            mock.DALMapperMockFactory.DALIncludedColumnTestMapperMock);

			UpdateResponse<ApiIncludedColumnTestResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.IncludedColumnTestModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiIncludedColumnTestRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<IncludedColumnTest>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IIncludedColumnTestRepository>();
			var model = new ApiIncludedColumnTestRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new IncludedColumnTestService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.IncludedColumnTestModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLIncludedColumnTestMapperMock,
			                                            mock.DALMapperMockFactory.DALIncludedColumnTestMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.IncludedColumnTestModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>edbdfa85903dcb84c514780b7767c19f</Hash>
</Codenesium>*/