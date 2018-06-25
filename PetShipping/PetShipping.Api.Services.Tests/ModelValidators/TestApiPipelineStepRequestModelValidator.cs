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
        [Trait("Table", "PipelineStep")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiPipelineStepRequestModelValidatorTest
        {
                public ApiPipelineStepRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
                        pipelineStepRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStep()));

                        var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPipelineStepRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
                        pipelineStepRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStep()));

                        var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
                        pipelineStepRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStep()));

                        var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPipelineStepRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
                        pipelineStepRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStep()));

                        var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void PipelineStepStatusId_Create_Valid_Reference()
                {
                        Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
                        pipelineStepRepository.Setup(x => x.GetPipelineStepStatus(It.IsAny<int>())).Returns(Task.FromResult<PipelineStepStatus>(new PipelineStepStatus()));

                        var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPipelineStepRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepStatusId, 1);
                }

                [Fact]
                public async void PipelineStepStatusId_Create_Invalid_Reference()
                {
                        Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
                        pipelineStepRepository.Setup(x => x.GetPipelineStepStatus(It.IsAny<int>())).Returns(Task.FromResult<PipelineStepStatus>(null));

                        var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);

                        await validator.ValidateCreateAsync(new ApiPipelineStepRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PipelineStepStatusId, 1);
                }

                [Fact]
                public async void PipelineStepStatusId_Update_Valid_Reference()
                {
                        Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
                        pipelineStepRepository.Setup(x => x.GetPipelineStepStatus(It.IsAny<int>())).Returns(Task.FromResult<PipelineStepStatus>(new PipelineStepStatus()));

                        var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepStatusId, 1);
                }

                [Fact]
                public async void PipelineStepStatusId_Update_Invalid_Reference()
                {
                        Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
                        pipelineStepRepository.Setup(x => x.GetPipelineStepStatus(It.IsAny<int>())).Returns(Task.FromResult<PipelineStepStatus>(null));

                        var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PipelineStepStatusId, 1);
                }

                [Fact]
                public async void ShipperId_Create_Valid_Reference()
                {
                        Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
                        pipelineStepRepository.Setup(x => x.GetEmployee(It.IsAny<int>())).Returns(Task.FromResult<Employee>(new Employee()));

                        var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPipelineStepRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ShipperId, 1);
                }

                [Fact]
                public async void ShipperId_Create_Invalid_Reference()
                {
                        Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
                        pipelineStepRepository.Setup(x => x.GetEmployee(It.IsAny<int>())).Returns(Task.FromResult<Employee>(null));

                        var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);

                        await validator.ValidateCreateAsync(new ApiPipelineStepRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ShipperId, 1);
                }

                [Fact]
                public async void ShipperId_Update_Valid_Reference()
                {
                        Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
                        pipelineStepRepository.Setup(x => x.GetEmployee(It.IsAny<int>())).Returns(Task.FromResult<Employee>(new Employee()));

                        var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ShipperId, 1);
                }

                [Fact]
                public async void ShipperId_Update_Invalid_Reference()
                {
                        Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
                        pipelineStepRepository.Setup(x => x.GetEmployee(It.IsAny<int>())).Returns(Task.FromResult<Employee>(null));

                        var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ShipperId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>5479798fa855b3ebf86c1ee21fa6e5ab</Hash>
</Codenesium>*/