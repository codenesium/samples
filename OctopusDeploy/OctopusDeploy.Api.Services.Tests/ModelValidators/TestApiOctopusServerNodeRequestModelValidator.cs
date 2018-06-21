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
        [Trait("Table", "OctopusServerNode")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiOctopusServerNodeRequestModelValidatorTest
        {
                public ApiOctopusServerNodeRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IOctopusServerNodeRepository> octopusServerNodeRepository = new Mock<IOctopusServerNodeRepository>();
                        octopusServerNodeRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new OctopusServerNode()));

                        var validator = new ApiOctopusServerNodeRequestModelValidator(octopusServerNodeRepository.Object);
                        await validator.ValidateCreateAsync(new ApiOctopusServerNodeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IOctopusServerNodeRepository> octopusServerNodeRepository = new Mock<IOctopusServerNodeRepository>();
                        octopusServerNodeRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new OctopusServerNode()));

                        var validator = new ApiOctopusServerNodeRequestModelValidator(octopusServerNodeRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiOctopusServerNodeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IOctopusServerNodeRepository> octopusServerNodeRepository = new Mock<IOctopusServerNodeRepository>();
                        octopusServerNodeRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new OctopusServerNode()));

                        var validator = new ApiOctopusServerNodeRequestModelValidator(octopusServerNodeRepository.Object);
                        await validator.ValidateCreateAsync(new ApiOctopusServerNodeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IOctopusServerNodeRepository> octopusServerNodeRepository = new Mock<IOctopusServerNodeRepository>();
                        octopusServerNodeRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new OctopusServerNode()));

                        var validator = new ApiOctopusServerNodeRequestModelValidator(octopusServerNodeRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiOctopusServerNodeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IOctopusServerNodeRepository> octopusServerNodeRepository = new Mock<IOctopusServerNodeRepository>();
                        octopusServerNodeRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new OctopusServerNode()));

                        var validator = new ApiOctopusServerNodeRequestModelValidator(octopusServerNodeRepository.Object);
                        await validator.ValidateCreateAsync(new ApiOctopusServerNodeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IOctopusServerNodeRepository> octopusServerNodeRepository = new Mock<IOctopusServerNodeRepository>();
                        octopusServerNodeRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new OctopusServerNode()));

                        var validator = new ApiOctopusServerNodeRequestModelValidator(octopusServerNodeRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiOctopusServerNodeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IOctopusServerNodeRepository> octopusServerNodeRepository = new Mock<IOctopusServerNodeRepository>();
                        octopusServerNodeRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new OctopusServerNode()));

                        var validator = new ApiOctopusServerNodeRequestModelValidator(octopusServerNodeRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Rank_Create_null()
                {
                        Mock<IOctopusServerNodeRepository> octopusServerNodeRepository = new Mock<IOctopusServerNodeRepository>();
                        octopusServerNodeRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new OctopusServerNode()));

                        var validator = new ApiOctopusServerNodeRequestModelValidator(octopusServerNodeRepository.Object);
                        await validator.ValidateCreateAsync(new ApiOctopusServerNodeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Rank, null as string);
                }

                [Fact]
                public async void Rank_Update_null()
                {
                        Mock<IOctopusServerNodeRepository> octopusServerNodeRepository = new Mock<IOctopusServerNodeRepository>();
                        octopusServerNodeRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new OctopusServerNode()));

                        var validator = new ApiOctopusServerNodeRequestModelValidator(octopusServerNodeRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiOctopusServerNodeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Rank, null as string);
                }

                [Fact]
                public async void Rank_Create_length()
                {
                        Mock<IOctopusServerNodeRepository> octopusServerNodeRepository = new Mock<IOctopusServerNodeRepository>();
                        octopusServerNodeRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new OctopusServerNode()));

                        var validator = new ApiOctopusServerNodeRequestModelValidator(octopusServerNodeRepository.Object);
                        await validator.ValidateCreateAsync(new ApiOctopusServerNodeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Rank, new string('A', 51));
                }

                [Fact]
                public async void Rank_Update_length()
                {
                        Mock<IOctopusServerNodeRepository> octopusServerNodeRepository = new Mock<IOctopusServerNodeRepository>();
                        octopusServerNodeRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new OctopusServerNode()));

                        var validator = new ApiOctopusServerNodeRequestModelValidator(octopusServerNodeRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiOctopusServerNodeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Rank, new string('A', 51));
                }

                [Fact]
                public async void Rank_Delete()
                {
                        Mock<IOctopusServerNodeRepository> octopusServerNodeRepository = new Mock<IOctopusServerNodeRepository>();
                        octopusServerNodeRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new OctopusServerNode()));

                        var validator = new ApiOctopusServerNodeRequestModelValidator(octopusServerNodeRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>22085432a2a34b26b09b631878b2cee2</Hash>
</Codenesium>*/