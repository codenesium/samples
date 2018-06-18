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
        [Trait("Table", "Address")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiAddressRequestModelValidatorTest
        {
                public ApiAddressRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void AddressLine1_Create_null()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAddressRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AddressLine1, null as string);
                }

                [Fact]
                public async void AddressLine1_Update_null()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAddressRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AddressLine1, null as string);
                }

                [Fact]
                public async void AddressLine1_Create_length()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAddressRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AddressLine1, new string('A', 61));
                }

                [Fact]
                public async void AddressLine1_Update_length()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAddressRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AddressLine1, new string('A', 61));
                }

                [Fact]
                public async void AddressLine1_Delete()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void AddressLine2_Create_length()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAddressRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AddressLine2, new string('A', 61));
                }

                [Fact]
                public async void AddressLine2_Update_length()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAddressRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AddressLine2, new string('A', 61));
                }

                [Fact]
                public async void AddressLine2_Delete()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void City_Create_null()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAddressRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.City, null as string);
                }

                [Fact]
                public async void City_Update_null()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAddressRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.City, null as string);
                }

                [Fact]
                public async void City_Create_length()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAddressRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.City, new string('A', 31));
                }

                [Fact]
                public async void City_Update_length()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAddressRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.City, new string('A', 31));
                }

                [Fact]
                public async void City_Delete()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void PostalCode_Create_null()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAddressRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PostalCode, null as string);
                }

                [Fact]
                public async void PostalCode_Update_null()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAddressRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PostalCode, null as string);
                }

                [Fact]
                public async void PostalCode_Create_length()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAddressRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PostalCode, new string('A', 16));
                }

                [Fact]
                public async void PostalCode_Update_length()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAddressRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PostalCode, new string('A', 16));
                }

                [Fact]
                public async void PostalCode_Delete()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));

                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueByAddressLine1AddressLine2CityStateProvinceIDPostalCode_Create_Exists()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<Address>(new Address()));
                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAddressRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AddressLine1, "A");
                }

                [Fact]
                private async void BeUniqueByAddressLine1AddressLine2CityStateProvinceIDPostalCode_Create_Not_Exists()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<Address>(null));
                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAddressRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.AddressLine1, "A");
                }

                [Fact]
                private async void BeUniqueByAddressLine1AddressLine2CityStateProvinceIDPostalCode_Update_Exists()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<Address>(new Address()));
                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAddressRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AddressLine1, "A");
                }

                [Fact]
                private async void BeUniqueByAddressLine1AddressLine2CityStateProvinceIDPostalCode_Update_Not_Exists()
                {
                        Mock<IAddressRepository> addressRepository = new Mock<IAddressRepository>();
                        addressRepository.Setup(x => x.ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<Address>(null));
                        var validator = new ApiAddressRequestModelValidator(addressRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiAddressRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.AddressLine1, "A");
                }
        }
}

/*<Codenesium>
    <Hash>b6ad355a27075dbd22bc9c3686d54d49</Hash>
</Codenesium>*/