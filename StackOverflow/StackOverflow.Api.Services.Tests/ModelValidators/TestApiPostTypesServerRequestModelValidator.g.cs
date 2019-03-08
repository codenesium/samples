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
	[Trait("Table", "PostTypes")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPostTypesServerRequestModelValidatorTest
	{
		public ApiPostTypesServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void RwType_Create_null()
		{
			Mock<IPostTypesRepository> postTypesRepository = new Mock<IPostTypesRepository>();
			postTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostTypes()));

			var validator = new ApiPostTypesServerRequestModelValidator(postTypesRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostTypesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RwType, null as string);
		}

		[Fact]
		public async void RwType_Update_null()
		{
			Mock<IPostTypesRepository> postTypesRepository = new Mock<IPostTypesRepository>();
			postTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostTypes()));

			var validator = new ApiPostTypesServerRequestModelValidator(postTypesRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostTypesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RwType, null as string);
		}

		[Fact]
		public async void RwType_Create_length()
		{
			Mock<IPostTypesRepository> postTypesRepository = new Mock<IPostTypesRepository>();
			postTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostTypes()));

			var validator = new ApiPostTypesServerRequestModelValidator(postTypesRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostTypesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RwType, new string('A', 51));
		}

		[Fact]
		public async void RwType_Update_length()
		{
			Mock<IPostTypesRepository> postTypesRepository = new Mock<IPostTypesRepository>();
			postTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostTypes()));

			var validator = new ApiPostTypesServerRequestModelValidator(postTypesRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostTypesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RwType, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>a614b9c752357df3e66d14a84fcdc62d</Hash>
</Codenesium>*/