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
	[Trait("Table", "Pipeline")]
	[Trait("Area", "Services")]
	public partial class PipelineServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPipelineRepository>();
			var records = new List<Pipeline>();
			records.Add(new Pipeline());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PipelineModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineMapperMock);

			List<ApiPipelineServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPipelineRepository>();
			var record = new Pipeline();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PipelineService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PipelineModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineMapperMock);

			ApiPipelineServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPipelineRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Pipeline>(null));
			var service = new PipelineService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PipelineModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineMapperMock);

			ApiPipelineServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IPipelineRepository>();
			var model = new ApiPipelineServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Pipeline>())).Returns(Task.FromResult(new Pipeline()));
			var service = new PipelineService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PipelineModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineMapperMock);

			CreateResponse<ApiPipelineServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PipelineModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Pipeline>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IPipelineRepository>();
			var model = new ApiPipelineServerRequestModel();
			var validatorMock = new Mock<IApiPipelineServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PipelineService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineMapperMock);

			CreateResponse<ApiPipelineServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IPipelineRepository>();
			var model = new ApiPipelineServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Pipeline>())).Returns(Task.FromResult(new Pipeline()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pipeline()));
			var service = new PipelineService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PipelineModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineMapperMock);

			UpdateResponse<ApiPipelineServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PipelineModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Pipeline>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IPipelineRepository>();
			var model = new ApiPipelineServerRequestModel();
			var validatorMock = new Mock<IApiPipelineServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pipeline()));
			var service = new PipelineService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineMapperMock);

			UpdateResponse<ApiPipelineServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IPipelineRepository>();
			var model = new ApiPipelineServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PipelineService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PipelineModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PipelineModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IPipelineRepository>();
			var model = new ApiPipelineServerRequestModel();
			var validatorMock = new Mock<IApiPipelineServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PipelineService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPipelineMapperMock,
			                                  mock.DALMapperMockFactory.DALPipelineMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>130718d4985e4b8783b01262a90ba801</Hash>
</Codenesium>*/