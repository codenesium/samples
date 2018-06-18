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
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ContactType")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiContactTypeRequestModelValidatorTest
        {
                public ApiContactTypeRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IContactTypeRepository> contactTypeRepository = new Mock<IContactTypeRepository>();
                        contactTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ContactType()));

                        var validator = new ApiContactTypeRequestModelValidator(contactTypeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiContactTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IContactTypeRepository> contactTypeRepository = new Mock<IContactTypeRepository>();
                        contactTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ContactType()));

                        var validator = new ApiContactTypeRequestModelValidator(contactTypeRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiContactTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IContactTypeRepository> contactTypeRepository = new Mock<IContactTypeRepository>();
                        contactTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ContactType()));

                        var validator = new ApiContactTypeRequestModelValidator(contactTypeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiContactTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IContactTypeRepository> contactTypeRepository = new Mock<IContactTypeRepository>();
                        contactTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ContactType()));

                        var validator = new ApiContactTypeRequestModelValidator(contactTypeRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiContactTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IContactTypeRepository> contactTypeRepository = new Mock<IContactTypeRepository>();
                        contactTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ContactType()));

                        var validator = new ApiContactTypeRequestModelValidator(contactTypeRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueByName_Create_Exists()
                {
                        Mock<IContactTypeRepository> contactTypeRepository = new Mock<IContactTypeRepository>();
                        contactTypeRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ContactType>(new ContactType()));
                        var validator = new ApiContactTypeRequestModelValidator(contactTypeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiContactTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Create_Not_Exists()
                {
                        Mock<IContactTypeRepository> contactTypeRepository = new Mock<IContactTypeRepository>();
                        contactTypeRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ContactType>(null));
                        var validator = new ApiContactTypeRequestModelValidator(contactTypeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiContactTypeRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Exists()
                {
                        Mock<IContactTypeRepository> contactTypeRepository = new Mock<IContactTypeRepository>();
                        contactTypeRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ContactType>(new ContactType()));
                        var validator = new ApiContactTypeRequestModelValidator(contactTypeRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiContactTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Not_Exists()
                {
                        Mock<IContactTypeRepository> contactTypeRepository = new Mock<IContactTypeRepository>();
                        contactTypeRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ContactType>(null));
                        var validator = new ApiContactTypeRequestModelValidator(contactTypeRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiContactTypeRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>92871da55b5272553acd684f4bd8a0ca</Hash>
</Codenesium>*/