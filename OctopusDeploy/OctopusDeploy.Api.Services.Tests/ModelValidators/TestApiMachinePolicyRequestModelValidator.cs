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
        [Trait("Table", "MachinePolicy")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiMachinePolicyRequestModelValidatorTest
        {
                public ApiMachinePolicyRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IMachinePolicyRepository> machinePolicyRepository = new Mock<IMachinePolicyRepository>();
                        machinePolicyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new MachinePolicy()));

                        var validator = new ApiMachinePolicyRequestModelValidator(machinePolicyRepository.Object);
                        await validator.ValidateCreateAsync(new ApiMachinePolicyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IMachinePolicyRepository> machinePolicyRepository = new Mock<IMachinePolicyRepository>();
                        machinePolicyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new MachinePolicy()));

                        var validator = new ApiMachinePolicyRequestModelValidator(machinePolicyRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiMachinePolicyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IMachinePolicyRepository> machinePolicyRepository = new Mock<IMachinePolicyRepository>();
                        machinePolicyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new MachinePolicy()));

                        var validator = new ApiMachinePolicyRequestModelValidator(machinePolicyRepository.Object);
                        await validator.ValidateCreateAsync(new ApiMachinePolicyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IMachinePolicyRepository> machinePolicyRepository = new Mock<IMachinePolicyRepository>();
                        machinePolicyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new MachinePolicy()));

                        var validator = new ApiMachinePolicyRequestModelValidator(machinePolicyRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiMachinePolicyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IMachinePolicyRepository> machinePolicyRepository = new Mock<IMachinePolicyRepository>();
                        machinePolicyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new MachinePolicy()));

                        var validator = new ApiMachinePolicyRequestModelValidator(machinePolicyRepository.Object);
                        await validator.ValidateCreateAsync(new ApiMachinePolicyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IMachinePolicyRepository> machinePolicyRepository = new Mock<IMachinePolicyRepository>();
                        machinePolicyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new MachinePolicy()));

                        var validator = new ApiMachinePolicyRequestModelValidator(machinePolicyRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiMachinePolicyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IMachinePolicyRepository> machinePolicyRepository = new Mock<IMachinePolicyRepository>();
                        machinePolicyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new MachinePolicy()));

                        var validator = new ApiMachinePolicyRequestModelValidator(machinePolicyRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueGetName_Create_Exists()
                {
                        Mock<IMachinePolicyRepository> machinePolicyRepository = new Mock<IMachinePolicyRepository>();
                        machinePolicyRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<MachinePolicy>(new MachinePolicy()));
                        var validator = new ApiMachinePolicyRequestModelValidator(machinePolicyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiMachinePolicyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Create_Not_Exists()
                {
                        Mock<IMachinePolicyRepository> machinePolicyRepository = new Mock<IMachinePolicyRepository>();
                        machinePolicyRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<MachinePolicy>(null));
                        var validator = new ApiMachinePolicyRequestModelValidator(machinePolicyRepository.Object);

                        await validator.ValidateCreateAsync(new ApiMachinePolicyRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Exists()
                {
                        Mock<IMachinePolicyRepository> machinePolicyRepository = new Mock<IMachinePolicyRepository>();
                        machinePolicyRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<MachinePolicy>(new MachinePolicy()));
                        var validator = new ApiMachinePolicyRequestModelValidator(machinePolicyRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiMachinePolicyRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Not_Exists()
                {
                        Mock<IMachinePolicyRepository> machinePolicyRepository = new Mock<IMachinePolicyRepository>();
                        machinePolicyRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<MachinePolicy>(null));
                        var validator = new ApiMachinePolicyRequestModelValidator(machinePolicyRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiMachinePolicyRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>e7b70051dbd00aa00c14ac6d38e2ffea</Hash>
</Codenesium>*/