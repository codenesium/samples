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
        [Trait("Table", "Feed")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiFeedRequestModelValidatorTest
        {
                public ApiFeedRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void FeedType_Create_null()
                {
                        Mock<IFeedRepository> feedRepository = new Mock<IFeedRepository>();
                        feedRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Feed()));

                        var validator = new ApiFeedRequestModelValidator(feedRepository.Object);
                        await validator.ValidateCreateAsync(new ApiFeedRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FeedType, null as string);
                }

                [Fact]
                public async void FeedType_Update_null()
                {
                        Mock<IFeedRepository> feedRepository = new Mock<IFeedRepository>();
                        feedRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Feed()));

                        var validator = new ApiFeedRequestModelValidator(feedRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiFeedRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FeedType, null as string);
                }

                [Fact]
                public async void FeedType_Create_length()
                {
                        Mock<IFeedRepository> feedRepository = new Mock<IFeedRepository>();
                        feedRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Feed()));

                        var validator = new ApiFeedRequestModelValidator(feedRepository.Object);
                        await validator.ValidateCreateAsync(new ApiFeedRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FeedType, new string('A', 51));
                }

                [Fact]
                public async void FeedType_Update_length()
                {
                        Mock<IFeedRepository> feedRepository = new Mock<IFeedRepository>();
                        feedRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Feed()));

                        var validator = new ApiFeedRequestModelValidator(feedRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiFeedRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FeedType, new string('A', 51));
                }

                [Fact]
                public async void FeedType_Delete()
                {
                        Mock<IFeedRepository> feedRepository = new Mock<IFeedRepository>();
                        feedRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Feed()));

                        var validator = new ApiFeedRequestModelValidator(feedRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void FeedUri_Create_null()
                {
                        Mock<IFeedRepository> feedRepository = new Mock<IFeedRepository>();
                        feedRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Feed()));

                        var validator = new ApiFeedRequestModelValidator(feedRepository.Object);
                        await validator.ValidateCreateAsync(new ApiFeedRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FeedUri, null as string);
                }

                [Fact]
                public async void FeedUri_Update_null()
                {
                        Mock<IFeedRepository> feedRepository = new Mock<IFeedRepository>();
                        feedRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Feed()));

                        var validator = new ApiFeedRequestModelValidator(feedRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiFeedRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FeedUri, null as string);
                }

                [Fact]
                public async void FeedUri_Create_length()
                {
                        Mock<IFeedRepository> feedRepository = new Mock<IFeedRepository>();
                        feedRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Feed()));

                        var validator = new ApiFeedRequestModelValidator(feedRepository.Object);
                        await validator.ValidateCreateAsync(new ApiFeedRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FeedUri, new string('A', 513));
                }

                [Fact]
                public async void FeedUri_Update_length()
                {
                        Mock<IFeedRepository> feedRepository = new Mock<IFeedRepository>();
                        feedRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Feed()));

                        var validator = new ApiFeedRequestModelValidator(feedRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiFeedRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FeedUri, new string('A', 513));
                }

                [Fact]
                public async void FeedUri_Delete()
                {
                        Mock<IFeedRepository> feedRepository = new Mock<IFeedRepository>();
                        feedRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Feed()));

                        var validator = new ApiFeedRequestModelValidator(feedRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IFeedRepository> feedRepository = new Mock<IFeedRepository>();
                        feedRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Feed()));

                        var validator = new ApiFeedRequestModelValidator(feedRepository.Object);
                        await validator.ValidateCreateAsync(new ApiFeedRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IFeedRepository> feedRepository = new Mock<IFeedRepository>();
                        feedRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Feed()));

                        var validator = new ApiFeedRequestModelValidator(feedRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiFeedRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IFeedRepository> feedRepository = new Mock<IFeedRepository>();
                        feedRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Feed()));

                        var validator = new ApiFeedRequestModelValidator(feedRepository.Object);
                        await validator.ValidateCreateAsync(new ApiFeedRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IFeedRepository> feedRepository = new Mock<IFeedRepository>();
                        feedRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Feed()));

                        var validator = new ApiFeedRequestModelValidator(feedRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiFeedRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IFeedRepository> feedRepository = new Mock<IFeedRepository>();
                        feedRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Feed()));

                        var validator = new ApiFeedRequestModelValidator(feedRepository.Object);
                        await validator.ValidateCreateAsync(new ApiFeedRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IFeedRepository> feedRepository = new Mock<IFeedRepository>();
                        feedRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Feed()));

                        var validator = new ApiFeedRequestModelValidator(feedRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiFeedRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IFeedRepository> feedRepository = new Mock<IFeedRepository>();
                        feedRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Feed()));

                        var validator = new ApiFeedRequestModelValidator(feedRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueGetName_Create_Exists()
                {
                        Mock<IFeedRepository> feedRepository = new Mock<IFeedRepository>();
                        feedRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Feed>(new Feed()));
                        var validator = new ApiFeedRequestModelValidator(feedRepository.Object);

                        await validator.ValidateCreateAsync(new ApiFeedRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Create_Not_Exists()
                {
                        Mock<IFeedRepository> feedRepository = new Mock<IFeedRepository>();
                        feedRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Feed>(null));
                        var validator = new ApiFeedRequestModelValidator(feedRepository.Object);

                        await validator.ValidateCreateAsync(new ApiFeedRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Exists()
                {
                        Mock<IFeedRepository> feedRepository = new Mock<IFeedRepository>();
                        feedRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Feed>(new Feed()));
                        var validator = new ApiFeedRequestModelValidator(feedRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiFeedRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Not_Exists()
                {
                        Mock<IFeedRepository> feedRepository = new Mock<IFeedRepository>();
                        feedRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Feed>(null));
                        var validator = new ApiFeedRequestModelValidator(feedRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiFeedRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>29f4b30d75548d3fd8b08da6d844d999</Hash>
</Codenesium>*/