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
        [Trait("Table", "EventRelatedDocument")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiEventRelatedDocumentRequestModelValidatorTest
        {
                public ApiEventRelatedDocumentRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void EventId_Create_null()
                {
                        Mock<IEventRelatedDocumentRepository> eventRelatedDocumentRepository = new Mock<IEventRelatedDocumentRepository>();
                        eventRelatedDocumentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventRelatedDocument()));

                        var validator = new ApiEventRelatedDocumentRequestModelValidator(eventRelatedDocumentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRelatedDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EventId, null as string);
                }

                [Fact]
                public async void EventId_Update_null()
                {
                        Mock<IEventRelatedDocumentRepository> eventRelatedDocumentRepository = new Mock<IEventRelatedDocumentRepository>();
                        eventRelatedDocumentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventRelatedDocument()));

                        var validator = new ApiEventRelatedDocumentRequestModelValidator(eventRelatedDocumentRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEventRelatedDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EventId, null as string);
                }

                [Fact]
                public async void EventId_Create_length()
                {
                        Mock<IEventRelatedDocumentRepository> eventRelatedDocumentRepository = new Mock<IEventRelatedDocumentRepository>();
                        eventRelatedDocumentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventRelatedDocument()));

                        var validator = new ApiEventRelatedDocumentRequestModelValidator(eventRelatedDocumentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRelatedDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EventId, new string('A', 51));
                }

                [Fact]
                public async void EventId_Update_length()
                {
                        Mock<IEventRelatedDocumentRepository> eventRelatedDocumentRepository = new Mock<IEventRelatedDocumentRepository>();
                        eventRelatedDocumentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventRelatedDocument()));

                        var validator = new ApiEventRelatedDocumentRequestModelValidator(eventRelatedDocumentRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEventRelatedDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EventId, new string('A', 51));
                }

                [Fact]
                public async void EventId_Delete()
                {
                        Mock<IEventRelatedDocumentRepository> eventRelatedDocumentRepository = new Mock<IEventRelatedDocumentRepository>();
                        eventRelatedDocumentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventRelatedDocument()));

                        var validator = new ApiEventRelatedDocumentRequestModelValidator(eventRelatedDocumentRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void EventId_Create_Valid_Reference()
                {
                        Mock<IEventRelatedDocumentRepository> eventRelatedDocumentRepository = new Mock<IEventRelatedDocumentRepository>();
                        eventRelatedDocumentRepository.Setup(x => x.GetEvent(It.IsAny<string>())).Returns(Task.FromResult<Event>(new Event()));

                        var validator = new ApiEventRelatedDocumentRequestModelValidator(eventRelatedDocumentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRelatedDocumentRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.EventId, "A");
                }

                [Fact]
                public async void EventId_Create_Invalid_Reference()
                {
                        Mock<IEventRelatedDocumentRepository> eventRelatedDocumentRepository = new Mock<IEventRelatedDocumentRepository>();
                        eventRelatedDocumentRepository.Setup(x => x.GetEvent(It.IsAny<string>())).Returns(Task.FromResult<Event>(null));

                        var validator = new ApiEventRelatedDocumentRequestModelValidator(eventRelatedDocumentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRelatedDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EventId, "A");
                }

                [Fact]
                public async void EventId_Update_Valid_Reference()
                {
                        Mock<IEventRelatedDocumentRepository> eventRelatedDocumentRepository = new Mock<IEventRelatedDocumentRepository>();
                        eventRelatedDocumentRepository.Setup(x => x.GetEvent(It.IsAny<string>())).Returns(Task.FromResult<Event>(new Event()));

                        var validator = new ApiEventRelatedDocumentRequestModelValidator(eventRelatedDocumentRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEventRelatedDocumentRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.EventId, "A");
                }

                [Fact]
                public async void EventId_Update_Invalid_Reference()
                {
                        Mock<IEventRelatedDocumentRepository> eventRelatedDocumentRepository = new Mock<IEventRelatedDocumentRepository>();
                        eventRelatedDocumentRepository.Setup(x => x.GetEvent(It.IsAny<string>())).Returns(Task.FromResult<Event>(null));

                        var validator = new ApiEventRelatedDocumentRequestModelValidator(eventRelatedDocumentRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEventRelatedDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EventId, "A");
                }

                [Fact]
                public async void RelatedDocumentId_Create_null()
                {
                        Mock<IEventRelatedDocumentRepository> eventRelatedDocumentRepository = new Mock<IEventRelatedDocumentRepository>();
                        eventRelatedDocumentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventRelatedDocument()));

                        var validator = new ApiEventRelatedDocumentRequestModelValidator(eventRelatedDocumentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRelatedDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.RelatedDocumentId, null as string);
                }

                [Fact]
                public async void RelatedDocumentId_Update_null()
                {
                        Mock<IEventRelatedDocumentRepository> eventRelatedDocumentRepository = new Mock<IEventRelatedDocumentRepository>();
                        eventRelatedDocumentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventRelatedDocument()));

                        var validator = new ApiEventRelatedDocumentRequestModelValidator(eventRelatedDocumentRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEventRelatedDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.RelatedDocumentId, null as string);
                }

                [Fact]
                public async void RelatedDocumentId_Create_length()
                {
                        Mock<IEventRelatedDocumentRepository> eventRelatedDocumentRepository = new Mock<IEventRelatedDocumentRepository>();
                        eventRelatedDocumentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventRelatedDocument()));

                        var validator = new ApiEventRelatedDocumentRequestModelValidator(eventRelatedDocumentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRelatedDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.RelatedDocumentId, new string('A', 251));
                }

                [Fact]
                public async void RelatedDocumentId_Update_length()
                {
                        Mock<IEventRelatedDocumentRepository> eventRelatedDocumentRepository = new Mock<IEventRelatedDocumentRepository>();
                        eventRelatedDocumentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventRelatedDocument()));

                        var validator = new ApiEventRelatedDocumentRequestModelValidator(eventRelatedDocumentRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEventRelatedDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.RelatedDocumentId, new string('A', 251));
                }

                [Fact]
                public async void RelatedDocumentId_Delete()
                {
                        Mock<IEventRelatedDocumentRepository> eventRelatedDocumentRepository = new Mock<IEventRelatedDocumentRepository>();
                        eventRelatedDocumentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventRelatedDocument()));

                        var validator = new ApiEventRelatedDocumentRequestModelValidator(eventRelatedDocumentRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>7c8283f7d89e902b102826cc3488e47e</Hash>
</Codenesium>*/