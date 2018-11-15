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
	[Trait("Table", "PipelineStepStepRequirement")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPipelineStepStepRequirementServerRequestModelValidatorTest
	{
		public ApiPipelineStepStepRequirementServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Detail_Create_null()
		{
			Mock<IPipelineStepStepRequirementRepository> pipelineStepStepRequirementRepository = new Mock<IPipelineStepStepRequirementRepository>();
			pipelineStepStepRequirementRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStepRequirement()));

			var validator = new ApiPipelineStepStepRequirementServerRequestModelValidator(pipelineStepStepRequirementRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineStepStepRequirementServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Detail, null as string);
		}

		[Fact]
		public async void Detail_Update_null()
		{
			Mock<IPipelineStepStepRequirementRepository> pipelineStepStepRequirementRepository = new Mock<IPipelineStepStepRequirementRepository>();
			pipelineStepStepRequirementRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStepRequirement()));

			var validator = new ApiPipelineStepStepRequirementServerRequestModelValidator(pipelineStepStepRequirementRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepStepRequirementServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Detail, null as string);
		}

		[Fact]
		public async void PipelineStepId_Create_Valid_Reference()
		{
			Mock<IPipelineStepStepRequirementRepository> pipelineStepStepRequirementRepository = new Mock<IPipelineStepStepRequirementRepository>();
			pipelineStepStepRequirementRepository.Setup(x => x.PipelineStepByPipelineStepId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(new PipelineStep()));

			var validator = new ApiPipelineStepStepRequirementServerRequestModelValidator(pipelineStepStepRequirementRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineStepStepRequirementServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}

		[Fact]
		public async void PipelineStepId_Create_Invalid_Reference()
		{
			Mock<IPipelineStepStepRequirementRepository> pipelineStepStepRequirementRepository = new Mock<IPipelineStepStepRequirementRepository>();
			pipelineStepStepRequirementRepository.Setup(x => x.PipelineStepByPipelineStepId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));

			var validator = new ApiPipelineStepStepRequirementServerRequestModelValidator(pipelineStepStepRequirementRepository.Object);

			await validator.ValidateCreateAsync(new ApiPipelineStepStepRequirementServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}

		[Fact]
		public async void PipelineStepId_Update_Valid_Reference()
		{
			Mock<IPipelineStepStepRequirementRepository> pipelineStepStepRequirementRepository = new Mock<IPipelineStepStepRequirementRepository>();
			pipelineStepStepRequirementRepository.Setup(x => x.PipelineStepByPipelineStepId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(new PipelineStep()));

			var validator = new ApiPipelineStepStepRequirementServerRequestModelValidator(pipelineStepStepRequirementRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepStepRequirementServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}

		[Fact]
		public async void PipelineStepId_Update_Invalid_Reference()
		{
			Mock<IPipelineStepStepRequirementRepository> pipelineStepStepRequirementRepository = new Mock<IPipelineStepStepRequirementRepository>();
			pipelineStepStepRequirementRepository.Setup(x => x.PipelineStepByPipelineStepId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));

			var validator = new ApiPipelineStepStepRequirementServerRequestModelValidator(pipelineStepStepRequirementRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepStepRequirementServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>0b76e412476e3d91aa711a9f5d1d54df</Hash>
</Codenesium>*/