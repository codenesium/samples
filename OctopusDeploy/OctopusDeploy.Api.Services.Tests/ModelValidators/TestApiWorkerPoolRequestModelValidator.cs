using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "WorkerPool")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiWorkerPoolRequestModelValidatorTest
        {
                public ApiWorkerPoolRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IWorkerPoolRepository> workerPoolRepository = new Mock<IWorkerPoolRepository>();
                        workerPoolRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerPool()));

                        var validator = new ApiWorkerPoolRequestModelValidator(workerPoolRepository.Object);
                        await validator.ValidateCreateAsync(new ApiWorkerPoolRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IWorkerPoolRepository> workerPoolRepository = new Mock<IWorkerPoolRepository>();
                        workerPoolRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerPool()));

                        var validator = new ApiWorkerPoolRequestModelValidator(workerPoolRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiWorkerPoolRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IWorkerPoolRepository> workerPoolRepository = new Mock<IWorkerPoolRepository>();
                        workerPoolRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerPool()));

                        var validator = new ApiWorkerPoolRequestModelValidator(workerPoolRepository.Object);
                        await validator.ValidateCreateAsync(new ApiWorkerPoolRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IWorkerPoolRepository> workerPoolRepository = new Mock<IWorkerPoolRepository>();
                        workerPoolRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerPool()));

                        var validator = new ApiWorkerPoolRequestModelValidator(workerPoolRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiWorkerPoolRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IWorkerPoolRepository> workerPoolRepository = new Mock<IWorkerPoolRepository>();
                        workerPoolRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerPool()));

                        var validator = new ApiWorkerPoolRequestModelValidator(workerPoolRepository.Object);
                        await validator.ValidateCreateAsync(new ApiWorkerPoolRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IWorkerPoolRepository> workerPoolRepository = new Mock<IWorkerPoolRepository>();
                        workerPoolRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerPool()));

                        var validator = new ApiWorkerPoolRequestModelValidator(workerPoolRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiWorkerPoolRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IWorkerPoolRepository> workerPoolRepository = new Mock<IWorkerPoolRepository>();
                        workerPoolRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerPool()));

                        var validator = new ApiWorkerPoolRequestModelValidator(workerPoolRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueGetName_Create_Exists()
                {
                        Mock<IWorkerPoolRepository> workerPoolRepository = new Mock<IWorkerPoolRepository>();
                        workerPoolRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<WorkerPool>(new WorkerPool()));
                        var validator = new ApiWorkerPoolRequestModelValidator(workerPoolRepository.Object);

                        await validator.ValidateCreateAsync(new ApiWorkerPoolRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Create_Not_Exists()
                {
                        Mock<IWorkerPoolRepository> workerPoolRepository = new Mock<IWorkerPoolRepository>();
                        workerPoolRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<WorkerPool>(null));
                        var validator = new ApiWorkerPoolRequestModelValidator(workerPoolRepository.Object);

                        await validator.ValidateCreateAsync(new ApiWorkerPoolRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Exists()
                {
                        Mock<IWorkerPoolRepository> workerPoolRepository = new Mock<IWorkerPoolRepository>();
                        workerPoolRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<WorkerPool>(new WorkerPool()));
                        var validator = new ApiWorkerPoolRequestModelValidator(workerPoolRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiWorkerPoolRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Not_Exists()
                {
                        Mock<IWorkerPoolRepository> workerPoolRepository = new Mock<IWorkerPoolRepository>();
                        workerPoolRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<WorkerPool>(null));
                        var validator = new ApiWorkerPoolRequestModelValidator(workerPoolRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiWorkerPoolRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>8678bf6d0c8b818582d9240ff9c465c1</Hash>
</Codenesium>*/