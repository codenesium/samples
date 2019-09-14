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
		public Mock<IApiDirectTweetServerRequestModelValidator> DirectTweetModelValidatorMock { get; set; } = new Mock<IApiDirectTweetServerRequestModelValidator>();

		public Mock<IApiFollowerServerRequestModelValidator> FollowerModelValidatorMock { get; set; } = new Mock<IApiFollowerServerRequestModelValidator>();

		public Mock<IApiFollowingServerRequestModelValidator> FollowingModelValidatorMock { get; set; } = new Mock<IApiFollowingServerRequestModelValidator>();

		public Mock<IApiLocationServerRequestModelValidator> LocationModelValidatorMock { get; set; } = new Mock<IApiLocationServerRequestModelValidator>();

		public Mock<IApiMessageServerRequestModelValidator> MessageModelValidatorMock { get; set; } = new Mock<IApiMessageServerRequestModelValidator>();

		public Mock<IApiMessengerServerRequestModelValidator> MessengerModelValidatorMock { get; set; } = new Mock<IApiMessengerServerRequestModelValidator>();

		public Mock<IApiQuoteTweetServerRequestModelValidator> QuoteTweetModelValidatorMock { get; set; } = new Mock<IApiQuoteTweetServerRequestModelValidator>();

		public Mock<IApiReplyServerRequestModelValidator> ReplyModelValidatorMock { get; set; } = new Mock<IApiReplyServerRequestModelValidator>();

		public Mock<IApiRetweetServerRequestModelValidator> RetweetModelValidatorMock { get; set; } = new Mock<IApiRetweetServerRequestModelValidator>();

		public Mock<IApiTweetServerRequestModelValidator> TweetModelValidatorMock { get; set; } = new Mock<IApiTweetServerRequestModelValidator>();

		public Mock<IApiUserServerRequestModelValidator> UserModelValidatorMock { get; set; } = new Mock<IApiUserServerRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.DirectTweetModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDirectTweetServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DirectTweetModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDirectTweetServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DirectTweetModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.FollowerModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiFollowerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.FollowerModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFollowerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.FollowerModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.FollowingModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiFollowingServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.FollowingModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFollowingServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.FollowingModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.LocationModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLocationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LocationModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLocationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LocationModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.MessageModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiMessageServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MessageModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMessageServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MessageModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.MessengerModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiMessengerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MessengerModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMessengerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MessengerModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.QuoteTweetModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiQuoteTweetServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.QuoteTweetModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiQuoteTweetServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.QuoteTweetModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ReplyModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiReplyServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ReplyModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiReplyServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ReplyModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.RetweetModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiRetweetServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.RetweetModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiRetweetServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.RetweetModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TweetModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTweetServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TweetModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTweetServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TweetModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.UserModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiUserServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UserModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUserServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UserModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>5943eb7d9df766146b8658861e0aa8f3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/