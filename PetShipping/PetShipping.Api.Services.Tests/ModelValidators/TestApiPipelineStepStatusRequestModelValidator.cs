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
        [Trait("Table", "PipelineStepStatus")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiPipelineStepStatusRequestModelValidatorTest
        {
                public ApiPipelineStepStatusRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IPipelineStepStatusRepository> pipelineStepStatusRepository = new Mock<IPipelineStepStatusRepository>();
                        pipelineStepStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStatus()));

                        var validator = new ApiPipelineStepStatusRequestModelValidator(pipelineStepStatusRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPipelineStepStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IPipelineStepStatusRepository> pipelineStepStatusRepository = new Mock<IPipelineStepStatusRepository>();
                        pipelineStepStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStatus()));

                        var validator = new ApiPipelineStepStatusRequestModelValidator(pipelineStepStatusRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }
        }
}

/*<Codenesium>
    <Hash>a250b5b7849244933b49fe526535523d</Hash>
</Codenesium>*/