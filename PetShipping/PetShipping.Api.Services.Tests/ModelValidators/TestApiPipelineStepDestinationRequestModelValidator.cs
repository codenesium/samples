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

                        await validator.ValidateUpdateAsync(default (int), new ApiPipelineStepDestinationRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.DestinationId, 1);
                }

                [Fact]
                public async void DestinationId_Update_Invalid_Reference()
                {
                        Mock<IPipelineStepDestinationRepository> pipelineStepDestinationRepository = new Mock<IPipelineStepDestinationRepository>();
                        pipelineStepDestinationRepository.Setup(x => x.GetDestination(It.IsAny<int>())).Returns(Task.FromResult<Destination>(null));

                        var validator = new ApiPipelineStepDestinationRequestModelValidator(pipelineStepDestinationRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiPipelineStepDestinationRequestModel());

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

                        await validator.ValidateUpdateAsync(default (int), new ApiPipelineStepDestinationRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepId, 1);
                }

                [Fact]
                public async void PipelineStepId_Update_Invalid_Reference()
                {
                        Mock<IPipelineStepDestinationRepository> pipelineStepDestinationRepository = new Mock<IPipelineStepDestinationRepository>();
                        pipelineStepDestinationRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));

                        var validator = new ApiPipelineStepDestinationRequestModelValidator(pipelineStepDestinationRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiPipelineStepDestinationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PipelineStepId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>a61ca5e055f864b61501f4f5fd94284a</Hash>
</Codenesium>*/