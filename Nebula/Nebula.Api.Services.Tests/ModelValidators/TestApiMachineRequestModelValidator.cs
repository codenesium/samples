using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Machine")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiMachineRequestModelValidatorTest
        {
                public ApiMachineRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Description_Create_null()
                {
                        Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
                        machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

                        var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
                        await validator.ValidateCreateAsync(new ApiMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
                }

                [Fact]
                public async void Description_Update_null()
                {
                        Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
                        machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

                        var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
                }

                [Fact]
                public async void JwtKey_Create_null()
                {
                        Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
                        machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

                        var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
                        await validator.ValidateCreateAsync(new ApiMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JwtKey, null as string);
                }

                [Fact]
                public async void JwtKey_Update_null()
                {
                        Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
                        machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

                        var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JwtKey, null as string);
                }

                [Fact]
                public async void JwtKey_Create_length()
                {
                        Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
                        machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

                        var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
                        await validator.ValidateCreateAsync(new ApiMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JwtKey, new string('A', 129));
                }

                [Fact]
                public async void JwtKey_Update_length()
                {
                        Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
                        machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

                        var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JwtKey, new string('A', 129));
                }

                [Fact]
                public async void JwtKey_Delete()
                {
                        Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
                        machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

                        var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void LastIpAddress_Create_null()
                {
                        Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
                        machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

                        var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
                        await validator.ValidateCreateAsync(new ApiMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastIpAddress, null as string);
                }

                [Fact]
                public async void LastIpAddress_Update_null()
                {
                        Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
                        machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

                        var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastIpAddress, null as string);
                }

                [Fact]
                public async void LastIpAddress_Create_length()
                {
                        Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
                        machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

                        var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
                        await validator.ValidateCreateAsync(new ApiMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastIpAddress, new string('A', 129));
                }

                [Fact]
                public async void LastIpAddress_Update_length()
                {
                        Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
                        machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

                        var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastIpAddress, new string('A', 129));
                }

                [Fact]
                public async void LastIpAddress_Delete()
                {
                        Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
                        machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

                        var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
                        machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

                        var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
                        await validator.ValidateCreateAsync(new ApiMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
                        machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

                        var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
                        machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

                        var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
                        await validator.ValidateCreateAsync(new ApiMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
                        machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

                        var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiMachineRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IMachineRepository> machineRepository = new Mock<IMachineRepository>();
                        machineRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));

                        var validator = new ApiMachineRequestModelValidator(machineRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>fd056d4783994b156b1f64d66a58ebac</Hash>
</Codenesium>*/