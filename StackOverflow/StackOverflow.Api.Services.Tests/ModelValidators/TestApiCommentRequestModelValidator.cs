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
	public partial class ApiCommentRequestModelValidatorTest
	{
		public ApiCommentRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Text_Create_null()
		{
			Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comment()));

			var validator = new ApiCommentRequestModelValidator(commentRepository.Object);
			await validator.ValidateCreateAsync(new ApiCommentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Text, null as string);
		}

		[Fact]
		public async void Text_Update_null()
		{
			Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comment()));

			var validator = new ApiCommentRequestModelValidator(commentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCommentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Text, null as string);
		}

		[Fact]
		public async void Text_Create_length()
		{
			Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comment()));

			var validator = new ApiCommentRequestModelValidator(commentRepository.Object);
			await validator.ValidateCreateAsync(new ApiCommentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Text, new string('A', 701));
		}

		[Fact]
		public async void Text_Update_length()
		{
			Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comment()));

			var validator = new ApiCommentRequestModelValidator(commentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCommentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Text, new string('A', 701));
		}
	}
}

/*<Codenesium>
    <Hash>6432995c4687a899e25980ac1bf8608b</Hash>
</Codenesium>*/