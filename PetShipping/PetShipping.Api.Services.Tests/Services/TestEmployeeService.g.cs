using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Employee")]
	[Trait("Area", "Services")]
	public partial class EmployeeServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var records = new List<Employee>();
			records.Add(new Employee());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

			List<ApiEmployeeResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var record = new Employee();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

			ApiEmployeeResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Employee>(null));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

			ApiEmployeeResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var model = new ApiEmployeeRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Employee>())).Returns(Task.FromResult(new Employee()));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

			CreateResponse<ApiEmployeeResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEmployeeRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Employee>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var model = new ApiEmployeeRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Employee>())).Returns(Task.FromResult(new Employee()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

			UpdateResponse<ApiEmployeeResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEmployeeRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Employee>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var model = new ApiEmployeeRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ClientCommunications_Exists()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var records = new List<ClientCommunication>();
			records.Add(new ClientCommunication());
			mock.RepositoryMock.Setup(x => x.ClientCommunications(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

			List<ApiClientCommunicationResponseModel> response = await service.ClientCommunications(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ClientCommunications(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ClientCommunications_Not_Exists()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			mock.RepositoryMock.Setup(x => x.ClientCommunications(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ClientCommunication>>(new List<ClientCommunication>()));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

			List<ApiClientCommunicationResponseModel> response = await service.ClientCommunications(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ClientCommunications(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineSteps_Exists()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var records = new List<PipelineStep>();
			records.Add(new PipelineStep());
			mock.RepositoryMock.Setup(x => x.PipelineSteps(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

			List<ApiPipelineStepResponseModel> response = await service.PipelineSteps(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineSteps(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineSteps_Not_Exists()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			mock.RepositoryMock.Setup(x => x.PipelineSteps(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PipelineStep>>(new List<PipelineStep>()));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

			List<ApiPipelineStepResponseModel> response = await service.PipelineSteps(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineSteps(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineStepNotes_Exists()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var records = new List<PipelineStepNote>();
			records.Add(new PipelineStepNote());
			mock.RepositoryMock.Setup(x => x.PipelineStepNotes(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

			List<ApiPipelineStepNoteResponseModel> response = await service.PipelineStepNotes(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepNotes(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineStepNotes_Not_Exists()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			mock.RepositoryMock.Setup(x => x.PipelineStepNotes(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PipelineStepNote>>(new List<PipelineStepNote>()));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLClientCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALClientCommunicationMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

			List<ApiPipelineStepNoteResponseModel> response = await service.PipelineStepNotes(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepNotes(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>805cffb871f603608eb573616407822c</Hash>
</Codenesium>*/