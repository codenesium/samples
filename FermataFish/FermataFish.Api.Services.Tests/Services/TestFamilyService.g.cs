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
	[Trait("Table", "Family")]
	[Trait("Area", "Services")]
	public partial class FamilyServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IFamilyRepository>();
			var records = new List<Family>();
			records.Add(new Family());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new FamilyService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

			List<ApiFamilyResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IFamilyRepository>();
			var record = new Family();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new FamilyService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

			ApiFamilyResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IFamilyRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Family>(null));
			var service = new FamilyService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

			ApiFamilyResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IFamilyRepository>();
			var model = new ApiFamilyRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Family>())).Returns(Task.FromResult(new Family()));
			var service = new FamilyService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

			CreateResponse<ApiFamilyResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiFamilyRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Family>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IFamilyRepository>();
			var model = new ApiFamilyRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Family>())).Returns(Task.FromResult(new Family()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Family()));
			var service = new FamilyService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

			UpdateResponse<ApiFamilyResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFamilyRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Family>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IFamilyRepository>();
			var model = new ApiFamilyRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new FamilyService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Students_Exists()
		{
			var mock = new ServiceMockFacade<IFamilyRepository>();
			var records = new List<Student>();
			records.Add(new Student());
			mock.RepositoryMock.Setup(x => x.Students(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new FamilyService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

			List<ApiStudentResponseModel> response = await service.Students(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Students(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Students_Not_Exists()
		{
			var mock = new ServiceMockFacade<IFamilyRepository>();
			mock.RepositoryMock.Setup(x => x.Students(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Student>>(new List<Student>()));
			var service = new FamilyService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

			List<ApiStudentResponseModel> response = await service.Students(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Students(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void StudentXFamilies_Exists()
		{
			var mock = new ServiceMockFacade<IFamilyRepository>();
			var records = new List<StudentXFamily>();
			records.Add(new StudentXFamily());
			mock.RepositoryMock.Setup(x => x.StudentXFamilies(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new FamilyService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

			List<ApiStudentXFamilyResponseModel> response = await service.StudentXFamilies(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.StudentXFamilies(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void StudentXFamilies_Not_Exists()
		{
			var mock = new ServiceMockFacade<IFamilyRepository>();
			mock.RepositoryMock.Setup(x => x.StudentXFamilies(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<StudentXFamily>>(new List<StudentXFamily>()));
			var service = new FamilyService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.FamilyModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALFamilyMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                mock.DALMapperMockFactory.DALStudentMapperMock,
			                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
			                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

			List<ApiStudentXFamilyResponseModel> response = await service.StudentXFamilies(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.StudentXFamilies(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>19b4dbbd2f7662188a9236ab8c56e2bc</Hash>
</Codenesium>*/