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
	[Trait("Table", "Subscription")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSubscriptionServerRequestModelValidatorTest
	{
		public ApiSubscriptionServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
			subscriptionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Subscription()));

			var validator = new ApiSubscriptionServerRequestModelValidator(subscriptionRepository.Object);
			await validator.ValidateCreateAsync(new ApiSubscriptionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
			subscriptionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Subscription()));

			var validator = new ApiSubscriptionServerRequestModelValidator(subscriptionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSubscriptionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
			subscriptionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Subscription()));

			var validator = new ApiSubscriptionServerRequestModelValidator(subscriptionRepository.Object);
			await validator.ValidateCreateAsync(new ApiSubscriptionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
			subscriptionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Subscription()));

			var validator = new ApiSubscriptionServerRequestModelValidator(subscriptionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSubscriptionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void StripePlanName_Create_null()
		{
			Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
			subscriptionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Subscription()));

			var validator = new ApiSubscriptionServerRequestModelValidator(subscriptionRepository.Object);
			await validator.ValidateCreateAsync(new ApiSubscriptionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StripePlanName, null as string);
		}

		[Fact]
		public async void StripePlanName_Update_null()
		{
			Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
			subscriptionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Subscription()));

			var validator = new ApiSubscriptionServerRequestModelValidator(subscriptionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSubscriptionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StripePlanName, null as string);
		}

		[Fact]
		public async void StripePlanName_Create_length()
		{
			Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
			subscriptionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Subscription()));

			var validator = new ApiSubscriptionServerRequestModelValidator(subscriptionRepository.Object);
			await validator.ValidateCreateAsync(new ApiSubscriptionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StripePlanName, new string('A', 129));
		}

		[Fact]
		public async void StripePlanName_Update_length()
		{
			Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
			subscriptionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Subscription()));

			var validator = new ApiSubscriptionServerRequestModelValidator(subscriptionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSubscriptionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StripePlanName, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>0cd20700f58340d9a86b2803082b2bd6</Hash>
</Codenesium>*/