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
	[Trait("Table", "PersonRef")]
	[Trait("Area", "Services")]
	public partial class PersonRefServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPersonRefRepository>();
			var records = new List<PersonRef>();
			records.Add(new PersonRef());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PersonRefService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PersonRefModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                   mock.DALMapperMockFactory.DALPersonRefMapperMock);

			List<ApiPersonRefResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPersonRefRepository>();
			var record = new PersonRef();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PersonRefService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PersonRefModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                   mock.DALMapperMockFactory.DALPersonRefMapperMock);

			ApiPersonRefResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPersonRefRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PersonRef>(null));
			var service = new PersonRefService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PersonRefModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                   mock.DALMapperMockFactory.DALPersonRefMapperMock);

			ApiPersonRefResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IPersonRefRepository>();
			var model = new ApiPersonRefRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PersonRef>())).Returns(Task.FromResult(new PersonRef()));
			var service = new PersonRefService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PersonRefModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                   mock.DALMapperMockFactory.DALPersonRefMapperMock);

			CreateResponse<ApiPersonRefResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PersonRefModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPersonRefRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PersonRef>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IPersonRefRepository>();
			var model = new ApiPersonRefRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PersonRef>())).Returns(Task.FromResult(new PersonRef()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PersonRef()));
			var service = new PersonRefService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PersonRefModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                   mock.DALMapperMockFactory.DALPersonRefMapperMock);

			UpdateResponse<ApiPersonRefResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PersonRefModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonRefRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PersonRef>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IPersonRefRepository>();
			var model = new ApiPersonRefRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PersonRefService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PersonRefModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                   mock.DALMapperMockFactory.DALPersonRefMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PersonRefModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>36b3f7b841232ccd4baff8f66ec79aad</Hash>
</Codenesium>*/