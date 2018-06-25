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
                        await validator.ValidateUpdateAsync(default(int), new ApiOrganizationRequestModel());

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
                        await validator.ValidateUpdateAsync(default(int), new ApiOrganizationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }
        }
}

/*<Codenesium>
    <Hash>86fdb85c1c9008542e98567dff09c177</Hash>
</Codenesium>*/