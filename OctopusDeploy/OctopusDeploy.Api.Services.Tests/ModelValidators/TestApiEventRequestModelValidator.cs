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
        [Trait("Table", "Event")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiEventRequestModelValidatorTest
        {
                public ApiEventRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Category_Create_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Category, null as string);
                }

                [Fact]
                public async void Category_Update_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Category, null as string);
                }

                [Fact]
                public async void Category_Create_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Category, new string('A', 51));
                }

                [Fact]
                public async void Category_Update_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Category, new string('A', 51));
                }

                [Fact]
                public async void Category_Delete()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void EnvironmentId_Create_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, new string('A', 51));
                }

                [Fact]
                public async void EnvironmentId_Update_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, new string('A', 51));
                }

                [Fact]
                public async void EnvironmentId_Delete()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Message_Create_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Message, null as string);
                }

                [Fact]
                public async void Message_Update_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Message, null as string);
                }

                [Fact]
                public async void ProjectId_Create_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, new string('A', 51));
                }

                [Fact]
                public async void ProjectId_Update_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProjectId, new string('A', 51));
                }

                [Fact]
                public async void ProjectId_Delete()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void RelatedDocumentIds_Create_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.RelatedDocumentIds, null as string);
                }

                [Fact]
                public async void RelatedDocumentIds_Update_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.RelatedDocumentIds, null as string);
                }

                [Fact]
                public async void TenantId_Create_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TenantId, new string('A', 51));
                }

                [Fact]
                public async void TenantId_Update_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TenantId, new string('A', 51));
                }

                [Fact]
                public async void TenantId_Delete()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void UserId_Create_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UserId, null as string);
                }

                [Fact]
                public async void UserId_Update_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UserId, null as string);
                }

                [Fact]
                public async void UserId_Create_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UserId, new string('A', 51));
                }

                [Fact]
                public async void UserId_Update_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UserId, new string('A', 51));
                }

                [Fact]
                public async void UserId_Delete()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Username_Create_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Username, null as string);
                }

                [Fact]
                public async void Username_Update_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Username, null as string);
                }

                [Fact]
                public async void Username_Create_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Username, new string('A', 201));
                }

                [Fact]
                public async void Username_Update_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Username, new string('A', 201));
                }

                [Fact]
                public async void Username_Delete()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>5f0c2b4f1a46dbca0c01ecb9eeee2d06</Hash>
</Codenesium>*/