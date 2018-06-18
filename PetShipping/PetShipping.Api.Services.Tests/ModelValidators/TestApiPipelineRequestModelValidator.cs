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
        [Trait("Table", "Pipeline")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiPipelineRequestModelValidatorTest
        {
                public ApiPipelineRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void PipelineStatusId_Create_Valid_Reference()
                {
                        Mock<IPipelineRepository> pipelineRepository = new Mock<IPipelineRepository>();
                        pipelineRepository.Setup(x => x.GetPipelineStatus(It.IsAny<int>())).Returns(Task.FromResult<PipelineStatus>(new PipelineStatus()));

                        var validator = new ApiPipelineRequestModelValidator(pipelineRepository.Object);

                        await validator.ValidateCreateAsync(new ApiPipelineRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStatusId, 1);
                }

                [Fact]
                public async void PipelineStatusId_Create_Invalid_Reference()
                {
                        Mock<IPipelineRepository> pipelineRepository = new Mock<IPipelineRepository>();
                        pipelineRepository.Setup(x => x.GetPipelineStatus(It.IsAny<int>())).Returns(Task.FromResult<PipelineStatus>(null));

                        var validator = new ApiPipelineRequestModelValidator(pipelineRepository.Object);

                        await validator.ValidateCreateAsync(new ApiPipelineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PipelineStatusId, 1);
                }

                [Fact]
                public async void PipelineStatusId_Update_Valid_Reference()
                {
                        Mock<IPipelineRepository> pipelineRepository = new Mock<IPipelineRepository>();
                        pipelineRepository.Setup(x => x.GetPipelineStatus(It.IsAny<int>())).Returns(Task.FromResult<PipelineStatus>(new PipelineStatus()));

                        var validator = new ApiPipelineRequestModelValidator(pipelineRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiPipelineRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStatusId, 1);
                }

                [Fact]
                public async void PipelineStatusId_Update_Invalid_Reference()
                {
                        Mock<IPipelineRepository> pipelineRepository = new Mock<IPipelineRepository>();
                        pipelineRepository.Setup(x => x.GetPipelineStatus(It.IsAny<int>())).Returns(Task.FromResult<PipelineStatus>(null));

                        var validator = new ApiPipelineRequestModelValidator(pipelineRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiPipelineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PipelineStatusId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>a635c88ea62f57839133dd9c36399d4c</Hash>
</Codenesium>*/