using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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

namespace FermataFishNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LessonStatus")]
	[Trait("Area", "Services")]
	public partial class LessonStatusServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ILessonStatusRepository>();
			var records = new List<LessonStatus>();
			records.Add(new LessonStatus());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LessonStatusService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.LessonStatusModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                      mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                      mock.DALMapperMockFactory.DALLessonMapperMock);

			List<ApiLessonStatusResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ILessonStatusRepository>();
			var record = new LessonStatus();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new LessonStatusService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.LessonStatusModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                      mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                      mock.DALMapperMockFactory.DALLessonMapperMock);

			ApiLessonStatusResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ILessonStatusRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<LessonStatus>(null));
			var service = new LessonStatusService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.LessonStatusModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                      mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                      mock.DALMapperMockFactory.DALLessonMapperMock);

			ApiLessonStatusResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ILessonStatusRepository>();
			var model = new ApiLessonStatusRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LessonStatus>())).Returns(Task.FromResult(new LessonStatus()));
			var service = new LessonStatusService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.LessonStatusModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                      mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                      mock.DALMapperMockFactory.DALLessonMapperMock);

			CreateResponse<ApiLessonStatusResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.LessonStatusModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLessonStatusRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<LessonStatus>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ILessonStatusRepository>();
			var model = new ApiLessonStatusRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LessonStatus>())).Returns(Task.FromResult(new LessonStatus()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LessonStatus()));
			var service = new LessonStatusService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.LessonStatusModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                      mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                      mock.DALMapperMockFactory.DALLessonMapperMock);

			UpdateResponse<ApiLessonStatusResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.LessonStatusModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLessonStatusRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<LessonStatus>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ILessonStatusRepository>();
			var model = new ApiLessonStatusRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new LessonStatusService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.LessonStatusModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                      mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                      mock.DALMapperMockFactory.DALLessonMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.LessonStatusModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Lessons_Exists()
		{
			var mock = new ServiceMockFacade<ILessonStatusRepository>();
			var records = new List<Lesson>();
			records.Add(new Lesson());
			mock.RepositoryMock.Setup(x => x.Lessons(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LessonStatusService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.LessonStatusModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                      mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                      mock.DALMapperMockFactory.DALLessonMapperMock);

			List<ApiLessonResponseModel> response = await service.Lessons(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Lessons(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Lessons_Not_Exists()
		{
			var mock = new ServiceMockFacade<ILessonStatusRepository>();
			mock.RepositoryMock.Setup(x => x.Lessons(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Lesson>>(new List<Lesson>()));
			var service = new LessonStatusService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.LessonStatusModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLLessonStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALLessonStatusMapperMock,
			                                      mock.BOLMapperMockFactory.BOLLessonMapperMock,
			                                      mock.DALMapperMockFactory.DALLessonMapperMock);

			List<ApiLessonResponseModel> response = await service.Lessons(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Lessons(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>c971f3227402b3124d8e1b397dd846ca</Hash>
</Codenesium>*/