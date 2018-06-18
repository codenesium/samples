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
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "File")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiFileRequestModelValidatorTest
        {
                public ApiFileRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void BucketId_Create_Valid_Reference()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.GetBucket(It.IsAny<int>())).Returns(Task.FromResult<Bucket>(new Bucket()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateCreateAsync(new ApiFileRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.BucketId, 1);
                }

                [Fact]
                public async void BucketId_Create_Invalid_Reference()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.GetBucket(It.IsAny<int>())).Returns(Task.FromResult<Bucket>(null));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateCreateAsync(new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.BucketId, 1);
                }

                [Fact]
                public async void BucketId_Update_Valid_Reference()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.GetBucket(It.IsAny<int>())).Returns(Task.FromResult<Bucket>(new Bucket()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiFileRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.BucketId, 1);
                }

                [Fact]
                public async void BucketId_Update_Invalid_Reference()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.GetBucket(It.IsAny<int>())).Returns(Task.FromResult<Bucket>(null));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.BucketId, 1);
                }

                [Fact]
                public async void Description_Create_length()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateCreateAsync(new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 256));
                }

                [Fact]
                public async void Description_Update_length()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 256));
                }

                [Fact]
                public async void Description_Delete()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Extension_Create_null()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateCreateAsync(new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Extension, null as string);
                }

                [Fact]
                public async void Extension_Update_null()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Extension, null as string);
                }

                [Fact]
                public async void Extension_Create_length()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateCreateAsync(new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Extension, new string('A', 33));
                }

                [Fact]
                public async void Extension_Update_length()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Extension, new string('A', 33));
                }

                [Fact]
                public async void Extension_Delete()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void FileTypeId_Create_Valid_Reference()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.GetFileType(It.IsAny<int>())).Returns(Task.FromResult<FileType>(new FileType()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateCreateAsync(new ApiFileRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.FileTypeId, 1);
                }

                [Fact]
                public async void FileTypeId_Create_Invalid_Reference()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.GetFileType(It.IsAny<int>())).Returns(Task.FromResult<FileType>(null));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateCreateAsync(new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FileTypeId, 1);
                }

                [Fact]
                public async void FileTypeId_Update_Valid_Reference()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.GetFileType(It.IsAny<int>())).Returns(Task.FromResult<FileType>(new FileType()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiFileRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.FileTypeId, 1);
                }

                [Fact]
                public async void FileTypeId_Update_Invalid_Reference()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.GetFileType(It.IsAny<int>())).Returns(Task.FromResult<FileType>(null));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.FileTypeId, 1);
                }

                [Fact]
                public async void Location_Create_null()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateCreateAsync(new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Location, null as string);
                }

                [Fact]
                public async void Location_Update_null()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Location, null as string);
                }

                [Fact]
                public async void Location_Create_length()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateCreateAsync(new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Location, new string('A', 256));
                }

                [Fact]
                public async void Location_Update_length()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Location, new string('A', 256));
                }

                [Fact]
                public async void Location_Delete()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void PrivateKey_Create_null()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateCreateAsync(new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PrivateKey, null as string);
                }

                [Fact]
                public async void PrivateKey_Update_null()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PrivateKey, null as string);
                }

                [Fact]
                public async void PrivateKey_Create_length()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateCreateAsync(new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PrivateKey, new string('A', 65));
                }

                [Fact]
                public async void PrivateKey_Update_length()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PrivateKey, new string('A', 65));
                }

                [Fact]
                public async void PrivateKey_Delete()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void PublicKey_Create_null()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateCreateAsync(new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PublicKey, null as string);
                }

                [Fact]
                public async void PublicKey_Update_null()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PublicKey, null as string);
                }

                [Fact]
                public async void PublicKey_Create_length()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateCreateAsync(new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PublicKey, new string('A', 65));
                }

                [Fact]
                public async void PublicKey_Update_length()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiFileRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PublicKey, new string('A', 65));
                }

                [Fact]
                public async void PublicKey_Delete()
                {
                        Mock<IFileRepository> fileRepository = new Mock<IFileRepository>();
                        fileRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));

                        var validator = new ApiFileRequestModelValidator(fileRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>024904c9457941d6c6bb5baadae7e176</Hash>
</Codenesium>*/