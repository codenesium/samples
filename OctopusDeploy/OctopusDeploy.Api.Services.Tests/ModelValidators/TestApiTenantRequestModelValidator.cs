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
        [Trait("Table", "Tenant")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiTenantRequestModelValidatorTest
        {
                public ApiTenantRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<ITenantRepository> tenantRepository = new Mock<ITenantRepository>();
                        tenantRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Tenant()));

                        var validator = new ApiTenantRequestModelValidator(tenantRepository.Object);
                        await validator.ValidateCreateAsync(new ApiTenantRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<ITenantRepository> tenantRepository = new Mock<ITenantRepository>();
                        tenantRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Tenant()));

                        var validator = new ApiTenantRequestModelValidator(tenantRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiTenantRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<ITenantRepository> tenantRepository = new Mock<ITenantRepository>();
                        tenantRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Tenant()));

                        var validator = new ApiTenantRequestModelValidator(tenantRepository.Object);
                        await validator.ValidateCreateAsync(new ApiTenantRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ITenantRepository> tenantRepository = new Mock<ITenantRepository>();
                        tenantRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Tenant()));

                        var validator = new ApiTenantRequestModelValidator(tenantRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiTenantRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ITenantRepository> tenantRepository = new Mock<ITenantRepository>();
                        tenantRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Tenant()));

                        var validator = new ApiTenantRequestModelValidator(tenantRepository.Object);
                        await validator.ValidateCreateAsync(new ApiTenantRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ITenantRepository> tenantRepository = new Mock<ITenantRepository>();
                        tenantRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Tenant()));

                        var validator = new ApiTenantRequestModelValidator(tenantRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiTenantRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void ProjectIds_Create_null()
                {
                        Mock<ITenantRepository> tenantRepository = new Mock<ITenantRepository>();
                        tenantRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Tenant()));

                        var validator = new ApiTenantRequestModelValidator(tenantRepository.Object);
                        await validator.ValidateCreateAsync(new ApiTenantRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectIds, null as string);
                }

                [Fact]
                public async void ProjectIds_Update_null()
                {
                        Mock<ITenantRepository> tenantRepository = new Mock<ITenantRepository>();
                        tenantRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Tenant()));

                        var validator = new ApiTenantRequestModelValidator(tenantRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiTenantRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectIds, null as string);
                }

                [Fact]
                private async void BeUniqueByName_Create_Exists()
                {
                        Mock<ITenantRepository> tenantRepository = new Mock<ITenantRepository>();
                        tenantRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Tenant>(new Tenant()));
                        var validator = new ApiTenantRequestModelValidator(tenantRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTenantRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Create_Not_Exists()
                {
                        Mock<ITenantRepository> tenantRepository = new Mock<ITenantRepository>();
                        tenantRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Tenant>(null));
                        var validator = new ApiTenantRequestModelValidator(tenantRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTenantRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Exists()
                {
                        Mock<ITenantRepository> tenantRepository = new Mock<ITenantRepository>();
                        tenantRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Tenant>(new Tenant()));
                        var validator = new ApiTenantRequestModelValidator(tenantRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiTenantRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Not_Exists()
                {
                        Mock<ITenantRepository> tenantRepository = new Mock<ITenantRepository>();
                        tenantRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Tenant>(null));
                        var validator = new ApiTenantRequestModelValidator(tenantRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiTenantRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>eea75587449a53eaaf44aa50449e9b75</Hash>
</Codenesium>*/