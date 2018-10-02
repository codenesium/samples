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
	[Trait("Table", "VoteType")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVoteTypeRequestModelValidatorTest
	{
		public ApiVoteTypeRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IVoteTypeRepository> voteTypeRepository = new Mock<IVoteTypeRepository>();
			voteTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VoteType()));

			var validator = new ApiVoteTypeRequestModelValidator(voteTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiVoteTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IVoteTypeRepository> voteTypeRepository = new Mock<IVoteTypeRepository>();
			voteTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VoteType()));

			var validator = new ApiVoteTypeRequestModelValidator(voteTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVoteTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IVoteTypeRepository> voteTypeRepository = new Mock<IVoteTypeRepository>();
			voteTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VoteType()));

			var validator = new ApiVoteTypeRequestModelValidator(voteTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiVoteTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IVoteTypeRepository> voteTypeRepository = new Mock<IVoteTypeRepository>();
			voteTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VoteType()));

			var validator = new ApiVoteTypeRequestModelValidator(voteTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVoteTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>b3376c82d6b5126c62507042dc0515cf</Hash>
</Codenesium>*/