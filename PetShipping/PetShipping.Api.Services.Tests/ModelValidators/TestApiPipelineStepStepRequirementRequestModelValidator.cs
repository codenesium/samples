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
        public partial class ApiPipelineStepStepRequirementRequestModelValidatorTest
        {
                public ApiPipelineStepStepRequirementRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void PipelineStepId_Create_Valid_Reference()
                {
                        Mock<IPipelineStepStepRequirementRepository> pipelineStepStepRequirementRepository = new Mock<IPipelineStepStepRequirementRepository>();
                        pipelineStepStepRequirementRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(new PipelineStep()));

                        var validator = new ApiPipelineStepStepRequirementRequestModelValidator(pipelineStepStepRequirementRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPipelineStepStepRequirementRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepId, 1);
                }

                [Fact]
                public async void PipelineStepId_Create_Invalid_Reference()
                {
                        Mock<IPipelineStepStepRequirementRepository> pipelineStepStepRequirementRepository = new Mock<IPipelineStepStepRequirementRepository>();
                        pipelineStepStepRequirementRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));

                        var validator = new ApiPipelineStepStepRequirementRequestModelValidator(pipelineStepStepRequirementRepository.Object);

                        await validator.ValidateCreateAsync(new ApiPipelineStepStepRequirementRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PipelineStepId, 1);
                }

                [Fact]
                public async void PipelineStepId_Update_Valid_Reference()
                {
                        Mock<IPipelineStepStepRequirementRepository> pipelineStepStepRequirementRepository = new Mock<IPipelineStepStepRequirementRepository>();
                        pipelineStepStepRequirementRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(new PipelineStep()));

                        var validator = new ApiPipelineStepStepRequirementRequestModelValidator(pipelineStepStepRequirementRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepStepRequirementRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepId, 1);
                }

                [Fact]
                public async void PipelineStepId_Update_Invalid_Reference()
                {
                        Mock<IPipelineStepStepRequirementRepository> pipelineStepStepRequirementRepository = new Mock<IPipelineStepStepRequirementRepository>();
                        pipelineStepStepRequirementRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));

                        var validator = new ApiPipelineStepStepRequirementRequestModelValidator(pipelineStepStepRequirementRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepStepRequirementRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PipelineStepId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>8af76a67b9403bb80614726af707be74</Hash>
</Codenesium>*/