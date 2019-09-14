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
	public partial class ApiSpaceServerRequestModelValidatorTest
	{
		public ApiSpaceServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Description_Create_null()
		{
			Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
			spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

			var validator = new ApiSpaceServerRequestModelValidator(spaceRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpaceServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Description_Update_null()
		{
			Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
			spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

			var validator = new ApiSpaceServerRequestModelValidator(spaceRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpaceServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Description_Create_length()
		{
			Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
			spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

			var validator = new ApiSpaceServerRequestModelValidator(spaceRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpaceServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 129));
		}

		[Fact]
		public async void Description_Update_length()
		{
			Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
			spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

			var validator = new ApiSpaceServerRequestModelValidator(spaceRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpaceServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 129));
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
			spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

			var validator = new ApiSpaceServerRequestModelValidator(spaceRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpaceServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
			spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

			var validator = new ApiSpaceServerRequestModelValidator(spaceRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpaceServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
			spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

			var validator = new ApiSpaceServerRequestModelValidator(spaceRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpaceServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ISpaceRepository> spaceRepository = new Mock<ISpaceRepository>();
			spaceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));

			var validator = new ApiSpaceServerRequestModelValidator(spaceRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpaceServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>72c599f8d21a9f83c86b68168daecf39</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/