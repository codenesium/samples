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
        [Trait("Table", "PipelineStepStatus")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiPipelineStepStatusRequestModelValidatorTest
        {
                public ApiPipelineStepStatusRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IPipelineStepStatusRepository> pipelineStepStatusRepository = new Mock<IPipelineStepStatusRepository>();
                        pipelineStepStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStatus()));

                        var validator = new ApiPipelineStepStatusRequestModelValidator(pipelineStepStatusRepository.Object);

                        await validator.ValidateCreateAsync(new ApiPipelineStepStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IPipelineStepStatusRepository> pipelineStepStatusRepository = new Mock<IPipelineStepStatusRepository>();
                        pipelineStepStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStatus()));

                        var validator = new ApiPipelineStepStatusRequestModelValidator(pipelineStepStatusRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiPipelineStepStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
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

                        await validator.ValidateUpdateAsync(default (int), new ApiPipelineStepStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IPipelineStepStatusRepository> pipelineStepStatusRepository = new Mock<IPipelineStepStatusRepository>();
                        pipelineStepStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStatus()));

                        var validator = new ApiPipelineStepStatusRequestModelValidator(pipelineStepStatusRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>680546ecb435cd487f581ebba3cfe980</Hash>
</Codenesium>*/