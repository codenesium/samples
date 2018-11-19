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
	[Trait("Table", "PipelineStepStepRequirement")]
	[Trait("Area", "Services")]
	public partial class PipelineStepStepRequirementServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPipelineStepStepRequirementRepository>();
			var records = new List<PipelineStepStepRequirement>();
			records.Add(new PipelineStepStepRequirement());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineStepStepRequirementService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     mock.ModelValidatorMockFactory.PipelineStepStepRequirementModelValidatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLPipelineStepStepRequirementMapperMock,
			                                                     mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			List<ApiPipelineStepStepRequirementServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPipelineStepStepRequirementRepository>();
			var record = new PipelineStepStepRequirement();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PipelineStepStepRequirementService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     mock.ModelValidatorMockFactory.PipelineStepStepRequirementModelValidatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLPipelineStepStepRequirementMapperMock,
			                                                     mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			ApiPipelineStepStepRequirementServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPipelineStepStepRequirementRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PipelineStepStepRequirement>(null));
			var service = new PipelineStepStepRequirementService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     mock.ModelValidatorMockFactory.PipelineStepStepRequirementModelValidatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLPipelineStepStepRequirementMapperMock,
			                                                     mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			ApiPipelineStepStepRequirementServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IPipelineStepStepRequirementRepository>();
			var model = new ApiPipelineStepStepRequirementServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStepStepRequirement>())).Returns(Task.FromResult(new PipelineStepStepRequirement()));
			var service = new PipelineStepStepRequirementService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     mock.ModelValidatorMockFactory.PipelineStepStepRequirementModelValidatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLPipelineStepStepRequirementMapperMock,
			                                                     mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			CreateResponse<ApiPipelineStepStepRequirementServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PipelineStepStepRequirementModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PipelineStepStepRequirement>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IPipelineStepStepRequirementRepository>();
			var model = new ApiPipelineStepStepRequirementServerRequestModel();
			var validatorMock = new Mock<IApiPipelineStepStepRequirementServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PipelineStepStepRequirementService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     validatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLPipelineStepStepRequirementMapperMock,
			                                                     mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			CreateResponse<ApiPipelineStepStepRequirementServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IPipelineStepStepRequirementRepository>();
			var model = new ApiPipelineStepStepRequirementServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStepStepRequirement>())).Returns(Task.FromResult(new PipelineStepStepRequirement()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStepRequirement()));
			var service = new PipelineStepStepRequirementService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     mock.ModelValidatorMockFactory.PipelineStepStepRequirementModelValidatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLPipelineStepStepRequirementMapperMock,
			                                                     mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			UpdateResponse<ApiPipelineStepStepRequirementServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PipelineStepStepRequirementModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PipelineStepStepRequirement>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IPipelineStepStepRequirementRepository>();
			var model = new ApiPipelineStepStepRequirementServerRequestModel();
			var validatorMock = new Mock<IApiPipelineStepStepRequirementServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStepRequirement()));
			var service = new PipelineStepStepRequirementService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     validatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLPipelineStepStepRequirementMapperMock,
			                                                     mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			UpdateResponse<ApiPipelineStepStepRequirementServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IPipelineStepStepRequirementRepository>();
			var model = new ApiPipelineStepStepRequirementServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PipelineStepStepRequirementService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     mock.ModelValidatorMockFactory.PipelineStepStepRequirementModelValidatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLPipelineStepStepRequirementMapperMock,
			                                                     mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PipelineStepStepRequirementModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IPipelineStepStepRequirementRepository>();
			var model = new ApiPipelineStepStepRequirementServerRequestModel();
			var validatorMock = new Mock<IApiPipelineStepStepRequirementServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PipelineStepStepRequirementService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     validatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLPipelineStepStepRequirementMapperMock,
			                                                     mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>56e98c5e30610edbd2e04c84d18621dc</Hash>
</Codenesium>*/