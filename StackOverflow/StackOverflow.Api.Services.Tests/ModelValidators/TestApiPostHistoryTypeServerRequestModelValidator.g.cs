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
		public async void RwType_Create_null()
		{
			Mock<IPostHistoryTypeRepository> postHistoryTypeRepository = new Mock<IPostHistoryTypeRepository>();
			postHistoryTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryType()));

			var validator = new ApiPostHistoryTypeServerRequestModelValidator(postHistoryTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostHistoryTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RwType, null as string);
		}

		[Fact]
		public async void RwType_Update_null()
		{
			Mock<IPostHistoryTypeRepository> postHistoryTypeRepository = new Mock<IPostHistoryTypeRepository>();
			postHistoryTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryType()));

			var validator = new ApiPostHistoryTypeServerRequestModelValidator(postHistoryTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RwType, null as string);
		}

		[Fact]
		public async void RwType_Create_length()
		{
			Mock<IPostHistoryTypeRepository> postHistoryTypeRepository = new Mock<IPostHistoryTypeRepository>();
			postHistoryTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryType()));

			var validator = new ApiPostHistoryTypeServerRequestModelValidator(postHistoryTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostHistoryTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RwType, new string('A', 51));
		}

		[Fact]
		public async void RwType_Update_length()
		{
			Mock<IPostHistoryTypeRepository> postHistoryTypeRepository = new Mock<IPostHistoryTypeRepository>();
			postHistoryTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryType()));

			var validator = new ApiPostHistoryTypeServerRequestModelValidator(postHistoryTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RwType, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>e7a64c936d8a460db65360248d720ae9</Hash>
</Codenesium>*/