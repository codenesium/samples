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
	[Trait("Table", "Comment")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCommentServerRequestModelValidatorTest
	{
		public ApiCommentServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Text_Create_null()
		{
			Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comment()));

			var validator = new ApiCommentServerRequestModelValidator(commentRepository.Object);
			await validator.ValidateCreateAsync(new ApiCommentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Text, null as string);
		}

		[Fact]
		public async void Text_Update_null()
		{
			Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comment()));

			var validator = new ApiCommentServerRequestModelValidator(commentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCommentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Text, null as string);
		}

		[Fact]
		public async void Text_Create_length()
		{
			Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comment()));

			var validator = new ApiCommentServerRequestModelValidator(commentRepository.Object);
			await validator.ValidateCreateAsync(new ApiCommentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Text, new string('A', 701));
		}

		[Fact]
		public async void Text_Update_length()
		{
			Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comment()));

			var validator = new ApiCommentServerRequestModelValidator(commentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCommentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Text, new string('A', 701));
		}
	}
}

/*<Codenesium>
    <Hash>62a2a9fc6178e9f7c1e979baa61f0e8a</Hash>
</Codenesium>*/