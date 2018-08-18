using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Clasp")]
	[Trait("Area", "Services")]
	public partial class ClaspServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IClaspRepository>();
			var records = new List<Clasp>();
			records.Add(new Clasp());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ClaspService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ClaspModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock);

			List<ApiClaspResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IClaspRepository>();
			var record = new Clasp();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ClaspService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ClaspModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock);

			ApiClaspResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IClaspRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Clasp>(null));
			var service = new ClaspService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ClaspModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock);

			ApiClaspResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IClaspRepository>();
			var model = new ApiClaspRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Clasp>())).Returns(Task.FromResult(new Clasp()));
			var service = new ClaspService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ClaspModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock);

			CreateResponse<ApiClaspResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ClaspModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiClaspRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Clasp>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IClaspRepository>();
			var model = new ApiClaspRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Clasp>())).Returns(Task.FromResult(new Clasp()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Clasp()));
			var service = new ClaspService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ClaspModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock);

			UpdateResponse<ApiClaspResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ClaspModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiClaspRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Clasp>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IClaspRepository>();
			var model = new ApiClaspRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ClaspService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.ClaspModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLClaspMapperMock,
			                               mock.DALMapperMockFactory.DALClaspMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ClaspModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>c6b054ba26843a304d60ea71b9f69492</Hash>
</Codenesium>*/