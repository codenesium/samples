using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
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
                public async void Gender_Create_null()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
                        await validator.ValidateCreateAsync(new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Gender, null as string);
                }

                [Fact]
                public async void Gender_Update_null()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Gender, null as string);
                }

                [Fact]
                public async void Gender_Create_length()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
                        await validator.ValidateCreateAsync(new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Gender, new string('A', 2));
                }

                [Fact]
                public async void Gender_Update_length()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Gender, new string('A', 2));
                }

                [Fact]
                public async void JobTitle_Create_null()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
                        await validator.ValidateCreateAsync(new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JobTitle, null as string);
                }

                [Fact]
                public async void JobTitle_Update_null()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JobTitle, null as string);
                }

                [Fact]
                public async void JobTitle_Create_length()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
                        await validator.ValidateCreateAsync(new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JobTitle, new string('A', 51));
                }

                [Fact]
                public async void JobTitle_Update_length()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JobTitle, new string('A', 51));
                }

                [Fact]
                public async void LoginID_Create_null()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
                        await validator.ValidateCreateAsync(new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LoginID, null as string);
                }

                [Fact]
                public async void LoginID_Update_null()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LoginID, null as string);
                }

                [Fact]
                public async void LoginID_Create_length()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
                        await validator.ValidateCreateAsync(new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LoginID, new string('A', 257));
                }

                [Fact]
                public async void LoginID_Update_length()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LoginID, new string('A', 257));
                }

                [Fact]
                public async void MaritalStatu_Create_null()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
                        await validator.ValidateCreateAsync(new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.MaritalStatu, null as string);
                }

                [Fact]
                public async void MaritalStatu_Update_null()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.MaritalStatu, null as string);
                }

                [Fact]
                public async void MaritalStatu_Create_length()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
                        await validator.ValidateCreateAsync(new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.MaritalStatu, new string('A', 2));
                }

                [Fact]
                public async void MaritalStatu_Update_length()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.MaritalStatu, new string('A', 2));
                }

                [Fact]
                public async void NationalIDNumber_Create_null()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
                        await validator.ValidateCreateAsync(new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.NationalIDNumber, null as string);
                }

                [Fact]
                public async void NationalIDNumber_Update_null()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.NationalIDNumber, null as string);
                }

                [Fact]
                public async void NationalIDNumber_Create_length()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
                        await validator.ValidateCreateAsync(new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.NationalIDNumber, new string('A', 16));
                }

                [Fact]
                public async void NationalIDNumber_Update_length()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.NationalIDNumber, new string('A', 16));
                }

                [Fact]
                private async void BeUniqueByLoginID_Create_Exists()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.ByLoginID(It.IsAny<string>())).Returns(Task.FromResult<Employee>(new Employee()));
                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LoginID, "A");
                }

                [Fact]
                private async void BeUniqueByLoginID_Create_Not_Exists()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.ByLoginID(It.IsAny<string>())).Returns(Task.FromResult<Employee>(null));
                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEmployeeRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.LoginID, "A");
                }

                [Fact]
                private async void BeUniqueByLoginID_Update_Exists()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.ByLoginID(It.IsAny<string>())).Returns(Task.FromResult<Employee>(new Employee()));
                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiEmployeeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LoginID, "A");
                }

                [Fact]
                private async void BeUniqueByLoginID_Update_Not_Exists()
                {
                        Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
                        employeeRepository.Setup(x => x.ByLoginID(It.IsAny<string>())).Returns(Task.FromResult<Employee>(null));
                        var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiEmployeeRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.LoginID, "A");
                }
        }
}

/*<Codenesium>
    <Hash>59c9692256a05e0f2b97af27a3ce3157</Hash>
</Codenesium>*/