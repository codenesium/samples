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
        [Trait("Table", "Employee")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiEmployeeRequestModelValidatorTest
        {
                public ApiEmployeeRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void FirstName_Create_null()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
                }

                [Fact]
                public async void FirstName_Update_null()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
                }

                [Fact]
                public async void FirstName_Create_length()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
                }

                [Fact]
                public async void FirstName_Update_length()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
                }

                [Fact]
                public async void FirstName_Delete()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void LastName_Create_null()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
                }

                [Fact]
                public async void LastName_Update_null()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
                }

                [Fact]
                public async void LastName_Create_length()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
                }

                [Fact]
                public async void LastName_Update_length()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
                }

                [Fact]
                public async void LastName_Delete()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>bf20490185b489030f5374133015bbaa</Hash>
</Codenesium>*/