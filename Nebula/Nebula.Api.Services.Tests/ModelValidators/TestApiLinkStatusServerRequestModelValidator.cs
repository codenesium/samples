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
	[Trait("Table", "LinkStatus")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiLinkStatusServerRequestModelValidatorTest
	{
		public ApiLinkStatusServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ILinkStatusRepository> linkStatusRepository = new Mock<ILinkStatusRepository>();
			linkStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkStatus()));

			var validator = new ApiLinkStatusServerRequestModelValidator(linkStatusRepository.Object);
			await validator.ValidateCreateAsync(new ApiLinkStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ILinkStatusRepository> linkStatusRepository = new Mock<ILinkStatusRepository>();
			linkStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkStatus()));

			var validator = new ApiLinkStatusServerRequestModelValidator(linkStatusRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLinkStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ILinkStatusRepository> linkStatusRepository = new Mock<ILinkStatusRepository>();
			linkStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkStatus()));

			var validator = new ApiLinkStatusServerRequestModelValidator(linkStatusRepository.Object);
			await validator.ValidateCreateAsync(new ApiLinkStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ILinkStatusRepository> linkStatusRepository = new Mock<ILinkStatusRepository>();
			linkStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkStatus()));

			var validator = new ApiLinkStatusServerRequestModelValidator(linkStatusRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLinkStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<ILinkStatusRepository> linkStatusRepository = new Mock<ILinkStatusRepository>();
			linkStatusRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<LinkStatus>(new LinkStatus()));
			var validator = new ApiLinkStatusServerRequestModelValidator(linkStatusRepository.Object);

			await validator.ValidateCreateAsync(new ApiLinkStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<ILinkStatusRepository> linkStatusRepository = new Mock<ILinkStatusRepository>();
			linkStatusRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<LinkStatus>(null));
			var validator = new ApiLinkStatusServerRequestModelValidator(linkStatusRepository.Object);

			await validator.ValidateCreateAsync(new ApiLinkStatusServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<ILinkStatusRepository> linkStatusRepository = new Mock<ILinkStatusRepository>();
			linkStatusRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<LinkStatus>(new LinkStatus()));
			var validator = new ApiLinkStatusServerRequestModelValidator(linkStatusRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiLinkStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<ILinkStatusRepository> linkStatusRepository = new Mock<ILinkStatusRepository>();
			linkStatusRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<LinkStatus>(null));
			var validator = new ApiLinkStatusServerRequestModelValidator(linkStatusRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiLinkStatusServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>2bc39b59e45c7924f058a4075447ba6d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/