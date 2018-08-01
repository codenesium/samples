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
	[Trait("Table", "Comments")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCommentsRequestModelValidatorTest
	{
		public ApiCommentsRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Text_Create_length()
		{
			Mock<ICommentsRepository> commentsRepository = new Mock<ICommentsRepository>();
			commentsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comments()));

			var validator = new ApiCommentsRequestModelValidator(commentsRepository.Object);
			await validator.ValidateCreateAsync(new ApiCommentsRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Text, new string('A', 701));
		}

		[Fact]
		public async void Text_Update_length()
		{
			Mock<ICommentsRepository> commentsRepository = new Mock<ICommentsRepository>();
			commentsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comments()));

			var validator = new ApiCommentsRequestModelValidator(commentsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCommentsRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Text, new string('A', 701));
		}
	}
}

/*<Codenesium>
    <Hash>54ebbeb74ea99444cd68700ae17410ae</Hash>
</Codenesium>*/