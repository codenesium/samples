using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Space")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSpaceRequestModelValidatorTest
	{
		public ApiSpaceRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Description_Create_null()
		{
			Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
			spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

			var validator = new ApiSpaceRequestModelValidator(spaceRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpaceRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Description_Update_null()
		{
			Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
			spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

			var validator = new ApiSpaceRequestModelValidator(spaceRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpaceRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Description_Create_length()
		{
			Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
			spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

			var validator = new ApiSpaceRequestModelValidator(spaceRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpaceRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 129));
		}

		[Fact]
		public async void Description_Update_length()
		{
			Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
			spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

			var validator = new ApiSpaceRequestModelValidator(spaceRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpaceRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 129));
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
			spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

			var validator = new ApiSpaceRequestModelValidator(spaceRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpaceRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
			spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

			var validator = new ApiSpaceRequestModelValidator(spaceRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpaceRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
			spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

			var validator = new ApiSpaceRequestModelValidator(spaceRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpaceRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
			spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

			var validator = new ApiSpaceRequestModelValidator(spaceRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpaceRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>dffd6efd7a0d70a5dfc7ba117f3547b7</Hash>
</Codenesium>*/