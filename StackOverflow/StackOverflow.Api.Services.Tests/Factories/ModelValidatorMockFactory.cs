using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services.Tests
{
	public class ModelValidatorMockFactory
	{
		public Mock<IApiBadgeRequestModelValidator> BadgeModelValidatorMock { get; set; } = new Mock<IApiBadgeRequestModelValidator>();

		public Mock<IApiCommentRequestModelValidator> CommentModelValidatorMock { get; set; } = new Mock<IApiCommentRequestModelValidator>();

		public Mock<IApiLinkTypeRequestModelValidator> LinkTypeModelValidatorMock { get; set; } = new Mock<IApiLinkTypeRequestModelValidator>();

		public Mock<IApiPostHistoryRequestModelValidator> PostHistoryModelValidatorMock { get; set; } = new Mock<IApiPostHistoryRequestModelValidator>();

		public Mock<IApiPostHistoryTypeRequestModelValidator> PostHistoryTypeModelValidatorMock { get; set; } = new Mock<IApiPostHistoryTypeRequestModelValidator>();

		public Mock<IApiPostLinkRequestModelValidator> PostLinkModelValidatorMock { get; set; } = new Mock<IApiPostLinkRequestModelValidator>();

		public Mock<IApiPostRequestModelValidator> PostModelValidatorMock { get; set; } = new Mock<IApiPostRequestModelValidator>();

		public Mock<IApiPostTypeRequestModelValidator> PostTypeModelValidatorMock { get; set; } = new Mock<IApiPostTypeRequestModelValidator>();

		public Mock<IApiTagRequestModelValidator> TagModelValidatorMock { get; set; } = new Mock<IApiTagRequestModelValidator>();

		public Mock<IApiUserRequestModelValidator> UserModelValidatorMock { get; set; } = new Mock<IApiUserRequestModelValidator>();

		public Mock<IApiVoteRequestModelValidator> VoteModelValidatorMock { get; set; } = new Mock<IApiVoteRequestModelValidator>();

		public Mock<IApiVoteTypeRequestModelValidator> VoteTypeModelValidatorMock { get; set; } = new Mock<IApiVoteTypeRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.BadgeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiBadgeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BadgeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBadgeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BadgeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CommentModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCommentRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CommentModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCommentRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CommentModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.LinkTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLinkTypeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkTypeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PostHistoryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostHistoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostHistoryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostHistoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostHistoryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PostHistoryTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostHistoryTypeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostHistoryTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostHistoryTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PostLinkModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostLinkRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostLinkModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostLinkRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostLinkModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PostModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PostTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostTypeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostTypeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TagModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTagRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TagModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTagRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TagModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.UserModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiUserRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UserModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUserRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UserModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.VoteModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVoteRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VoteModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVoteRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VoteModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.VoteTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVoteTypeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VoteTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVoteTypeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VoteTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>35901f5089eb737d27bd7698d77a1464</Hash>
</Codenesium>*/