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
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiEmployeeServerResponseModel> response = await service.All();

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
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			ApiEmployeeServerResponseModel response = await service.Get(default(int));

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
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			ApiEmployeeServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var model = new ApiEmployeeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Employee>())).Returns(Task.FromResult(new Employee()));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			CreateResponse<ApiEmployeeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEmployeeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Employee>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var model = new ApiEmployeeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Employee>())).Returns(Task.FromResult(new Employee()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			UpdateResponse<ApiEmployeeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEmployeeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Employee>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var model = new ApiEmployeeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineStepsByShipperId_Exists()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var records = new List<PipelineStep>();
			records.Add(new PipelineStep());
			mock.RepositoryMock.Setup(x => x.PipelineStepsByShipperId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiPipelineStepServerResponseModel> response = await service.PipelineStepsByShipperId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepsByShipperId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineStepsByShipperId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			mock.RepositoryMock.Setup(x => x.PipelineStepsByShipperId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PipelineStep>>(new List<PipelineStep>()));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiPipelineStepServerResponseModel> response = await service.PipelineStepsByShipperId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepsByShipperId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineStepNotesByEmployeeId_Exists()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var records = new List<PipelineStepNote>();
			records.Add(new PipelineStepNote());
			mock.RepositoryMock.Setup(x => x.PipelineStepNotesByEmployeeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiPipelineStepNoteServerResponseModel> response = await service.PipelineStepNotesByEmployeeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepNotesByEmployeeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineStepNotesByEmployeeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			mock.RepositoryMock.Setup(x => x.PipelineStepNotesByEmployeeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PipelineStepNote>>(new List<PipelineStepNote>()));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiPipelineStepNoteServerResponseModel> response = await service.PipelineStepNotesByEmployeeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepNotesByEmployeeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CustomerCommunicationsByEmployeeId_Exists()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var records = new List<CustomerCommunication>();
			records.Add(new CustomerCommunication());
			mock.RepositoryMock.Setup(x => x.CustomerCommunicationsByEmployeeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiCustomerCommunicationServerResponseModel> response = await service.CustomerCommunicationsByEmployeeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CustomerCommunicationsByEmployeeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CustomerCommunicationsByEmployeeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			mock.RepositoryMock.Setup(x => x.CustomerCommunicationsByEmployeeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<CustomerCommunication>>(new List<CustomerCommunication>()));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                  mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiCustomerCommunicationServerResponseModel> response = await service.CustomerCommunicationsByEmployeeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CustomerCommunicationsByEmployeeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>89c8914534151954c4620ac02b29f72e</Hash>
</Codenesium>*/