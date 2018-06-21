using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "AddressType")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiAddressTypeRequestModelValidatorTest
        {
                public ApiAddressTypeRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IAddressTypeRepository> addressTypeRepository = new Mock<IAddressTypeRepository>();
                        addressTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AddressType()));

                        var validator = new ApiAddressTypeRequestModelValidator(addressTypeRepository.Object);
                        await validator.ValidateCreateAsync(new ApiAddressTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IAddressTypeRepository> addressTypeRepository = new Mock<IAddressTypeRepository>();
                        addressTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AddressType()));

                        var validator = new ApiAddressTypeRequestModelValidator(addressTypeRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiAddressTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IAddressTypeRepository> addressTypeRepository = new Mock<IAddressTypeRepository>();
                        addressTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AddressType()));

                        var validator = new ApiAddressTypeRequestModelValidator(addressTypeRepository.Object);
                        await validator.ValidateCreateAsync(new ApiAddressTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IAddressTypeRepository> addressTypeRepository = new Mock<IAddressTypeRepository>();
                        addressTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AddressType()));

                        var validator = new ApiAddressTypeRequestModelValidator(addressTypeRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiAddressTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IAddressTypeRepository> addressTypeRepository = new Mock<IAddressTypeRepository>();
                        addressTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AddressType()));

                        var validator = new ApiAddressTypeRequestModelValidator(addressTypeRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueByName_Create_Exists()
                {
                        Mock<IAddressTypeRepository> addressTypeRepository = new Mock<IAddressTypeRepository>();
                        addressTypeRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<AddressType>(new AddressType()));
                        var validator = new ApiAddressTypeRequestModelValidator(addressTypeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAddressTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Create_Not_Exists()
                {
                        Mock<IAddressTypeRepository> addressTypeRepository = new Mock<IAddressTypeRepository>();
                        addressTypeRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<AddressType>(null));
                        var validator = new ApiAddressTypeRequestModelValidator(addressTypeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAddressTypeRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Exists()
                {
                        Mock<IAddressTypeRepository> addressTypeRepository = new Mock<IAddressTypeRepository>();
                        addressTypeRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<AddressType>(new AddressType()));
                        var validator = new ApiAddressTypeRequestModelValidator(addressTypeRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiAddressTypeRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Not_Exists()
                {
                        Mock<IAddressTypeRepository> addressTypeRepository = new Mock<IAddressTypeRepository>();
                        addressTypeRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<AddressType>(null));
                        var validator = new ApiAddressTypeRequestModelValidator(addressTypeRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiAddressTypeRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>188294e0404496b22fafb22510f590db</Hash>
</Codenesium>*/