using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LibraryVariableSet")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiLibraryVariableSetRequestModelValidatorTest
	{
		public ApiLibraryVariableSetRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void ContentType_Create_length()
		{
			Mock<ILibraryVariableSetRepository> libraryVariableSetRepository = new Mock<ILibraryVariableSetRepository>();
			libraryVariableSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new LibraryVariableSet()));

			var validator = new ApiLibraryVariableSetRequestModelValidator(libraryVariableSetRepository.Object);
			await validator.ValidateCreateAsync(new ApiLibraryVariableSetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ContentType, new string('A', 51));
		}

		[Fact]
		public async void ContentType_Update_length()
		{
			Mock<ILibraryVariableSetRepository> libraryVariableSetRepository = new Mock<ILibraryVariableSetRepository>();
			libraryVariableSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new LibraryVariableSet()));

			var validator = new ApiLibraryVariableSetRequestModelValidator(libraryVariableSetRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiLibraryVariableSetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ContentType, new string('A', 51));
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ILibraryVariableSetRepository> libraryVariableSetRepository = new Mock<ILibraryVariableSetRepository>();
			libraryVariableSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new LibraryVariableSet()));

			var validator = new ApiLibraryVariableSetRequestModelValidator(libraryVariableSetRepository.Object);
			await validator.ValidateCreateAsync(new ApiLibraryVariableSetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ILibraryVariableSetRepository> libraryVariableSetRepository = new Mock<ILibraryVariableSetRepository>();
			libraryVariableSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new LibraryVariableSet()));

			var validator = new ApiLibraryVariableSetRequestModelValidator(libraryVariableSetRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiLibraryVariableSetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
		}

		[Fact]
		public async void VariableSetId_Create_length()
		{
			Mock<ILibraryVariableSetRepository> libraryVariableSetRepository = new Mock<ILibraryVariableSetRepository>();
			libraryVariableSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new LibraryVariableSet()));

			var validator = new ApiLibraryVariableSetRequestModelValidator(libraryVariableSetRepository.Object);
			await validator.ValidateCreateAsync(new ApiLibraryVariableSetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.VariableSetId, new string('A', 151));
		}

		[Fact]
		public async void VariableSetId_Update_length()
		{
			Mock<ILibraryVariableSetRepository> libraryVariableSetRepository = new Mock<ILibraryVariableSetRepository>();
			libraryVariableSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new LibraryVariableSet()));

			var validator = new ApiLibraryVariableSetRequestModelValidator(libraryVariableSetRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiLibraryVariableSetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.VariableSetId, new string('A', 151));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<ILibraryVariableSetRepository> libraryVariableSetRepository = new Mock<ILibraryVariableSetRepository>();
			libraryVariableSetRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<LibraryVariableSet>(new LibraryVariableSet()));
			var validator = new ApiLibraryVariableSetRequestModelValidator(libraryVariableSetRepository.Object);

			await validator.ValidateCreateAsync(new ApiLibraryVariableSetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<ILibraryVariableSetRepository> libraryVariableSetRepository = new Mock<ILibraryVariableSetRepository>();
			libraryVariableSetRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<LibraryVariableSet>(null));
			var validator = new ApiLibraryVariableSetRequestModelValidator(libraryVariableSetRepository.Object);

			await validator.ValidateCreateAsync(new ApiLibraryVariableSetRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<ILibraryVariableSetRepository> libraryVariableSetRepository = new Mock<ILibraryVariableSetRepository>();
			libraryVariableSetRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<LibraryVariableSet>(new LibraryVariableSet()));
			var validator = new ApiLibraryVariableSetRequestModelValidator(libraryVariableSetRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiLibraryVariableSetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<ILibraryVariableSetRepository> libraryVariableSetRepository = new Mock<ILibraryVariableSetRepository>();
			libraryVariableSetRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<LibraryVariableSet>(null));
			var validator = new ApiLibraryVariableSetRequestModelValidator(libraryVariableSetRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiLibraryVariableSetRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>1028708d528c8dada00fee23c3c9080f</Hash>
</Codenesium>*/