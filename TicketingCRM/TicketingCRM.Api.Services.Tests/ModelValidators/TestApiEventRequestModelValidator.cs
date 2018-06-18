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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services.Tests
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
                public async void Address1_Create_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Address1, null as string);
                }

                [Fact]
                public async void Address1_Update_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Address1, null as string);
                }

                [Fact]
                public async void Address1_Create_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Address1, new string('A', 129));
                }

                [Fact]
                public async void Address1_Update_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Address1, new string('A', 129));
                }

                [Fact]
                public async void Address1_Delete()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Address2_Create_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Address2, null as string);
                }

                [Fact]
                public async void Address2_Update_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Address2, null as string);
                }

                [Fact]
                public async void Address2_Create_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Address2, new string('A', 129));
                }

                [Fact]
                public async void Address2_Update_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Address2, new string('A', 129));
                }

                [Fact]
                public async void Address2_Delete()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void CityId_Create_Valid_Reference()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.GetCity(It.IsAny<int>())).Returns(Task.FromResult<City>(new City()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CityId, 1);
                }

                [Fact]
                public async void CityId_Create_Invalid_Reference()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.GetCity(It.IsAny<int>())).Returns(Task.FromResult<City>(null));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CityId, 1);
                }

                [Fact]
                public async void CityId_Update_Valid_Reference()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.GetCity(It.IsAny<int>())).Returns(Task.FromResult<City>(new City()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEventRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CityId, 1);
                }

                [Fact]
                public async void CityId_Update_Invalid_Reference()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.GetCity(It.IsAny<int>())).Returns(Task.FromResult<City>(null));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CityId, 1);
                }

                [Fact]
                public async void Description_Create_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
                }

                [Fact]
                public async void Description_Update_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
                }

                [Fact]
                public async void Facebook_Create_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Facebook, null as string);
                }

                [Fact]
                public async void Facebook_Update_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Facebook, null as string);
                }

                [Fact]
                public async void Facebook_Create_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Facebook, new string('A', 129));
                }

                [Fact]
                public async void Facebook_Update_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Facebook, new string('A', 129));
                }

                [Fact]
                public async void Facebook_Delete()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Website_Create_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Website, null as string);
                }

                [Fact]
                public async void Website_Update_null()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Website, null as string);
                }

                [Fact]
                public async void Website_Create_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateCreateAsync(new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Website, new string('A', 129));
                }

                [Fact]
                public async void Website_Update_length()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiEventRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Website, new string('A', 129));
                }

                [Fact]
                public async void Website_Delete()
                {
                        Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
                        eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

                        var validator = new ApiEventRequestModelValidator(eventRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>16b43ff97d4ba12e6d429ec1ba5fc823</Hash>
</Codenesium>*/