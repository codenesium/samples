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
	[Trait("Table", "TimestampCheck")]
	[Trait("Area", "Services")]
	public partial class TimestampCheckServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITimestampCheckRepository>();
			var records = new List<TimestampCheck>();
			records.Add(new TimestampCheck());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TimestampCheckService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.TimestampCheckModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLTimestampCheckMapperMock,
			                                        mock.DALMapperMockFactory.DALTimestampCheckMapperMock);

			List<ApiTimestampCheckServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITimestampCheckRepository>();
			var record = new TimestampCheck();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TimestampCheckService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.TimestampCheckModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLTimestampCheckMapperMock,
			                                        mock.DALMapperMockFactory.DALTimestampCheckMapperMock);

			ApiTimestampCheckServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITimestampCheckRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TimestampCheck>(null));
			var service = new TimestampCheckService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.TimestampCheckModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLTimestampCheckMapperMock,
			                                        mock.DALMapperMockFactory.DALTimestampCheckMapperMock);

			ApiTimestampCheckServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ITimestampCheckRepository>();
			var model = new ApiTimestampCheckServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TimestampCheck>())).Returns(Task.FromResult(new TimestampCheck()));
			var service = new TimestampCheckService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.TimestampCheckModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLTimestampCheckMapperMock,
			                                        mock.DALMapperMockFactory.DALTimestampCheckMapperMock);

			CreateResponse<ApiTimestampCheckServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TimestampCheckModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTimestampCheckServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TimestampCheck>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ITimestampCheckRepository>();
			var model = new ApiTimestampCheckServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TimestampCheck>())).Returns(Task.FromResult(new TimestampCheck()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TimestampCheck()));
			var service = new TimestampCheckService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.TimestampCheckModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLTimestampCheckMapperMock,
			                                        mock.DALMapperMockFactory.DALTimestampCheckMapperMock);

			UpdateResponse<ApiTimestampCheckServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TimestampCheckModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTimestampCheckServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TimestampCheck>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ITimestampCheckRepository>();
			var model = new ApiTimestampCheckServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TimestampCheckService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.TimestampCheckModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLTimestampCheckMapperMock,
			                                        mock.DALMapperMockFactory.DALTimestampCheckMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TimestampCheckModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>d9ec003a1fb6e19d25b9e9a21a3a3381</Hash>
</Codenesium>*/