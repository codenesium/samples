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
        [Trait("Table", "HandlerPipelineStep")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiHandlerPipelineStepRequestModelValidatorTest
        {
                public ApiHandlerPipelineStepRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void HandlerId_Create_Valid_Reference()
                {
                        Mock<IHandlerPipelineStepRepository> handlerPipelineStepRepository = new Mock<IHandlerPipelineStepRepository>();
                        handlerPipelineStepRepository.Setup(x => x.GetHandler(It.IsAny<int>())).Returns(Task.FromResult<Handler>(new Handler()));

                        var validator = new ApiHandlerPipelineStepRequestModelValidator(handlerPipelineStepRepository.Object);
                        await validator.ValidateCreateAsync(new ApiHandlerPipelineStepRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.HandlerId, 1);
                }

                [Fact]
                public async void HandlerId_Create_Invalid_Reference()
                {
                        Mock<IHandlerPipelineStepRepository> handlerPipelineStepRepository = new Mock<IHandlerPipelineStepRepository>();
                        handlerPipelineStepRepository.Setup(x => x.GetHandler(It.IsAny<int>())).Returns(Task.FromResult<Handler>(null));

                        var validator = new ApiHandlerPipelineStepRequestModelValidator(handlerPipelineStepRepository.Object);

                        await validator.ValidateCreateAsync(new ApiHandlerPipelineStepRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.HandlerId, 1);
                }

                [Fact]
                public async void HandlerId_Update_Valid_Reference()
                {
                        Mock<IHandlerPipelineStepRepository> handlerPipelineStepRepository = new Mock<IHandlerPipelineStepRepository>();
                        handlerPipelineStepRepository.Setup(x => x.GetHandler(It.IsAny<int>())).Returns(Task.FromResult<Handler>(new Handler()));

                        var validator = new ApiHandlerPipelineStepRequestModelValidator(handlerPipelineStepRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiHandlerPipelineStepRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.HandlerId, 1);
                }

                [Fact]
                public async void HandlerId_Update_Invalid_Reference()
                {
                        Mock<IHandlerPipelineStepRepository> handlerPipelineStepRepository = new Mock<IHandlerPipelineStepRepository>();
                        handlerPipelineStepRepository.Setup(x => x.GetHandler(It.IsAny<int>())).Returns(Task.FromResult<Handler>(null));

                        var validator = new ApiHandlerPipelineStepRequestModelValidator(handlerPipelineStepRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiHandlerPipelineStepRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.HandlerId, 1);
                }

                [Fact]
                public async void PipelineStepId_Create_Valid_Reference()
                {
                        Mock<IHandlerPipelineStepRepository> handlerPipelineStepRepository = new Mock<IHandlerPipelineStepRepository>();
                        handlerPipelineStepRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(new PipelineStep()));

                        var validator = new ApiHandlerPipelineStepRequestModelValidator(handlerPipelineStepRepository.Object);
                        await validator.ValidateCreateAsync(new ApiHandlerPipelineStepRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepId, 1);
                }

                [Fact]
                public async void PipelineStepId_Create_Invalid_Reference()
                {
                        Mock<IHandlerPipelineStepRepository> handlerPipelineStepRepository = new Mock<IHandlerPipelineStepRepository>();
                        handlerPipelineStepRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));

                        var validator = new ApiHandlerPipelineStepRequestModelValidator(handlerPipelineStepRepository.Object);

                        await validator.ValidateCreateAsync(new ApiHandlerPipelineStepRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PipelineStepId, 1);
                }

                [Fact]
                public async void PipelineStepId_Update_Valid_Reference()
                {
                        Mock<IHandlerPipelineStepRepository> handlerPipelineStepRepository = new Mock<IHandlerPipelineStepRepository>();
                        handlerPipelineStepRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(new PipelineStep()));

                        var validator = new ApiHandlerPipelineStepRequestModelValidator(handlerPipelineStepRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiHandlerPipelineStepRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepId, 1);
                }

                [Fact]
                public async void PipelineStepId_Update_Invalid_Reference()
                {
                        Mock<IHandlerPipelineStepRepository> handlerPipelineStepRepository = new Mock<IHandlerPipelineStepRepository>();
                        handlerPipelineStepRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));

                        var validator = new ApiHandlerPipelineStepRequestModelValidator(handlerPipelineStepRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiHandlerPipelineStepRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PipelineStepId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>b99738dcb4f6ec4288c8185b2d201bb1</Hash>
</Codenesium>*/