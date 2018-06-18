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
        [Trait("Table", "Customer")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiCustomerRequestModelValidatorTest
        {
                public ApiCustomerRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Email_Create_null()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
                }

                [Fact]
                public async void Email_Update_null()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
                }

                [Fact]
                public async void Email_Create_length()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
                }

                [Fact]
                public async void Email_Update_length()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
                }

                [Fact]
                public async void Email_Delete()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void FirstName_Create_null()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
                }

                [Fact]
                public async void FirstName_Update_null()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
                }

                [Fact]
                public async void FirstName_Create_length()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
                }

                [Fact]
                public async void FirstName_Update_length()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
                }

                [Fact]
                public async void FirstName_Delete()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void LastName_Create_null()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
                }

                [Fact]
                public async void LastName_Update_null()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
                }

                [Fact]
                public async void LastName_Create_length()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
                }

                [Fact]
                public async void LastName_Update_length()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
                }

                [Fact]
                public async void LastName_Delete()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Phone_Create_null()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
                }

                [Fact]
                public async void Phone_Update_null()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
                }

                [Fact]
                public async void Phone_Create_length()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
                }

                [Fact]
                public async void Phone_Update_length()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
                }

                [Fact]
                public async void Phone_Delete()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>969a79589ce77a5762a1bff27c19e31b</Hash>
</Codenesium>*/