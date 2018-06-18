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
        [Trait("Table", "Vendor")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiVendorRequestModelValidatorTest
        {
                public ApiVendorRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void AccountNumber_Create_null()
                {
                        Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
                        vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

                        var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);

                        await validator.ValidateCreateAsync(new ApiVendorRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, null as string);
                }

                [Fact]
                public async void AccountNumber_Update_null()
                {
                        Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
                        vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

                        var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiVendorRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, null as string);
                }

                [Fact]
                public async void AccountNumber_Create_length()
                {
                        Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
                        vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

                        var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);

                        await validator.ValidateCreateAsync(new ApiVendorRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, new string('A', 16));
                }

                [Fact]
                public async void AccountNumber_Update_length()
                {
                        Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
                        vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

                        var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiVendorRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, new string('A', 16));
                }

                [Fact]
                public async void AccountNumber_Delete()
                {
                        Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
                        vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

                        var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
                        vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

                        var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);

                        await validator.ValidateCreateAsync(new ApiVendorRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
                        vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

                        var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiVendorRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
                        vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

                        var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);

                        await validator.ValidateCreateAsync(new ApiVendorRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
                        vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

                        var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiVendorRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
                        vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

                        var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void PurchasingWebServiceURL_Create_length()
                {
                        Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
                        vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

                        var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);

                        await validator.ValidateCreateAsync(new ApiVendorRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PurchasingWebServiceURL, new string('A', 1025));
                }

                [Fact]
                public async void PurchasingWebServiceURL_Update_length()
                {
                        Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
                        vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

                        var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiVendorRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PurchasingWebServiceURL, new string('A', 1025));
                }

                [Fact]
                public async void PurchasingWebServiceURL_Delete()
                {
                        Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
                        vendorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));

                        var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueByAccountNumber_Create_Exists()
                {
                        Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
                        vendorRepository.Setup(x => x.ByAccountNumber(It.IsAny<string>())).Returns(Task.FromResult<Vendor>(new Vendor()));
                        var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);

                        await validator.ValidateCreateAsync(new ApiVendorRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, "A");
                }

                [Fact]
                private async void BeUniqueByAccountNumber_Create_Not_Exists()
                {
                        Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
                        vendorRepository.Setup(x => x.ByAccountNumber(It.IsAny<string>())).Returns(Task.FromResult<Vendor>(null));
                        var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);

                        await validator.ValidateCreateAsync(new ApiVendorRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.AccountNumber, "A");
                }

                [Fact]
                private async void BeUniqueByAccountNumber_Update_Exists()
                {
                        Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
                        vendorRepository.Setup(x => x.ByAccountNumber(It.IsAny<string>())).Returns(Task.FromResult<Vendor>(new Vendor()));
                        var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiVendorRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, "A");
                }

                [Fact]
                private async void BeUniqueByAccountNumber_Update_Not_Exists()
                {
                        Mock<IVendorRepository> vendorRepository = new Mock<IVendorRepository>();
                        vendorRepository.Setup(x => x.ByAccountNumber(It.IsAny<string>())).Returns(Task.FromResult<Vendor>(null));
                        var validator = new ApiVendorRequestModelValidator(vendorRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiVendorRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.AccountNumber, "A");
                }
        }
}

/*<Codenesium>
    <Hash>2196156aedf84a6d8c0a59872e46e971</Hash>
</Codenesium>*/