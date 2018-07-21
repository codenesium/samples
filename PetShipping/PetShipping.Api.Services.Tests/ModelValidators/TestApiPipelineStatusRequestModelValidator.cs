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
        [Trait("Table", "PipelineStatus")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiPipelineStatusRequestModelValidatorTest
        {
                public ApiPipelineStatusRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IPipelineStatusRepository> pipelineStatusRepository = new Mock<IPipelineStatusRepository>();
                        pipelineStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStatus()));

                        var validator = new ApiPipelineStatusRequestModelValidator(pipelineStatusRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPipelineStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IPipelineStatusRepository> pipelineStatusRepository = new Mock<IPipelineStatusRepository>();
                        pipelineStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStatus()));

                        var validator = new ApiPipelineStatusRequestModelValidator(pipelineStatusRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPipelineStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }
        }
}

/*<Codenesium>
    <Hash>3e416e8e0833cf572c2c128c45db9b3f</Hash>
</Codenesium>*/