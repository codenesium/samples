using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.Services;

namespace TwitterNS.Api.Services.Tests
{
	public class ModelValidatorMockFactory
	{
		public Mock<IApiDirectTweetRequestModelValidator> DirectTweetModelValidatorMock { get; set; } = new Mock<IApiDirectTweetRequestModelValidator>();

		public Mock<IApiFollowingRequestModelValidator> FollowingModelValidatorMock { get; set; } = new Mock<IApiFollowingRequestModelValidator>();

		public Mock<IApiLikeRequestModelValidator> LikeModelValidatorMock { get; set; } = new Mock<IApiLikeRequestModelValidator>();

		public Mock<IApiLocationRequestModelValidator> LocationModelValidatorMock { get; set; } = new Mock<IApiLocationRequestModelValidator>();

		public Mock<IApiMessageRequestModelValidator> MessageModelValidatorMock { get; set; } = new Mock<IApiMessageRequestModelValidator>();

		public Mock<IApiMessengerRequestModelValidator> MessengerModelValidatorMock { get; set; } = new Mock<IApiMessengerRequestModelValidator>();

		public Mock<IApiQuoteTweetRequestModelValidator> QuoteTweetModelValidatorMock { get; set; } = new Mock<IApiQuoteTweetRequestModelValidator>();

		public Mock<IApiReplyRequestModelValidator> ReplyModelValidatorMock { get; set; } = new Mock<IApiReplyRequestModelValidator>();

		public Mock<IApiRetweetRequestModelValidator> RetweetModelValidatorMock { get; set; } = new Mock<IApiRetweetRequestModelValidator>();

		public Mock<IApiTweetRequestModelValidator> TweetModelValidatorMock { get; set; } = new Mock<IApiTweetRequestModelValidator>();

		public Mock<IApiUserRequestModelValidator> UserModelValidatorMock { get; set; } = new Mock<IApiUserRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.DirectTweetModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDirectTweetRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DirectTweetModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDirectTweetRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DirectTweetModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.FollowingModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiFollowingRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.FollowingModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiFollowingRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.FollowingModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.LikeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLikeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LikeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLikeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LikeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.LocationModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLocationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LocationModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLocationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LocationModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.MessageModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiMessageRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MessageModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMessageRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MessageModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.MessengerModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiMessengerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MessengerModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMessengerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MessengerModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.QuoteTweetModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiQuoteTweetRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.QuoteTweetModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiQuoteTweetRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.QuoteTweetModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ReplyModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiReplyRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ReplyModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiReplyRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ReplyModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.RetweetModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiRetweetRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.RetweetModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiRetweetRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.RetweetModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TweetModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTweetRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TweetModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTweetRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TweetModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.UserModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiUserRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UserModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUserRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UserModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>fa2a7a0ec5af704f4ecdbbce02df9352</Hash>
</Codenesium>*/