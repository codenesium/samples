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
	[Trait("Table", "PostHistoryTypes")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPostHistoryTypesServerRequestModelValidatorTest
	{
		public ApiPostHistoryTypesServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void RwType_Create_null()
		{
			Mock<IPostHistoryTypesRepository> postHistoryTypesRepository = new Mock<IPostHistoryTypesRepository>();
			postHistoryTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryTypes()));

			var validator = new ApiPostHistoryTypesServerRequestModelValidator(postHistoryTypesRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostHistoryTypesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RwType, null as string);
		}

		[Fact]
		public async void RwType_Update_null()
		{
			Mock<IPostHistoryTypesRepository> postHistoryTypesRepository = new Mock<IPostHistoryTypesRepository>();
			postHistoryTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryTypes()));

			var validator = new ApiPostHistoryTypesServerRequestModelValidator(postHistoryTypesRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryTypesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RwType, null as string);
		}

		[Fact]
		public async void RwType_Create_length()
		{
			Mock<IPostHistoryTypesRepository> postHistoryTypesRepository = new Mock<IPostHistoryTypesRepository>();
			postHistoryTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryTypes()));

			var validator = new ApiPostHistoryTypesServerRequestModelValidator(postHistoryTypesRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostHistoryTypesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RwType, new string('A', 51));
		}

		[Fact]
		public async void RwType_Update_length()
		{
			Mock<IPostHistoryTypesRepository> postHistoryTypesRepository = new Mock<IPostHistoryTypesRepository>();
			postHistoryTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryTypes()));

			var validator = new ApiPostHistoryTypesServerRequestModelValidator(postHistoryTypesRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryTypesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RwType, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>5a0a2331b5da9d3c4d2c0747aac90881</Hash>
</Codenesium>*/