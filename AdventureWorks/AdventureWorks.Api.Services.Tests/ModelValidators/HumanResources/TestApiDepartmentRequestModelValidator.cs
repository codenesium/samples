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
        [Trait("Table", "Department")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiDepartmentRequestModelValidatorTest
        {
                public ApiDepartmentRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void GroupName_Create_null()
                {
                        Mock<IDepartmentRepository> departmentRepository = new Mock<IDepartmentRepository>();
                        departmentRepository.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new Department()));

                        var validator = new ApiDepartmentRequestModelValidator(departmentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDepartmentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.GroupName, null as string);
                }

                [Fact]
                public async void GroupName_Update_null()
                {
                        Mock<IDepartmentRepository> departmentRepository = new Mock<IDepartmentRepository>();
                        departmentRepository.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new Department()));

                        var validator = new ApiDepartmentRequestModelValidator(departmentRepository.Object);
                        await validator.ValidateUpdateAsync(default(short), new ApiDepartmentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.GroupName, null as string);
                }

                [Fact]
                public async void GroupName_Create_length()
                {
                        Mock<IDepartmentRepository> departmentRepository = new Mock<IDepartmentRepository>();
                        departmentRepository.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new Department()));

                        var validator = new ApiDepartmentRequestModelValidator(departmentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDepartmentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.GroupName, new string('A', 51));
                }

                [Fact]
                public async void GroupName_Update_length()
                {
                        Mock<IDepartmentRepository> departmentRepository = new Mock<IDepartmentRepository>();
                        departmentRepository.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new Department()));

                        var validator = new ApiDepartmentRequestModelValidator(departmentRepository.Object);
                        await validator.ValidateUpdateAsync(default(short), new ApiDepartmentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.GroupName, new string('A', 51));
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IDepartmentRepository> departmentRepository = new Mock<IDepartmentRepository>();
                        departmentRepository.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new Department()));

                        var validator = new ApiDepartmentRequestModelValidator(departmentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDepartmentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IDepartmentRepository> departmentRepository = new Mock<IDepartmentRepository>();
                        departmentRepository.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new Department()));

                        var validator = new ApiDepartmentRequestModelValidator(departmentRepository.Object);
                        await validator.ValidateUpdateAsync(default(short), new ApiDepartmentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IDepartmentRepository> departmentRepository = new Mock<IDepartmentRepository>();
                        departmentRepository.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new Department()));

                        var validator = new ApiDepartmentRequestModelValidator(departmentRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDepartmentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IDepartmentRepository> departmentRepository = new Mock<IDepartmentRepository>();
                        departmentRepository.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new Department()));

                        var validator = new ApiDepartmentRequestModelValidator(departmentRepository.Object);
                        await validator.ValidateUpdateAsync(default(short), new ApiDepartmentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                private async void BeUniqueByName_Create_Exists()
                {
                        Mock<IDepartmentRepository> departmentRepository = new Mock<IDepartmentRepository>();
                        departmentRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Department>(new Department()));
                        var validator = new ApiDepartmentRequestModelValidator(departmentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDepartmentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Create_Not_Exists()
                {
                        Mock<IDepartmentRepository> departmentRepository = new Mock<IDepartmentRepository>();
                        departmentRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Department>(null));
                        var validator = new ApiDepartmentRequestModelValidator(departmentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDepartmentRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Exists()
                {
                        Mock<IDepartmentRepository> departmentRepository = new Mock<IDepartmentRepository>();
                        departmentRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Department>(new Department()));
                        var validator = new ApiDepartmentRequestModelValidator(departmentRepository.Object);

                        await validator.ValidateUpdateAsync(default(short), new ApiDepartmentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Not_Exists()
                {
                        Mock<IDepartmentRepository> departmentRepository = new Mock<IDepartmentRepository>();
                        departmentRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Department>(null));
                        var validator = new ApiDepartmentRequestModelValidator(departmentRepository.Object);

                        await validator.ValidateUpdateAsync(default(short), new ApiDepartmentRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>5efe037eebd4f2c08fafc83222e6ca70</Hash>
</Codenesium>*/