using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkStatu")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiLinkStatuRequestModelValidatorTest
	{
		public ApiLinkStatuRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ILinkStatuRepository> linkStatuRepository = new Mock<ILinkStatuRepository>();
			linkStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkStatu()));

			var validator = new ApiLinkStatuRequestModelValidator(linkStatuRepository.Object);
			await validator.ValidateCreateAsync(new ApiLinkStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ILinkStatuRepository> linkStatuRepository = new Mock<ILinkStatuRepository>();
			linkStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkStatu()));

			var validator = new ApiLinkStatuRequestModelValidator(linkStatuRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLinkStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ILinkStatuRepository> linkStatuRepository = new Mock<ILinkStatuRepository>();
			linkStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkStatu()));

			var validator = new ApiLinkStatuRequestModelValidator(linkStatuRepository.Object);
			await validator.ValidateCreateAsync(new ApiLinkStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ILinkStatuRepository> linkStatuRepository = new Mock<ILinkStatuRepository>();
			linkStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkStatu()));

			var validator = new ApiLinkStatuRequestModelValidator(linkStatuRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLinkStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<ILinkStatuRepository> linkStatuRepository = new Mock<ILinkStatuRepository>();
			linkStatuRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<LinkStatu>(new LinkStatu()));
			var validator = new ApiLinkStatuRequestModelValidator(linkStatuRepository.Object);

			await validator.ValidateCreateAsync(new ApiLinkStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<ILinkStatuRepository> linkStatuRepository = new Mock<ILinkStatuRepository>();
			linkStatuRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<LinkStatu>(null));
			var validator = new ApiLinkStatuRequestModelValidator(linkStatuRepository.Object);

			await validator.ValidateCreateAsync(new ApiLinkStatuRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<ILinkStatuRepository> linkStatuRepository = new Mock<ILinkStatuRepository>();
			linkStatuRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<LinkStatu>(new LinkStatu()));
			var validator = new ApiLinkStatuRequestModelValidator(linkStatuRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiLinkStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<ILinkStatuRepository> linkStatuRepository = new Mock<ILinkStatuRepository>();
			linkStatuRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<LinkStatu>(null));
			var validator = new ApiLinkStatuRequestModelValidator(linkStatuRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiLinkStatuRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>11fa2eb327aedc420f3eac9ddd78be33</Hash>
</Codenesium>*/