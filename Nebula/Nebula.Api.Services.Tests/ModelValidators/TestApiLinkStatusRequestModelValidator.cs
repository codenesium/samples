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
        [Trait("Table", "LinkStatus")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiLinkStatusRequestModelValidatorTest
        {
                public ApiLinkStatusRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<ILinkStatusRepository> linkStatusRepository = new Mock<ILinkStatusRepository>();
                        linkStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkStatus()));

                        var validator = new ApiLinkStatusRequestModelValidator(linkStatusRepository.Object);
                        await validator.ValidateCreateAsync(new ApiLinkStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ILinkStatusRepository> linkStatusRepository = new Mock<ILinkStatusRepository>();
                        linkStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkStatus()));

                        var validator = new ApiLinkStatusRequestModelValidator(linkStatusRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiLinkStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ILinkStatusRepository> linkStatusRepository = new Mock<ILinkStatusRepository>();
                        linkStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkStatus()));

                        var validator = new ApiLinkStatusRequestModelValidator(linkStatusRepository.Object);
                        await validator.ValidateCreateAsync(new ApiLinkStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ILinkStatusRepository> linkStatusRepository = new Mock<ILinkStatusRepository>();
                        linkStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkStatus()));

                        var validator = new ApiLinkStatusRequestModelValidator(linkStatusRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiLinkStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<ILinkStatusRepository> linkStatusRepository = new Mock<ILinkStatusRepository>();
                        linkStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkStatus()));

                        var validator = new ApiLinkStatusRequestModelValidator(linkStatusRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>2d2543214672f6d15d43ac2f644ac606</Hash>
</Codenesium>*/