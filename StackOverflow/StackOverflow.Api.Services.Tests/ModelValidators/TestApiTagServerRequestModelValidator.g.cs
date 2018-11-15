using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tag")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTagServerRequestModelValidatorTest
	{
		public ApiTagServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void TagName_Create_null()
		{
			Mock<ITagRepository> tagRepository = new Mock<ITagRepository>();
			tagRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tag()));

			var validator = new ApiTagServerRequestModelValidator(tagRepository.Object);
			await validator.ValidateCreateAsync(new ApiTagServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TagName, null as string);
		}

		[Fact]
		public async void TagName_Update_null()
		{
			Mock<ITagRepository> tagRepository = new Mock<ITagRepository>();
			tagRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tag()));

			var validator = new ApiTagServerRequestModelValidator(tagRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTagServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TagName, null as string);
		}

		[Fact]
		public async void TagName_Create_length()
		{
			Mock<ITagRepository> tagRepository = new Mock<ITagRepository>();
			tagRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tag()));

			var validator = new ApiTagServerRequestModelValidator(tagRepository.Object);
			await validator.ValidateCreateAsync(new ApiTagServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TagName, new string('A', 151));
		}

		[Fact]
		public async void TagName_Update_length()
		{
			Mock<ITagRepository> tagRepository = new Mock<ITagRepository>();
			tagRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tag()));

			var validator = new ApiTagServerRequestModelValidator(tagRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTagServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TagName, new string('A', 151));
		}
	}
}

/*<Codenesium>
    <Hash>bcac4a1681a520ace2b13990dacd97db</Hash>
</Codenesium>*/