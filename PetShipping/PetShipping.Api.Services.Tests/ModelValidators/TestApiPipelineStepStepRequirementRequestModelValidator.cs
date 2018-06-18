using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using System.Linq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
                public async void Details_Create_null()
                {
                        Mock<IPipelineStepStepRequirementRepository> pipelineStepStepRequirementRepository = new Mock<IPipelineStepStepRequirementRepository>();
                        pipelineStepStepRequirementRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStepRequirement()));

                        var validator = new ApiPipelineStepStepRequirementRequestModelValidator(pipelineStepStepRequirementRepository.Object);

                        await validator.ValidateCreateAsync(new ApiPipelineStepStepRequirementRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Details, null as string);
                }

                [Fact]
                public async void Details_Update_null()
                {
                        Mock<IPipelineStepStepRequirementRepository> pipelineStepStepRequirementRepository = new Mock<IPipelineStepStepRequirementRepository>();
                        pipelineStepStepRequirementRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStepRequirement()));

                        var validator = new ApiPipelineStepStepRequirementRequestModelValidator(pipelineStepStepRequirementRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiPipelineStepStepRequirementRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Details, null as string);
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

                        await validator.ValidateUpdateAsync(default (int), new ApiPipelineStepStepRequirementRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepId, 1);
                }

                [Fact]
                public async void PipelineStepId_Update_Invalid_Reference()
                {
                        Mock<IPipelineStepStepRequirementRepository> pipelineStepStepRequirementRepository = new Mock<IPipelineStepStepRequirementRepository>();
                        pipelineStepStepRequirementRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));

                        var validator = new ApiPipelineStepStepRequirementRequestModelValidator(pipelineStepStepRequirementRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiPipelineStepStepRequirementRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PipelineStepId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>567efd01ec71c44b9503963d108bfa2b</Hash>
</Codenesium>*/