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
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Lifecycle")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiLifecycleRequestModelValidatorTest
        {
                public ApiLifecycleRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<ILifecycleRepository> lifecycleRepository = new Mock<ILifecycleRepository>();
                        lifecycleRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Lifecycle()));

                        var validator = new ApiLifecycleRequestModelValidator(lifecycleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiLifecycleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<ILifecycleRepository> lifecycleRepository = new Mock<ILifecycleRepository>();
                        lifecycleRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Lifecycle()));

                        var validator = new ApiLifecycleRequestModelValidator(lifecycleRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiLifecycleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<ILifecycleRepository> lifecycleRepository = new Mock<ILifecycleRepository>();
                        lifecycleRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Lifecycle()));

                        var validator = new ApiLifecycleRequestModelValidator(lifecycleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiLifecycleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ILifecycleRepository> lifecycleRepository = new Mock<ILifecycleRepository>();
                        lifecycleRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Lifecycle()));

                        var validator = new ApiLifecycleRequestModelValidator(lifecycleRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiLifecycleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ILifecycleRepository> lifecycleRepository = new Mock<ILifecycleRepository>();
                        lifecycleRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Lifecycle()));

                        var validator = new ApiLifecycleRequestModelValidator(lifecycleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiLifecycleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ILifecycleRepository> lifecycleRepository = new Mock<ILifecycleRepository>();
                        lifecycleRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Lifecycle()));

                        var validator = new ApiLifecycleRequestModelValidator(lifecycleRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiLifecycleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<ILifecycleRepository> lifecycleRepository = new Mock<ILifecycleRepository>();
                        lifecycleRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Lifecycle()));

                        var validator = new ApiLifecycleRequestModelValidator(lifecycleRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueGetName_Create_Exists()
                {
                        Mock<ILifecycleRepository> lifecycleRepository = new Mock<ILifecycleRepository>();
                        lifecycleRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Lifecycle>(new Lifecycle()));
                        var validator = new ApiLifecycleRequestModelValidator(lifecycleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiLifecycleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Create_Not_Exists()
                {
                        Mock<ILifecycleRepository> lifecycleRepository = new Mock<ILifecycleRepository>();
                        lifecycleRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Lifecycle>(null));
                        var validator = new ApiLifecycleRequestModelValidator(lifecycleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiLifecycleRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Exists()
                {
                        Mock<ILifecycleRepository> lifecycleRepository = new Mock<ILifecycleRepository>();
                        lifecycleRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Lifecycle>(new Lifecycle()));
                        var validator = new ApiLifecycleRequestModelValidator(lifecycleRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiLifecycleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Not_Exists()
                {
                        Mock<ILifecycleRepository> lifecycleRepository = new Mock<ILifecycleRepository>();
                        lifecycleRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Lifecycle>(null));
                        var validator = new ApiLifecycleRequestModelValidator(lifecycleRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiLifecycleRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>c12427706941155ab6eb792b77fc5053</Hash>
</Codenesium>*/