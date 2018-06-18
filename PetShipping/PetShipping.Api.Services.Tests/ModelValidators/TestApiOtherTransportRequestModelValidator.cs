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
        [Trait("Table", "OtherTransport")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiOtherTransportRequestModelValidatorTest
        {
                public ApiOtherTransportRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void HandlerId_Create_Valid_Reference()
                {
                        Mock<IOtherTransportRepository> otherTransportRepository = new Mock<IOtherTransportRepository>();
                        otherTransportRepository.Setup(x => x.GetHandler(It.IsAny<int>())).Returns(Task.FromResult<Handler>(new Handler()));

                        var validator = new ApiOtherTransportRequestModelValidator(otherTransportRepository.Object);

                        await validator.ValidateCreateAsync(new ApiOtherTransportRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.HandlerId, 1);
                }

                [Fact]
                public async void HandlerId_Create_Invalid_Reference()
                {
                        Mock<IOtherTransportRepository> otherTransportRepository = new Mock<IOtherTransportRepository>();
                        otherTransportRepository.Setup(x => x.GetHandler(It.IsAny<int>())).Returns(Task.FromResult<Handler>(null));

                        var validator = new ApiOtherTransportRequestModelValidator(otherTransportRepository.Object);

                        await validator.ValidateCreateAsync(new ApiOtherTransportRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.HandlerId, 1);
                }

                [Fact]
                public async void HandlerId_Update_Valid_Reference()
                {
                        Mock<IOtherTransportRepository> otherTransportRepository = new Mock<IOtherTransportRepository>();
                        otherTransportRepository.Setup(x => x.GetHandler(It.IsAny<int>())).Returns(Task.FromResult<Handler>(new Handler()));

                        var validator = new ApiOtherTransportRequestModelValidator(otherTransportRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiOtherTransportRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.HandlerId, 1);
                }

                [Fact]
                public async void HandlerId_Update_Invalid_Reference()
                {
                        Mock<IOtherTransportRepository> otherTransportRepository = new Mock<IOtherTransportRepository>();
                        otherTransportRepository.Setup(x => x.GetHandler(It.IsAny<int>())).Returns(Task.FromResult<Handler>(null));

                        var validator = new ApiOtherTransportRequestModelValidator(otherTransportRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiOtherTransportRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.HandlerId, 1);
                }

                [Fact]
                public async void PipelineStepId_Create_Valid_Reference()
                {
                        Mock<IOtherTransportRepository> otherTransportRepository = new Mock<IOtherTransportRepository>();
                        otherTransportRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(new PipelineStep()));

                        var validator = new ApiOtherTransportRequestModelValidator(otherTransportRepository.Object);

                        await validator.ValidateCreateAsync(new ApiOtherTransportRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepId, 1);
                }

                [Fact]
                public async void PipelineStepId_Create_Invalid_Reference()
                {
                        Mock<IOtherTransportRepository> otherTransportRepository = new Mock<IOtherTransportRepository>();
                        otherTransportRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));

                        var validator = new ApiOtherTransportRequestModelValidator(otherTransportRepository.Object);

                        await validator.ValidateCreateAsync(new ApiOtherTransportRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PipelineStepId, 1);
                }

                [Fact]
                public async void PipelineStepId_Update_Valid_Reference()
                {
                        Mock<IOtherTransportRepository> otherTransportRepository = new Mock<IOtherTransportRepository>();
                        otherTransportRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(new PipelineStep()));

                        var validator = new ApiOtherTransportRequestModelValidator(otherTransportRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiOtherTransportRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepId, 1);
                }

                [Fact]
                public async void PipelineStepId_Update_Invalid_Reference()
                {
                        Mock<IOtherTransportRepository> otherTransportRepository = new Mock<IOtherTransportRepository>();
                        otherTransportRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));

                        var validator = new ApiOtherTransportRequestModelValidator(otherTransportRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiOtherTransportRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PipelineStepId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>f57e40849e420eed4203c3cfc4b59af0</Hash>
</Codenesium>*/