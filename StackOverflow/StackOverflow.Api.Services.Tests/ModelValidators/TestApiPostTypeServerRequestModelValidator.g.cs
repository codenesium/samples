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
	[Trait("Table", "PostType")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPostTypeServerRequestModelValidatorTest
	{
		public ApiPostTypeServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Type_Create_null()
		{
			Mock<IPostTypeRepository> postTypeRepository = new Mock<IPostTypeRepository>();
			postTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostType()));

			var validator = new ApiPostTypeServerRequestModelValidator(postTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, null as string);
		}

		[Fact]
		public async void Type_Update_null()
		{
			Mock<IPostTypeRepository> postTypeRepository = new Mock<IPostTypeRepository>();
			postTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostType()));

			var validator = new ApiPostTypeServerRequestModelValidator(postTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, null as string);
		}

		[Fact]
		public async void Type_Create_length()
		{
			Mock<IPostTypeRepository> postTypeRepository = new Mock<IPostTypeRepository>();
			postTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostType()));

			var validator = new ApiPostTypeServerRequestModelValidator(postTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
		}

		[Fact]
		public async void Type_Update_length()
		{
			Mock<IPostTypeRepository> postTypeRepository = new Mock<IPostTypeRepository>();
			postTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostType()));

			var validator = new ApiPostTypeServerRequestModelValidator(postTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>2a776190c98013cfa51608262462999c</Hash>
</Codenesium>*/