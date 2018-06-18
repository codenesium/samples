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

                        await validator.ValidateUpdateAsync(default (int), new ApiLinkStatusRequestModel());

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

                        await validator.ValidateUpdateAsync(default (int), new ApiLinkStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<ILinkStatusRepository> linkStatusRepository = new Mock<ILinkStatusRepository>();
                        linkStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkStatus()));

                        var validator = new ApiLinkStatusRequestModelValidator(linkStatusRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>100690ba7cb0ae8a1793a7700a94896e</Hash>
</Codenesium>*/