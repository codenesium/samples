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
			await validator.ValidateUpdateAsync(default(Guid), new ApiDocumentRequestModel());

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
			await validator.ValidateUpdateAsync(default(Guid), new ApiDocumentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FileExtension, new string('A', 9));
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
			await validator.ValidateUpdateAsync(default(Guid), new ApiDocumentRequestModel());

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
			await validator.ValidateUpdateAsync(default(Guid), new ApiDocumentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FileName, new string('A', 401));
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
			await validator.ValidateUpdateAsync(default(Guid), new ApiDocumentRequestModel());

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
			await validator.ValidateUpdateAsync(default(Guid), new ApiDocumentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Revision, new string('A', 6));
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
			await validator.ValidateUpdateAsync(default(Guid), new ApiDocumentRequestModel());

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
			await validator.ValidateUpdateAsync(default(Guid), new ApiDocumentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Title, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>3d1b843cadc0724bd624a70ac59ca2a5</Hash>
</Codenesium>*/