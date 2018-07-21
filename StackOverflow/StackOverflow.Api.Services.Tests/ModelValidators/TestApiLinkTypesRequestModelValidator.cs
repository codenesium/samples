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
        [Trait("Table", "LinkTypes")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiLinkTypesRequestModelValidatorTest
        {
                public ApiLinkTypesRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Type_Create_length()
                {
                        Mock<ILinkTypesRepository> linkTypesRepository = new Mock<ILinkTypesRepository>();
                        linkTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkTypes()));

                        var validator = new ApiLinkTypesRequestModelValidator(linkTypesRepository.Object);
                        await validator.ValidateCreateAsync(new ApiLinkTypesRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
                }

                [Fact]
                public async void Type_Update_length()
                {
                        Mock<ILinkTypesRepository> linkTypesRepository = new Mock<ILinkTypesRepository>();
                        linkTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkTypes()));

                        var validator = new ApiLinkTypesRequestModelValidator(linkTypesRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiLinkTypesRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
                }
        }
}

/*<Codenesium>
    <Hash>237ce55a4677511522a2e8f6402449e0</Hash>
</Codenesium>*/