using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SecureVideoCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Video")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVideoServerRequestModelValidatorTest
	{
		public ApiVideoServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Description_Create_null()
		{
			Mock<IVideoRepository> videoRepository = new Mock<IVideoRepository>();
			videoRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Video()));

			var validator = new ApiVideoServerRequestModelValidator(videoRepository.Object);
			await validator.ValidateCreateAsync(new ApiVideoServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Description_Update_null()
		{
			Mock<IVideoRepository> videoRepository = new Mock<IVideoRepository>();
			videoRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Video()));

			var validator = new ApiVideoServerRequestModelValidator(videoRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVideoServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Description_Create_length()
		{
			Mock<IVideoRepository> videoRepository = new Mock<IVideoRepository>();
			videoRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Video()));

			var validator = new ApiVideoServerRequestModelValidator(videoRepository.Object);
			await validator.ValidateCreateAsync(new ApiVideoServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 4001));
		}

		[Fact]
		public async void Description_Update_length()
		{
			Mock<IVideoRepository> videoRepository = new Mock<IVideoRepository>();
			videoRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Video()));

			var validator = new ApiVideoServerRequestModelValidator(videoRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVideoServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 4001));
		}

		[Fact]
		public async void Title_Create_null()
		{
			Mock<IVideoRepository> videoRepository = new Mock<IVideoRepository>();
			videoRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Video()));

			var validator = new ApiVideoServerRequestModelValidator(videoRepository.Object);
			await validator.ValidateCreateAsync(new ApiVideoServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Title, null as string);
		}

		[Fact]
		public async void Title_Update_null()
		{
			Mock<IVideoRepository> videoRepository = new Mock<IVideoRepository>();
			videoRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Video()));

			var validator = new ApiVideoServerRequestModelValidator(videoRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVideoServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Title, null as string);
		}

		[Fact]
		public async void Title_Create_length()
		{
			Mock<IVideoRepository> videoRepository = new Mock<IVideoRepository>();
			videoRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Video()));

			var validator = new ApiVideoServerRequestModelValidator(videoRepository.Object);
			await validator.ValidateCreateAsync(new ApiVideoServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Title, new string('A', 129));
		}

		[Fact]
		public async void Title_Update_length()
		{
			Mock<IVideoRepository> videoRepository = new Mock<IVideoRepository>();
			videoRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Video()));

			var validator = new ApiVideoServerRequestModelValidator(videoRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVideoServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Title, new string('A', 129));
		}

		[Fact]
		public async void Url_Create_null()
		{
			Mock<IVideoRepository> videoRepository = new Mock<IVideoRepository>();
			videoRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Video()));

			var validator = new ApiVideoServerRequestModelValidator(videoRepository.Object);
			await validator.ValidateCreateAsync(new ApiVideoServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Url, null as string);
		}

		[Fact]
		public async void Url_Update_null()
		{
			Mock<IVideoRepository> videoRepository = new Mock<IVideoRepository>();
			videoRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Video()));

			var validator = new ApiVideoServerRequestModelValidator(videoRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVideoServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Url, null as string);
		}

		[Fact]
		public async void Url_Create_length()
		{
			Mock<IVideoRepository> videoRepository = new Mock<IVideoRepository>();
			videoRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Video()));

			var validator = new ApiVideoServerRequestModelValidator(videoRepository.Object);
			await validator.ValidateCreateAsync(new ApiVideoServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Url, new string('A', 129));
		}

		[Fact]
		public async void Url_Update_length()
		{
			Mock<IVideoRepository> videoRepository = new Mock<IVideoRepository>();
			videoRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Video()));

			var validator = new ApiVideoServerRequestModelValidator(videoRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVideoServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Url, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>e1de997e56e130cc859726923a905f20</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/