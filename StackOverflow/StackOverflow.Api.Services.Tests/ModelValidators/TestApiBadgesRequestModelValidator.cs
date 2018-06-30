using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Badges")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiBadgesRequestModelValidatorTest
        {
                public ApiBadgesRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IBadgesRepository> badgesRepository = new Mock<IBadgesRepository>();
                        badgesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Badges()));

                        var validator = new ApiBadgesRequestModelValidator(badgesRepository.Object);
                        await validator.ValidateCreateAsync(new ApiBadgesRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IBadgesRepository> badgesRepository = new Mock<IBadgesRepository>();
                        badgesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Badges()));

                        var validator = new ApiBadgesRequestModelValidator(badgesRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiBadgesRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IBadgesRepository> badgesRepository = new Mock<IBadgesRepository>();
                        badgesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Badges()));

                        var validator = new ApiBadgesRequestModelValidator(badgesRepository.Object);
                        await validator.ValidateCreateAsync(new ApiBadgesRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 41));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IBadgesRepository> badgesRepository = new Mock<IBadgesRepository>();
                        badgesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Badges()));

                        var validator = new ApiBadgesRequestModelValidator(badgesRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiBadgesRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 41));
                }
        }
}

/*<Codenesium>
    <Hash>c141bc8a15f2c5e673c02d51f965b6b8</Hash>
</Codenesium>*/