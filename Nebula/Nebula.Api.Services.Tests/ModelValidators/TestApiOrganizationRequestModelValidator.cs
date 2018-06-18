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
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Organization")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiOrganizationRequestModelValidatorTest
        {
                public ApiOrganizationRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IOrganizationRepository> organizationRepository = new Mock<IOrganizationRepository>();
                        organizationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Organization()));

                        var validator = new ApiOrganizationRequestModelValidator(organizationRepository.Object);

                        await validator.ValidateCreateAsync(new ApiOrganizationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IOrganizationRepository> organizationRepository = new Mock<IOrganizationRepository>();
                        organizationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Organization()));

                        var validator = new ApiOrganizationRequestModelValidator(organizationRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiOrganizationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IOrganizationRepository> organizationRepository = new Mock<IOrganizationRepository>();
                        organizationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Organization()));

                        var validator = new ApiOrganizationRequestModelValidator(organizationRepository.Object);

                        await validator.ValidateCreateAsync(new ApiOrganizationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IOrganizationRepository> organizationRepository = new Mock<IOrganizationRepository>();
                        organizationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Organization()));

                        var validator = new ApiOrganizationRequestModelValidator(organizationRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiOrganizationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IOrganizationRepository> organizationRepository = new Mock<IOrganizationRepository>();
                        organizationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Organization()));

                        var validator = new ApiOrganizationRequestModelValidator(organizationRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>5dfe1dfaac5d8c96ce8e2f7ad6ef6282</Hash>
</Codenesium>*/