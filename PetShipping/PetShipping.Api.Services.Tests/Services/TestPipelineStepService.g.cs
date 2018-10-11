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
	[Trait("Table", "PipelineStep")]
	[Trait("Area", "Services")]
	public partial class PipelineStepServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPipelineStepRepository>();
			var records = new List<PipelineStep>();
			records.Add(new PipelineStep());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepStepRequirementMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			List<ApiPipelineStepResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPipelineStepRepository>();
			var record = new PipelineStep();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepStepRequirementMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			ApiPipelineStepResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPipelineStepRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepStepRequirementMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			ApiPipelineStepResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IPipelineStepRepository>();
			var model = new ApiPipelineStepRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStep>())).Returns(Task.FromResult(new PipelineStep()));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepStepRequirementMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			CreateResponse<ApiPipelineStepResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PipelineStep>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IPipelineStepRepository>();
			var model = new ApiPipelineStepRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStep>())).Returns(Task.FromResult(new PipelineStep()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStep()));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepStepRequirementMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			UpdateResponse<ApiPipelineStepResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PipelineStep>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IPipelineStepRepository>();
			var model = new ApiPipelineStepRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepStepRequirementMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineStepNotes_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepRepository>();
			var records = new List<PipelineStepNote>();
			records.Add(new PipelineStepNote());
			mock.RepositoryMock.Setup(x => x.PipelineStepNotes(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepStepRequirementMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			List<ApiPipelineStepNoteResponseModel> response = await service.PipelineStepNotes(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepNotes(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineStepNotes_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepRepository>();
			mock.RepositoryMock.Setup(x => x.PipelineStepNotes(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PipelineStepNote>>(new List<PipelineStepNote>()));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepStepRequirementMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			List<ApiPipelineStepNoteResponseModel> response = await service.PipelineStepNotes(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepNotes(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineStepStepRequirements_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepRepository>();
			var records = new List<PipelineStepStepRequirement>();
			records.Add(new PipelineStepStepRequirement());
			mock.RepositoryMock.Setup(x => x.PipelineStepStepRequirements(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepStepRequirementMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			List<ApiPipelineStepStepRequirementResponseModel> response = await service.PipelineStepStepRequirements(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepStepRequirements(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineStepStepRequirements_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepRepository>();
			mock.RepositoryMock.Setup(x => x.PipelineStepStepRequirements(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PipelineStepStepRequirement>>(new List<PipelineStepStepRequirement>()));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.BOLMapperMockFactory.BOLPipelineStepStepRequirementMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			List<ApiPipelineStepStepRequirementResponseModel> response = await service.PipelineStepStepRequirements(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepStepRequirements(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>c0ff531169bc8a0c2caedb6a568c4e28</Hash>
</Codenesium>*/