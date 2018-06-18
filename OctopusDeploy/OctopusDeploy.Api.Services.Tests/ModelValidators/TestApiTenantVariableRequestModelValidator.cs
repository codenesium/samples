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
        [Trait("Table", "TenantVariable")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiTenantVariableRequestModelValidatorTest
        {
                public ApiTenantVariableRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void EnvironmentId_Create_length()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTenantVariableRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, new string('A', 51));
                }

                [Fact]
                public async void EnvironmentId_Update_length()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiTenantVariableRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, new string('A', 51));
                }

                [Fact]
                public async void EnvironmentId_Delete()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTenantVariableRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiTenantVariableRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void OwnerId_Create_null()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTenantVariableRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.OwnerId, null as string);
                }

                [Fact]
                public async void OwnerId_Update_null()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiTenantVariableRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.OwnerId, null as string);
                }

                [Fact]
                public async void OwnerId_Create_length()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTenantVariableRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.OwnerId, new string('A', 51));
                }

                [Fact]
                public async void OwnerId_Update_length()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiTenantVariableRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.OwnerId, new string('A', 51));
                }

                [Fact]
                public async void OwnerId_Delete()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void TenantId_Create_null()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTenantVariableRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TenantId, null as string);
                }

                [Fact]
                public async void TenantId_Update_null()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiTenantVariableRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TenantId, null as string);
                }

                [Fact]
                public async void TenantId_Create_length()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTenantVariableRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TenantId, new string('A', 51));
                }

                [Fact]
                public async void TenantId_Update_length()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiTenantVariableRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TenantId, new string('A', 51));
                }

                [Fact]
                public async void TenantId_Delete()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void VariableTemplateId_Create_null()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTenantVariableRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.VariableTemplateId, null as string);
                }

                [Fact]
                public async void VariableTemplateId_Update_null()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiTenantVariableRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.VariableTemplateId, null as string);
                }

                [Fact]
                public async void VariableTemplateId_Create_length()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTenantVariableRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.VariableTemplateId, new string('A', 51));
                }

                [Fact]
                public async void VariableTemplateId_Update_length()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiTenantVariableRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.VariableTemplateId, new string('A', 51));
                }

                [Fact]
                public async void VariableTemplateId_Delete()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueGetTenantIdOwnerIdEnvironmentIdVariableTemplateId_Create_Exists()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.GetTenantIdOwnerIdEnvironmentIdVariableTemplateId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<TenantVariable>(new TenantVariable()));
                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTenantVariableRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, "A");
                }

                [Fact]
                private async void BeUniqueGetTenantIdOwnerIdEnvironmentIdVariableTemplateId_Create_Not_Exists()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.GetTenantIdOwnerIdEnvironmentIdVariableTemplateId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<TenantVariable>(null));
                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTenantVariableRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.EnvironmentId, "A");
                }

                [Fact]
                private async void BeUniqueGetTenantIdOwnerIdEnvironmentIdVariableTemplateId_Update_Exists()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.GetTenantIdOwnerIdEnvironmentIdVariableTemplateId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<TenantVariable>(new TenantVariable()));
                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiTenantVariableRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, "A");
                }

                [Fact]
                private async void BeUniqueGetTenantIdOwnerIdEnvironmentIdVariableTemplateId_Update_Not_Exists()
                {
                        Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
                        tenantVariableRepository.Setup(x => x.GetTenantIdOwnerIdEnvironmentIdVariableTemplateId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<TenantVariable>(null));
                        var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiTenantVariableRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.EnvironmentId, "A");
                }
        }
}

/*<Codenesium>
    <Hash>3ac85557fcede67707d41562f5355ada</Hash>
</Codenesium>*/