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
	public partial class ApiLinkTypeServerRequestModelValidatorTest
	{
		public ApiLinkTypeServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Type_Create_null()
		{
			Mock<ILinkTypeRepository> linkTypeRepository = new Mock<ILinkTypeRepository>();
			linkTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkType()));

			var validator = new ApiLinkTypeServerRequestModelValidator(linkTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiLinkTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, null as string);
		}

		[Fact]
		public async void Type_Update_null()
		{
			Mock<ILinkTypeRepository> linkTypeRepository = new Mock<ILinkTypeRepository>();
			linkTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkType()));

			var validator = new ApiLinkTypeServerRequestModelValidator(linkTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLinkTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, null as string);
		}

		[Fact]
		public async void Type_Create_length()
		{
			Mock<ILinkTypeRepository> linkTypeRepository = new Mock<ILinkTypeRepository>();
			linkTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkType()));

			var validator = new ApiLinkTypeServerRequestModelValidator(linkTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiLinkTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
		}

		[Fact]
		public async void Type_Update_length()
		{
			Mock<ILinkTypeRepository> linkTypeRepository = new Mock<ILinkTypeRepository>();
			linkTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkType()));

			var validator = new ApiLinkTypeServerRequestModelValidator(linkTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLinkTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>c5b24ced846542de1e6fed9cfea9377d</Hash>
</Codenesium>*/