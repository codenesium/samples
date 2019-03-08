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
	[Trait("Table", "LinkTypes")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiLinkTypesServerRequestModelValidatorTest
	{
		public ApiLinkTypesServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void RwType_Create_null()
		{
			Mock<ILinkTypesRepository> linkTypesRepository = new Mock<ILinkTypesRepository>();
			linkTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkTypes()));

			var validator = new ApiLinkTypesServerRequestModelValidator(linkTypesRepository.Object);
			await validator.ValidateCreateAsync(new ApiLinkTypesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RwType, null as string);
		}

		[Fact]
		public async void RwType_Update_null()
		{
			Mock<ILinkTypesRepository> linkTypesRepository = new Mock<ILinkTypesRepository>();
			linkTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkTypes()));

			var validator = new ApiLinkTypesServerRequestModelValidator(linkTypesRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLinkTypesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RwType, null as string);
		}

		[Fact]
		public async void RwType_Create_length()
		{
			Mock<ILinkTypesRepository> linkTypesRepository = new Mock<ILinkTypesRepository>();
			linkTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkTypes()));

			var validator = new ApiLinkTypesServerRequestModelValidator(linkTypesRepository.Object);
			await validator.ValidateCreateAsync(new ApiLinkTypesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RwType, new string('A', 51));
		}

		[Fact]
		public async void RwType_Update_length()
		{
			Mock<ILinkTypesRepository> linkTypesRepository = new Mock<ILinkTypesRepository>();
			linkTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkTypes()));

			var validator = new ApiLinkTypesServerRequestModelValidator(linkTypesRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLinkTypesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RwType, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>121c02096b6c494ce10694c44b02f90f</Hash>
</Codenesium>*/