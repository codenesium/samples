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
	[Trait("Table", "PostHistoryType")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPostHistoryTypeServerRequestModelValidatorTest
	{
		public ApiPostHistoryTypeServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Type_Create_null()
		{
			Mock<IPostHistoryTypeRepository> postHistoryTypeRepository = new Mock<IPostHistoryTypeRepository>();
			postHistoryTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryType()));

			var validator = new ApiPostHistoryTypeServerRequestModelValidator(postHistoryTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostHistoryTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, null as string);
		}

		[Fact]
		public async void Type_Update_null()
		{
			Mock<IPostHistoryTypeRepository> postHistoryTypeRepository = new Mock<IPostHistoryTypeRepository>();
			postHistoryTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryType()));

			var validator = new ApiPostHistoryTypeServerRequestModelValidator(postHistoryTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, null as string);
		}

		[Fact]
		public async void Type_Create_length()
		{
			Mock<IPostHistoryTypeRepository> postHistoryTypeRepository = new Mock<IPostHistoryTypeRepository>();
			postHistoryTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryType()));

			var validator = new ApiPostHistoryTypeServerRequestModelValidator(postHistoryTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostHistoryTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
		}

		[Fact]
		public async void Type_Update_length()
		{
			Mock<IPostHistoryTypeRepository> postHistoryTypeRepository = new Mock<IPostHistoryTypeRepository>();
			postHistoryTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryType()));

			var validator = new ApiPostHistoryTypeServerRequestModelValidator(postHistoryTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>c2f09955aa78d3a0112ae7c17ef2b02e</Hash>
</Codenesium>*/