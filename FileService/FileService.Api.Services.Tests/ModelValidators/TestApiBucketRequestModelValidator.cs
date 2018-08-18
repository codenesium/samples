using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FileServiceNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Bucket")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiBucketRequestModelValidatorTest
	{
		public ApiBucketRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IBucketRepository> bucketRepository = new Mock<IBucketRepository>();
			bucketRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Bucket()));

			var validator = new ApiBucketRequestModelValidator(bucketRepository.Object);
			await validator.ValidateCreateAsync(new ApiBucketRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 256));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IBucketRepository> bucketRepository = new Mock<IBucketRepository>();
			bucketRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Bucket()));

			var validator = new ApiBucketRequestModelValidator(bucketRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiBucketRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 256));
		}

		[Fact]
		private async void BeUniqueByExternalId_Create_Exists()
		{
			Mock<IBucketRepository> bucketRepository = new Mock<IBucketRepository>();
			bucketRepository.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<Bucket>(new Bucket()));
			var validator = new ApiBucketRequestModelValidator(bucketRepository.Object);

			await validator.ValidateCreateAsync(new ApiBucketRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByExternalId_Create_Not_Exists()
		{
			Mock<IBucketRepository> bucketRepository = new Mock<IBucketRepository>();
			bucketRepository.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<Bucket>(null));
			var validator = new ApiBucketRequestModelValidator(bucketRepository.Object);

			await validator.ValidateCreateAsync(new ApiBucketRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByExternalId_Update_Exists()
		{
			Mock<IBucketRepository> bucketRepository = new Mock<IBucketRepository>();
			bucketRepository.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<Bucket>(new Bucket()));
			var validator = new ApiBucketRequestModelValidator(bucketRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiBucketRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByExternalId_Update_Not_Exists()
		{
			Mock<IBucketRepository> bucketRepository = new Mock<IBucketRepository>();
			bucketRepository.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<Bucket>(null));
			var validator = new ApiBucketRequestModelValidator(bucketRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiBucketRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>1da8c20605a1e9eab1e23c8e8163d318</Hash>
</Codenesium>*/