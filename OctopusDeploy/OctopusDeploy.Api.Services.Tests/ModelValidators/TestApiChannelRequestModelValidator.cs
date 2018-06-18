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
        [Trait("Table", "Channel")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiChannelRequestModelValidatorTest
        {
                public ApiChannelRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IChannelRepository> channelRepository = new Mock<IChannelRepository>();
                        channelRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Channel()));

                        var validator = new ApiChannelRequestModelValidator(channelRepository.Object);

                        await validator.ValidateCreateAsync(new ApiChannelRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IChannelRepository> channelRepository = new Mock<IChannelRepository>();
                        channelRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Channel()));

                        var validator = new ApiChannelRequestModelValidator(channelRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiChannelRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void LifecycleId_Create_length()
                {
                        Mock<IChannelRepository> channelRepository = new Mock<IChannelRepository>();
                        channelRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Channel()));

                        var validator = new ApiChannelRequestModelValidator(channelRepository.Object);

                        await validator.ValidateCreateAsync(new ApiChannelRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LifecycleId, new string('A', 51));
                }

                [Fact]
                public async void LifecycleId_Update_length()
                {
                        Mock<IChannelRepository> channelRepository = new Mock<IChannelRepository>();
                        channelRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Channel()));

                        var validator = new ApiChannelRequestModelValidator(channelRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiChannelRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LifecycleId, new string('A', 51));
                }

                [Fact]
                public async void LifecycleId_Delete()
                {
                        Mock<IChannelRepository> channelRepository = new Mock<IChannelRepository>();
                        channelRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Channel()));

                        var validator = new ApiChannelRequestModelValidator(channelRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IChannelRepository> channelRepository = new Mock<IChannelRepository>();
                        channelRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Channel()));

                        var validator = new ApiChannelRequestModelValidator(channelRepository.Object);

                        await validator.ValidateCreateAsync(new ApiChannelRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IChannelRepository> channelRepository = new Mock<IChannelRepository>();
                        channelRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Channel()));

                        var validator = new ApiChannelRequestModelValidator(channelRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiChannelRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IChannelRepository> channelRepository = new Mock<IChannelRepository>();
                        channelRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Channel()));

                        var validator = new ApiChannelRequestModelValidator(channelRepository.Object);

                        await validator.ValidateCreateAsync(new ApiChannelRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IChannelRepository> channelRepository = new Mock<IChannelRepository>();
                        channelRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Channel()));

                        var validator = new ApiChannelRequestModelValidator(channelRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiChannelRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IChannelRepository> channelRepository = new Mock<IChannelRepository>();
                        channelRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Channel()));

                        var validator = new ApiChannelRequestModelValidator(channelRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void ProjectId_Create_null()
                {
                        Mock<IChannelRepository> channelRepository = new Mock<IChannelRepository>();
                        channelRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Channel()));

                        var validator = new ApiChannelRequestModelValidator(channelRepository.Object);

                        await validator.ValidateCreateAsync(new ApiChannelRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, null as string);
                }

                [Fact]
                public async void ProjectId_Update_null()
                {
                        Mock<IChannelRepository> channelRepository = new Mock<IChannelRepository>();
                        channelRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Channel()));

                        var validator = new ApiChannelRequestModelValidator(channelRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiChannelRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, null as string);
                }

                [Fact]
                public async void ProjectId_Create_length()
                {
                        Mock<IChannelRepository> channelRepository = new Mock<IChannelRepository>();
                        channelRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Channel()));

                        var validator = new ApiChannelRequestModelValidator(channelRepository.Object);

                        await validator.ValidateCreateAsync(new ApiChannelRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, new string('A', 51));
                }

                [Fact]
                public async void ProjectId_Update_length()
                {
                        Mock<IChannelRepository> channelRepository = new Mock<IChannelRepository>();
                        channelRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Channel()));

                        var validator = new ApiChannelRequestModelValidator(channelRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiChannelRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, new string('A', 51));
                }

                [Fact]
                public async void ProjectId_Delete()
                {
                        Mock<IChannelRepository> channelRepository = new Mock<IChannelRepository>();
                        channelRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Channel()));

                        var validator = new ApiChannelRequestModelValidator(channelRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueGetNameProjectId_Create_Exists()
                {
                        Mock<IChannelRepository> channelRepository = new Mock<IChannelRepository>();
                        channelRepository.Setup(x => x.GetNameProjectId(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<Channel>(new Channel()));
                        var validator = new ApiChannelRequestModelValidator(channelRepository.Object);

                        await validator.ValidateCreateAsync(new ApiChannelRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetNameProjectId_Create_Not_Exists()
                {
                        Mock<IChannelRepository> channelRepository = new Mock<IChannelRepository>();
                        channelRepository.Setup(x => x.GetNameProjectId(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<Channel>(null));
                        var validator = new ApiChannelRequestModelValidator(channelRepository.Object);

                        await validator.ValidateCreateAsync(new ApiChannelRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetNameProjectId_Update_Exists()
                {
                        Mock<IChannelRepository> channelRepository = new Mock<IChannelRepository>();
                        channelRepository.Setup(x => x.GetNameProjectId(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<Channel>(new Channel()));
                        var validator = new ApiChannelRequestModelValidator(channelRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiChannelRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetNameProjectId_Update_Not_Exists()
                {
                        Mock<IChannelRepository> channelRepository = new Mock<IChannelRepository>();
                        channelRepository.Setup(x => x.GetNameProjectId(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<Channel>(null));
                        var validator = new ApiChannelRequestModelValidator(channelRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiChannelRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>97e609a954cc08afb26efb13b8cd9791</Hash>
</Codenesium>*/