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
	[Trait("Table", "LinkType")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiLinkTypeRequestModelValidatorTest
	{
		public ApiLinkTypeRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Type_Create_null()
		{
			Mock<ILinkTypeRepository> linkTypeRepository = new Mock<ILinkTypeRepository>();
			linkTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkType()));

			var validator = new ApiLinkTypeRequestModelValidator(linkTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiLinkTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, null as string);
		}

		[Fact]
		public async void Type_Update_null()
		{
			Mock<ILinkTypeRepository> linkTypeRepository = new Mock<ILinkTypeRepository>();
			linkTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkType()));

			var validator = new ApiLinkTypeRequestModelValidator(linkTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLinkTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, null as string);
		}

		[Fact]
		public async void Type_Create_length()
		{
			Mock<ILinkTypeRepository> linkTypeRepository = new Mock<ILinkTypeRepository>();
			linkTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkType()));

			var validator = new ApiLinkTypeRequestModelValidator(linkTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiLinkTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
		}

		[Fact]
		public async void Type_Update_length()
		{
			Mock<ILinkTypeRepository> linkTypeRepository = new Mock<ILinkTypeRepository>();
			linkTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkType()));

			var validator = new ApiLinkTypeRequestModelValidator(linkTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLinkTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>0164064684e99a7c1fc679bcac2d4dc0</Hash>
</Codenesium>*/