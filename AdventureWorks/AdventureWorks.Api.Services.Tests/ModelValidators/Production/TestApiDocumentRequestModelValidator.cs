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
        [Trait("Table", "Document")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiDocumentRequestModelValidatorTest
        {
                public ApiDocumentRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void FileExtension_Create_null()
                {
                        Mock<IDocumentRepository> documentRepository = new Mock<IDocumentRepository>();
                        documentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Document()));

                        var validator = new ApiDocumentRequestModelValidator(documentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FileExtension, null as string);
                }

                [Fact]
                public async void FileExtension_Update_null()
                {
                        Mock<IDocumentRepository> documentRepository = new Mock<IDocumentRepository>();
                        documentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Document()));

                        var validator = new ApiDocumentRequestModelValidator(documentRepository.Object);

                        await validator.ValidateUpdateAsync(default (Guid), new ApiDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FileExtension, null as string);
                }

                [Fact]
                public async void FileExtension_Create_length()
                {
                        Mock<IDocumentRepository> documentRepository = new Mock<IDocumentRepository>();
                        documentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Document()));

                        var validator = new ApiDocumentRequestModelValidator(documentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FileExtension, new string('A', 9));
                }

                [Fact]
                public async void FileExtension_Update_length()
                {
                        Mock<IDocumentRepository> documentRepository = new Mock<IDocumentRepository>();
                        documentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Document()));

                        var validator = new ApiDocumentRequestModelValidator(documentRepository.Object);

                        await validator.ValidateUpdateAsync(default (Guid), new ApiDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FileExtension, new string('A', 9));
                }

                [Fact]
                public async void FileExtension_Delete()
                {
                        Mock<IDocumentRepository> documentRepository = new Mock<IDocumentRepository>();
                        documentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Document()));

                        var validator = new ApiDocumentRequestModelValidator(documentRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (Guid));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void FileName_Create_null()
                {
                        Mock<IDocumentRepository> documentRepository = new Mock<IDocumentRepository>();
                        documentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Document()));

                        var validator = new ApiDocumentRequestModelValidator(documentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FileName, null as string);
                }

                [Fact]
                public async void FileName_Update_null()
                {
                        Mock<IDocumentRepository> documentRepository = new Mock<IDocumentRepository>();
                        documentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Document()));

                        var validator = new ApiDocumentRequestModelValidator(documentRepository.Object);

                        await validator.ValidateUpdateAsync(default (Guid), new ApiDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FileName, null as string);
                }

                [Fact]
                public async void FileName_Create_length()
                {
                        Mock<IDocumentRepository> documentRepository = new Mock<IDocumentRepository>();
                        documentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Document()));

                        var validator = new ApiDocumentRequestModelValidator(documentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FileName, new string('A', 401));
                }

                [Fact]
                public async void FileName_Update_length()
                {
                        Mock<IDocumentRepository> documentRepository = new Mock<IDocumentRepository>();
                        documentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Document()));

                        var validator = new ApiDocumentRequestModelValidator(documentRepository.Object);

                        await validator.ValidateUpdateAsync(default (Guid), new ApiDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FileName, new string('A', 401));
                }

                [Fact]
                public async void FileName_Delete()
                {
                        Mock<IDocumentRepository> documentRepository = new Mock<IDocumentRepository>();
                        documentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Document()));

                        var validator = new ApiDocumentRequestModelValidator(documentRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (Guid));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Revision_Create_null()
                {
                        Mock<IDocumentRepository> documentRepository = new Mock<IDocumentRepository>();
                        documentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Document()));

                        var validator = new ApiDocumentRequestModelValidator(documentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Revision, null as string);
                }

                [Fact]
                public async void Revision_Update_null()
                {
                        Mock<IDocumentRepository> documentRepository = new Mock<IDocumentRepository>();
                        documentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Document()));

                        var validator = new ApiDocumentRequestModelValidator(documentRepository.Object);

                        await validator.ValidateUpdateAsync(default (Guid), new ApiDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Revision, null as string);
                }

                [Fact]
                public async void Revision_Create_length()
                {
                        Mock<IDocumentRepository> documentRepository = new Mock<IDocumentRepository>();
                        documentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Document()));

                        var validator = new ApiDocumentRequestModelValidator(documentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Revision, new string('A', 6));
                }

                [Fact]
                public async void Revision_Update_length()
                {
                        Mock<IDocumentRepository> documentRepository = new Mock<IDocumentRepository>();
                        documentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Document()));

                        var validator = new ApiDocumentRequestModelValidator(documentRepository.Object);

                        await validator.ValidateUpdateAsync(default (Guid), new ApiDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Revision, new string('A', 6));
                }

                [Fact]
                public async void Revision_Delete()
                {
                        Mock<IDocumentRepository> documentRepository = new Mock<IDocumentRepository>();
                        documentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Document()));

                        var validator = new ApiDocumentRequestModelValidator(documentRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (Guid));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Title_Create_null()
                {
                        Mock<IDocumentRepository> documentRepository = new Mock<IDocumentRepository>();
                        documentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Document()));

                        var validator = new ApiDocumentRequestModelValidator(documentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Title, null as string);
                }

                [Fact]
                public async void Title_Update_null()
                {
                        Mock<IDocumentRepository> documentRepository = new Mock<IDocumentRepository>();
                        documentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Document()));

                        var validator = new ApiDocumentRequestModelValidator(documentRepository.Object);

                        await validator.ValidateUpdateAsync(default (Guid), new ApiDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Title, null as string);
                }

                [Fact]
                public async void Title_Create_length()
                {
                        Mock<IDocumentRepository> documentRepository = new Mock<IDocumentRepository>();
                        documentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Document()));

                        var validator = new ApiDocumentRequestModelValidator(documentRepository.Object);

                        await validator.ValidateCreateAsync(new ApiDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Title, new string('A', 51));
                }

                [Fact]
                public async void Title_Update_length()
                {
                        Mock<IDocumentRepository> documentRepository = new Mock<IDocumentRepository>();
                        documentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Document()));

                        var validator = new ApiDocumentRequestModelValidator(documentRepository.Object);

                        await validator.ValidateUpdateAsync(default (Guid), new ApiDocumentRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Title, new string('A', 51));
                }

                [Fact]
                public async void Title_Delete()
                {
                        Mock<IDocumentRepository> documentRepository = new Mock<IDocumentRepository>();
                        documentRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Document()));

                        var validator = new ApiDocumentRequestModelValidator(documentRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (Guid));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>ae616e0df71c561322b44927f4eb217c</Hash>
</Codenesium>*/