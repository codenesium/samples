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
        [Trait("Table", "Invitation")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiInvitationRequestModelValidatorTest
        {
                public ApiInvitationRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void InvitationCode_Create_null()
                {
                        Mock<IInvitationRepository> invitationRepository = new Mock<IInvitationRepository>();
                        invitationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Invitation()));

                        var validator = new ApiInvitationRequestModelValidator(invitationRepository.Object);

                        await validator.ValidateCreateAsync(new ApiInvitationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.InvitationCode, null as string);
                }

                [Fact]
                public async void InvitationCode_Update_null()
                {
                        Mock<IInvitationRepository> invitationRepository = new Mock<IInvitationRepository>();
                        invitationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Invitation()));

                        var validator = new ApiInvitationRequestModelValidator(invitationRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiInvitationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.InvitationCode, null as string);
                }

                [Fact]
                public async void InvitationCode_Create_length()
                {
                        Mock<IInvitationRepository> invitationRepository = new Mock<IInvitationRepository>();
                        invitationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Invitation()));

                        var validator = new ApiInvitationRequestModelValidator(invitationRepository.Object);

                        await validator.ValidateCreateAsync(new ApiInvitationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.InvitationCode, new string('A', 201));
                }

                [Fact]
                public async void InvitationCode_Update_length()
                {
                        Mock<IInvitationRepository> invitationRepository = new Mock<IInvitationRepository>();
                        invitationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Invitation()));

                        var validator = new ApiInvitationRequestModelValidator(invitationRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiInvitationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.InvitationCode, new string('A', 201));
                }

                [Fact]
                public async void InvitationCode_Delete()
                {
                        Mock<IInvitationRepository> invitationRepository = new Mock<IInvitationRepository>();
                        invitationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Invitation()));

                        var validator = new ApiInvitationRequestModelValidator(invitationRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IInvitationRepository> invitationRepository = new Mock<IInvitationRepository>();
                        invitationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Invitation()));

                        var validator = new ApiInvitationRequestModelValidator(invitationRepository.Object);

                        await validator.ValidateCreateAsync(new ApiInvitationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IInvitationRepository> invitationRepository = new Mock<IInvitationRepository>();
                        invitationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Invitation()));

                        var validator = new ApiInvitationRequestModelValidator(invitationRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiInvitationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }
        }
}

/*<Codenesium>
    <Hash>cf900162f6749a19055d9758cebc4a8e</Hash>
</Codenesium>*/