using FluentAssertions;
using FluentValidation.Results;
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
	[Trait("Table", "PipelineStepNote")]
	[Trait("Area", "Services")]
	public partial class PipelineStepNoteServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPipelineStepNoteRepository>();
			var records = new List<PipelineStepNote>();
			records.Add(new PipelineStepNote());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineStepNoteService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.PipelineStepNoteModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                          mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

			List<ApiPipelineStepNoteServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPipelineStepNoteRepository>();
			var record = new PipelineStepNote();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PipelineStepNoteService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.PipelineStepNoteModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                          mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

			ApiPipelineStepNoteServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPipelineStepNoteRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PipelineStepNote>(null));
			var service = new PipelineStepNoteService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.PipelineStepNoteModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                          mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

			ApiPipelineStepNoteServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IPipelineStepNoteRepository>();
			var model = new ApiPipelineStepNoteServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStepNote>())).Returns(Task.FromResult(new PipelineStepNote()));
			var service = new PipelineStepNoteService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.PipelineStepNoteModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                          mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

			CreateResponse<ApiPipelineStepNoteServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PipelineStepNoteModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepNoteServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PipelineStepNote>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IPipelineStepNoteRepository>();
			var model = new ApiPipelineStepNoteServerRequestModel();
			var validatorMock = new Mock<IApiPipelineStepNoteServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepNoteServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PipelineStepNoteService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          validatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                          mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

			CreateResponse<ApiPipelineStepNoteServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepNoteServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IPipelineStepNoteRepository>();
			var model = new ApiPipelineStepNoteServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStepNote>())).Returns(Task.FromResult(new PipelineStepNote()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepNote()));
			var service = new PipelineStepNoteService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.PipelineStepNoteModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                          mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

			UpdateResponse<ApiPipelineStepNoteServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PipelineStepNoteModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepNoteServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PipelineStepNote>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IPipelineStepNoteRepository>();
			var model = new ApiPipelineStepNoteServerRequestModel();
			var validatorMock = new Mock<IApiPipelineStepNoteServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepNoteServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepNote()));
			var service = new PipelineStepNoteService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          validatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                          mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

			UpdateResponse<ApiPipelineStepNoteServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepNoteServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IPipelineStepNoteRepository>();
			var model = new ApiPipelineStepNoteServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PipelineStepNoteService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.PipelineStepNoteModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                          mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PipelineStepNoteModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IPipelineStepNoteRepository>();
			var model = new ApiPipelineStepNoteServerRequestModel();
			var validatorMock = new Mock<IApiPipelineStepNoteServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PipelineStepNoteService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          validatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLPipelineStepNoteMapperMock,
			                                          mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>be2b54aa48229241bc32a7984fcad2aa</Hash>
</Codenesium>*/