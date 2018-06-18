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
        [Trait("Table", "SchemaVersions")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiSchemaVersionsRequestModelValidatorTest
        {
                public ApiSchemaVersionsRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void ScriptName_Create_null()
                {
                        Mock<ISchemaVersionsRepository> schemaVersionsRepository = new Mock<ISchemaVersionsRepository>();
                        schemaVersionsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SchemaVersions()));

                        var validator = new ApiSchemaVersionsRequestModelValidator(schemaVersionsRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSchemaVersionsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ScriptName, null as string);
                }

                [Fact]
                public async void ScriptName_Update_null()
                {
                        Mock<ISchemaVersionsRepository> schemaVersionsRepository = new Mock<ISchemaVersionsRepository>();
                        schemaVersionsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SchemaVersions()));

                        var validator = new ApiSchemaVersionsRequestModelValidator(schemaVersionsRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSchemaVersionsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ScriptName, null as string);
                }

                [Fact]
                public async void ScriptName_Create_length()
                {
                        Mock<ISchemaVersionsRepository> schemaVersionsRepository = new Mock<ISchemaVersionsRepository>();
                        schemaVersionsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SchemaVersions()));

                        var validator = new ApiSchemaVersionsRequestModelValidator(schemaVersionsRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSchemaVersionsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ScriptName, new string('A', 256));
                }

                [Fact]
                public async void ScriptName_Update_length()
                {
                        Mock<ISchemaVersionsRepository> schemaVersionsRepository = new Mock<ISchemaVersionsRepository>();
                        schemaVersionsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SchemaVersions()));

                        var validator = new ApiSchemaVersionsRequestModelValidator(schemaVersionsRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSchemaVersionsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ScriptName, new string('A', 256));
                }

                [Fact]
                public async void ScriptName_Delete()
                {
                        Mock<ISchemaVersionsRepository> schemaVersionsRepository = new Mock<ISchemaVersionsRepository>();
                        schemaVersionsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SchemaVersions()));

                        var validator = new ApiSchemaVersionsRequestModelValidator(schemaVersionsRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>5ddb28702fae746f81fc49c94c049052</Hash>
</Codenesium>*/