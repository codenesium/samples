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
	[Trait("Table", "PostHistory")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPostHistoryRequestModelValidatorTest
	{
		public ApiPostHistoryRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void RevisionGUID_Create_length()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistory()));

			var validator = new ApiPostHistoryRequestModelValidator(postHistoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostHistoryRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RevisionGUID, new string('A', 37));
		}

		[Fact]
		public async void RevisionGUID_Update_length()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistory()));

			var validator = new ApiPostHistoryRequestModelValidator(postHistoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RevisionGUID, new string('A', 37));
		}

		[Fact]
		public async void UserDisplayName_Create_length()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistory()));

			var validator = new ApiPostHistoryRequestModelValidator(postHistoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostHistoryRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserDisplayName, new string('A', 41));
		}

		[Fact]
		public async void UserDisplayName_Update_length()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistory()));

			var validator = new ApiPostHistoryRequestModelValidator(postHistoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserDisplayName, new string('A', 41));
		}
	}
}

/*<Codenesium>
    <Hash>25476d7777bd909c9a217025d573a2a3</Hash>
</Codenesium>*/