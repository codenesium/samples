using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
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

namespace FileServiceNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "FileType")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiFileTypeServerRequestModelValidatorTest
	{
		public ApiFileTypeServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IFileTypeRepository> fileTypeRepository = new Mock<IFileTypeRepository>();
			fileTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new FileType()));

			var validator = new ApiFileTypeServerRequestModelValidator(fileTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiFileTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IFileTypeRepository> fileTypeRepository = new Mock<IFileTypeRepository>();
			fileTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new FileType()));

			var validator = new ApiFileTypeServerRequestModelValidator(fileTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFileTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IFileTypeRepository> fileTypeRepository = new Mock<IFileTypeRepository>();
			fileTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new FileType()));

			var validator = new ApiFileTypeServerRequestModelValidator(fileTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiFileTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 256));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IFileTypeRepository> fileTypeRepository = new Mock<IFileTypeRepository>();
			fileTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new FileType()));

			var validator = new ApiFileTypeServerRequestModelValidator(fileTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFileTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 256));
		}
	}
}

/*<Codenesium>
    <Hash>20c00403eee71326bbddec6e1880ac3b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/