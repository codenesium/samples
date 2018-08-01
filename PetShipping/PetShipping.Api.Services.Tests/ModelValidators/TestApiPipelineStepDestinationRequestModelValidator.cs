using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepDestination")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPipelineStepDestinationRequestModelValidatorTest
	{
		public ApiPipelineStepDestinationRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void DestinationId_Create_Valid_Reference()
		{
			Mock<IPipelineStepDestinationRepository> pipelineStepDestinationRepository = new Mock<IPipelineStepDestinationRepository>();
			pipelineStepDestinationRepository.Setup(x => x.GetDestination(It.IsAny<int>())).Returns(Task.FromResult<Destination>(new Destination()));

			var validator = new ApiPipelineStepDestinationRequestModelValidator(pipelineStepDestinationRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineStepDestinationRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.DestinationId, 1);
		}

		[Fact]
		public async void DestinationId_Create_Invalid_Reference()
		{
			Mock<IPipelineStepDestinationRepository> pipelineStepDestinationRepository = new Mock<IPipelineStepDestinationRepository>();
			pipelineStepDestinationRepository.Setup(x => x.GetDestination(It.IsAny<int>())).Returns(Task.FromResult<Destination>(null));

			var validator = new ApiPipelineStepDestinationRequestModelValidator(pipelineStepDestinationRepository.Object);

			await validator.ValidateCreateAsync(new ApiPipelineStepDestinationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.DestinationId, 1);
		}

		[Fact]
		public async void DestinationId_Update_Valid_Reference()
		{
			Mock<IPipelineStepDestinationRepository> pipelineStepDestinationRepository = new Mock<IPipelineStepDestinationRepository>();
			pipelineStepDestinationRepository.Setup(x => x.GetDestination(It.IsAny<int>())).Returns(Task.FromResult<Destination>(new Destination()));

			var validator = new ApiPipelineStepDestinationRequestModelValidator(pipelineStepDestinationRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepDestinationRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.DestinationId, 1);
		}

		[Fact]
		public async void DestinationId_Update_Invalid_Reference()
		{
			Mock<IPipelineStepDestinationRepository> pipelineStepDestinationRepository = new Mock<IPipelineStepDestinationRepository>();
			pipelineStepDestinationRepository.Setup(x => x.GetDestination(It.IsAny<int>())).Returns(Task.FromResult<Destination>(null));

			var validator = new ApiPipelineStepDestinationRequestModelValidator(pipelineStepDestinationRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepDestinationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.DestinationId, 1);
		}

		[Fact]
		public async void PipelineStepId_Create_Valid_Reference()
		{
			Mock<IPipelineStepDestinationRepository> pipelineStepDestinationRepository = new Mock<IPipelineStepDestinationRepository>();
			pipelineStepDestinationRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(new PipelineStep()));

			var validator = new ApiPipelineStepDestinationRequestModelValidator(pipelineStepDestinationRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineStepDestinationRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}

		[Fact]
		public async void PipelineStepId_Create_Invalid_Reference()
		{
			Mock<IPipelineStepDestinationRepository> pipelineStepDestinationRepository = new Mock<IPipelineStepDestinationRepository>();
			pipelineStepDestinationRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));

			var validator = new ApiPipelineStepDestinationRequestModelValidator(pipelineStepDestinationRepository.Object);

			await validator.ValidateCreateAsync(new ApiPipelineStepDestinationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}

		[Fact]
		public async void PipelineStepId_Update_Valid_Reference()
		{
			Mock<IPipelineStepDestinationRepository> pipelineStepDestinationRepository = new Mock<IPipelineStepDestinationRepository>();
			pipelineStepDestinationRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(new PipelineStep()));

			var validator = new ApiPipelineStepDestinationRequestModelValidator(pipelineStepDestinationRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepDestinationRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}

		[Fact]
		public async void PipelineStepId_Update_Invalid_Reference()
		{
			Mock<IPipelineStepDestinationRepository> pipelineStepDestinationRepository = new Mock<IPipelineStepDestinationRepository>();
			pipelineStepDestinationRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));

			var validator = new ApiPipelineStepDestinationRequestModelValidator(pipelineStepDestinationRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepDestinationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>9e5a2696c0d8a5570a65ed2494b2cff2</Hash>
</Codenesium>*/