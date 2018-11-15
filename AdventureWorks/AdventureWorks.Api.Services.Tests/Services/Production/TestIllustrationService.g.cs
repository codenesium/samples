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
	[Trait("Table", "Illustration")]
	[Trait("Area", "Services")]
	public partial class IllustrationServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IIllustrationRepository>();
			var records = new List<Illustration>();
			records.Add(new Illustration());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new IllustrationService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.IllustrationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLIllustrationMapperMock,
			                                      mock.DALMapperMockFactory.DALIllustrationMapperMock);

			List<ApiIllustrationServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IIllustrationRepository>();
			var record = new Illustration();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new IllustrationService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.IllustrationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLIllustrationMapperMock,
			                                      mock.DALMapperMockFactory.DALIllustrationMapperMock);

			ApiIllustrationServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IIllustrationRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Illustration>(null));
			var service = new IllustrationService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.IllustrationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLIllustrationMapperMock,
			                                      mock.DALMapperMockFactory.DALIllustrationMapperMock);

			ApiIllustrationServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IIllustrationRepository>();
			var model = new ApiIllustrationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Illustration>())).Returns(Task.FromResult(new Illustration()));
			var service = new IllustrationService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.IllustrationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLIllustrationMapperMock,
			                                      mock.DALMapperMockFactory.DALIllustrationMapperMock);

			CreateResponse<ApiIllustrationServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.IllustrationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiIllustrationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Illustration>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IIllustrationRepository>();
			var model = new ApiIllustrationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Illustration>())).Returns(Task.FromResult(new Illustration()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Illustration()));
			var service = new IllustrationService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.IllustrationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLIllustrationMapperMock,
			                                      mock.DALMapperMockFactory.DALIllustrationMapperMock);

			UpdateResponse<ApiIllustrationServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.IllustrationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiIllustrationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Illustration>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IIllustrationRepository>();
			var model = new ApiIllustrationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new IllustrationService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.IllustrationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLIllustrationMapperMock,
			                                      mock.DALMapperMockFactory.DALIllustrationMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.IllustrationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>55c54a6348cf7e15ff4acd31c5d982f6</Hash>
</Codenesium>*/