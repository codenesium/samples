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
        [Trait("Table", "VariableSet")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiVariableSetRequestModelValidatorTest
        {
                public ApiVariableSetRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IVariableSetRepository> variableSetRepository = new Mock<IVariableSetRepository>();
                        variableSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new VariableSet()));

                        var validator = new ApiVariableSetRequestModelValidator(variableSetRepository.Object);
                        await validator.ValidateCreateAsync(new ApiVariableSetRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IVariableSetRepository> variableSetRepository = new Mock<IVariableSetRepository>();
                        variableSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new VariableSet()));

                        var validator = new ApiVariableSetRequestModelValidator(variableSetRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiVariableSetRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void OwnerId_Create_null()
                {
                        Mock<IVariableSetRepository> variableSetRepository = new Mock<IVariableSetRepository>();
                        variableSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new VariableSet()));

                        var validator = new ApiVariableSetRequestModelValidator(variableSetRepository.Object);
                        await validator.ValidateCreateAsync(new ApiVariableSetRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.OwnerId, null as string);
                }

                [Fact]
                public async void OwnerId_Update_null()
                {
                        Mock<IVariableSetRepository> variableSetRepository = new Mock<IVariableSetRepository>();
                        variableSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new VariableSet()));

                        var validator = new ApiVariableSetRequestModelValidator(variableSetRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiVariableSetRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.OwnerId, null as string);
                }

                [Fact]
                public async void OwnerId_Create_length()
                {
                        Mock<IVariableSetRepository> variableSetRepository = new Mock<IVariableSetRepository>();
                        variableSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new VariableSet()));

                        var validator = new ApiVariableSetRequestModelValidator(variableSetRepository.Object);
                        await validator.ValidateCreateAsync(new ApiVariableSetRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.OwnerId, new string('A', 151));
                }

                [Fact]
                public async void OwnerId_Update_length()
                {
                        Mock<IVariableSetRepository> variableSetRepository = new Mock<IVariableSetRepository>();
                        variableSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new VariableSet()));

                        var validator = new ApiVariableSetRequestModelValidator(variableSetRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiVariableSetRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.OwnerId, new string('A', 151));
                }

                [Fact]
                public async void OwnerId_Delete()
                {
                        Mock<IVariableSetRepository> variableSetRepository = new Mock<IVariableSetRepository>();
                        variableSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new VariableSet()));

                        var validator = new ApiVariableSetRequestModelValidator(variableSetRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>d149b2e899d0f99a507180d07be55304</Hash>
</Codenesium>*/