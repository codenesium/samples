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

                        await validator.ValidateUpdateAsync(default (string), new ApiOctopusServerNodeRequestModel());

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

                        await validator.ValidateUpdateAsync(default (string), new ApiOctopusServerNodeRequestModel());

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

                        await validator.ValidateUpdateAsync(default (string), new ApiOctopusServerNodeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IOctopusServerNodeRepository> octopusServerNodeRepository = new Mock<IOctopusServerNodeRepository>();
                        octopusServerNodeRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new OctopusServerNode()));

                        var validator = new ApiOctopusServerNodeRequestModelValidator(octopusServerNodeRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

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

                        await validator.ValidateUpdateAsync(default (string), new ApiOctopusServerNodeRequestModel());

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

                        await validator.ValidateUpdateAsync(default (string), new ApiOctopusServerNodeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Rank, new string('A', 51));
                }

                [Fact]
                public async void Rank_Delete()
                {
                        Mock<IOctopusServerNodeRepository> octopusServerNodeRepository = new Mock<IOctopusServerNodeRepository>();
                        octopusServerNodeRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new OctopusServerNode()));

                        var validator = new ApiOctopusServerNodeRequestModelValidator(octopusServerNodeRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>6ec5a7ca59eb76345efee53866060909</Hash>
</Codenesium>*/