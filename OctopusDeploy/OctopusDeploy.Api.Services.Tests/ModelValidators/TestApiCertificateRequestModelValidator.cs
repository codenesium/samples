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
        [Trait("Table", "Certificate")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiCertificateRequestModelValidatorTest
        {
                public ApiCertificateRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<ICertificateRepository> certificateRepository = new Mock<ICertificateRepository>();
                        certificateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Certificate()));

                        var validator = new ApiCertificateRequestModelValidator(certificateRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCertificateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<ICertificateRepository> certificateRepository = new Mock<ICertificateRepository>();
                        certificateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Certificate()));

                        var validator = new ApiCertificateRequestModelValidator(certificateRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCertificateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<ICertificateRepository> certificateRepository = new Mock<ICertificateRepository>();
                        certificateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Certificate()));

                        var validator = new ApiCertificateRequestModelValidator(certificateRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCertificateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ICertificateRepository> certificateRepository = new Mock<ICertificateRepository>();
                        certificateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Certificate()));

                        var validator = new ApiCertificateRequestModelValidator(certificateRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCertificateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ICertificateRepository> certificateRepository = new Mock<ICertificateRepository>();
                        certificateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Certificate()));

                        var validator = new ApiCertificateRequestModelValidator(certificateRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCertificateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ICertificateRepository> certificateRepository = new Mock<ICertificateRepository>();
                        certificateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Certificate()));

                        var validator = new ApiCertificateRequestModelValidator(certificateRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCertificateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<ICertificateRepository> certificateRepository = new Mock<ICertificateRepository>();
                        certificateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Certificate()));

                        var validator = new ApiCertificateRequestModelValidator(certificateRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Subject_Create_null()
                {
                        Mock<ICertificateRepository> certificateRepository = new Mock<ICertificateRepository>();
                        certificateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Certificate()));

                        var validator = new ApiCertificateRequestModelValidator(certificateRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCertificateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Subject, null as string);
                }

                [Fact]
                public async void Subject_Update_null()
                {
                        Mock<ICertificateRepository> certificateRepository = new Mock<ICertificateRepository>();
                        certificateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Certificate()));

                        var validator = new ApiCertificateRequestModelValidator(certificateRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCertificateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Subject, null as string);
                }

                [Fact]
                public async void Thumbprint_Create_null()
                {
                        Mock<ICertificateRepository> certificateRepository = new Mock<ICertificateRepository>();
                        certificateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Certificate()));

                        var validator = new ApiCertificateRequestModelValidator(certificateRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCertificateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Thumbprint, null as string);
                }

                [Fact]
                public async void Thumbprint_Update_null()
                {
                        Mock<ICertificateRepository> certificateRepository = new Mock<ICertificateRepository>();
                        certificateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Certificate()));

                        var validator = new ApiCertificateRequestModelValidator(certificateRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCertificateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Thumbprint, null as string);
                }

                [Fact]
                public async void Thumbprint_Create_length()
                {
                        Mock<ICertificateRepository> certificateRepository = new Mock<ICertificateRepository>();
                        certificateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Certificate()));

                        var validator = new ApiCertificateRequestModelValidator(certificateRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCertificateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Thumbprint, new string('A', 129));
                }

                [Fact]
                public async void Thumbprint_Update_length()
                {
                        Mock<ICertificateRepository> certificateRepository = new Mock<ICertificateRepository>();
                        certificateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Certificate()));

                        var validator = new ApiCertificateRequestModelValidator(certificateRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiCertificateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Thumbprint, new string('A', 129));
                }

                [Fact]
                public async void Thumbprint_Delete()
                {
                        Mock<ICertificateRepository> certificateRepository = new Mock<ICertificateRepository>();
                        certificateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Certificate()));

                        var validator = new ApiCertificateRequestModelValidator(certificateRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>393db83aa8c75c5026577132dd1b5fe3</Hash>
</Codenesium>*/