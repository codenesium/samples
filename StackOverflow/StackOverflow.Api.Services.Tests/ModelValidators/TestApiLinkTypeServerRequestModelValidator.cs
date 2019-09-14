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
		public async void RwType_Create_null()
		{
			Mock<ILinkTypeRepository> linkTypeRepository = new Mock<ILinkTypeRepository>();
			linkTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkType()));

			var validator = new ApiLinkTypeServerRequestModelValidator(linkTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiLinkTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RwType, null as string);
		}

		[Fact]
		public async void RwType_Update_null()
		{
			Mock<ILinkTypeRepository> linkTypeRepository = new Mock<ILinkTypeRepository>();
			linkTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkType()));

			var validator = new ApiLinkTypeServerRequestModelValidator(linkTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLinkTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RwType, null as string);
		}

		[Fact]
		public async void RwType_Create_length()
		{
			Mock<ILinkTypeRepository> linkTypeRepository = new Mock<ILinkTypeRepository>();
			linkTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkType()));

			var validator = new ApiLinkTypeServerRequestModelValidator(linkTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiLinkTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RwType, new string('A', 51));
		}

		[Fact]
		public async void RwType_Update_length()
		{
			Mock<ILinkTypeRepository> linkTypeRepository = new Mock<ILinkTypeRepository>();
			linkTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkType()));

			var validator = new ApiLinkTypeServerRequestModelValidator(linkTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLinkTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RwType, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>156fabf6d6203012ce1bf2b45307941c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/