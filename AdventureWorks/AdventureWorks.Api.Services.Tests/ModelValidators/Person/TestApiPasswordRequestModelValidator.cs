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
        [Trait("Table", "Password")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiPasswordRequestModelValidatorTest
        {
                public ApiPasswordRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void PasswordHash_Create_null()
                {
                        Mock<IPasswordRepository> passwordRepository = new Mock<IPasswordRepository>();
                        passwordRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Password()));

                        var validator = new ApiPasswordRequestModelValidator(passwordRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPasswordRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PasswordHash, null as string);
                }

                [Fact]
                public async void PasswordHash_Update_null()
                {
                        Mock<IPasswordRepository> passwordRepository = new Mock<IPasswordRepository>();
                        passwordRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Password()));

                        var validator = new ApiPasswordRequestModelValidator(passwordRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPasswordRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PasswordHash, null as string);
                }

                [Fact]
                public async void PasswordHash_Create_length()
                {
                        Mock<IPasswordRepository> passwordRepository = new Mock<IPasswordRepository>();
                        passwordRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Password()));

                        var validator = new ApiPasswordRequestModelValidator(passwordRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPasswordRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PasswordHash, new string('A', 129));
                }

                [Fact]
                public async void PasswordHash_Update_length()
                {
                        Mock<IPasswordRepository> passwordRepository = new Mock<IPasswordRepository>();
                        passwordRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Password()));

                        var validator = new ApiPasswordRequestModelValidator(passwordRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPasswordRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PasswordHash, new string('A', 129));
                }

                [Fact]
                public async void PasswordSalt_Create_null()
                {
                        Mock<IPasswordRepository> passwordRepository = new Mock<IPasswordRepository>();
                        passwordRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Password()));

                        var validator = new ApiPasswordRequestModelValidator(passwordRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPasswordRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PasswordSalt, null as string);
                }

                [Fact]
                public async void PasswordSalt_Update_null()
                {
                        Mock<IPasswordRepository> passwordRepository = new Mock<IPasswordRepository>();
                        passwordRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Password()));

                        var validator = new ApiPasswordRequestModelValidator(passwordRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPasswordRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PasswordSalt, null as string);
                }

                [Fact]
                public async void PasswordSalt_Create_length()
                {
                        Mock<IPasswordRepository> passwordRepository = new Mock<IPasswordRepository>();
                        passwordRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Password()));

                        var validator = new ApiPasswordRequestModelValidator(passwordRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPasswordRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PasswordSalt, new string('A', 11));
                }

                [Fact]
                public async void PasswordSalt_Update_length()
                {
                        Mock<IPasswordRepository> passwordRepository = new Mock<IPasswordRepository>();
                        passwordRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Password()));

                        var validator = new ApiPasswordRequestModelValidator(passwordRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPasswordRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PasswordSalt, new string('A', 11));
                }
        }
}

/*<Codenesium>
    <Hash>18edad86ad4b5b78b70071fb90e776a2</Hash>
</Codenesium>*/