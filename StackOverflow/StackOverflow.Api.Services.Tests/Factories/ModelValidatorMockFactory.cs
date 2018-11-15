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
		public Mock<IApiBadgeServerRequestModelValidator> BadgeModelValidatorMock { get; set; } = new Mock<IApiBadgeServerRequestModelValidator>();

		public Mock<IApiCommentServerRequestModelValidator> CommentModelValidatorMock { get; set; } = new Mock<IApiCommentServerRequestModelValidator>();

		public Mock<IApiLinkTypeServerRequestModelValidator> LinkTypeModelValidatorMock { get; set; } = new Mock<IApiLinkTypeServerRequestModelValidator>();

		public Mock<IApiPostHistoryServerRequestModelValidator> PostHistoryModelValidatorMock { get; set; } = new Mock<IApiPostHistoryServerRequestModelValidator>();

		public Mock<IApiPostHistoryTypeServerRequestModelValidator> PostHistoryTypeModelValidatorMock { get; set; } = new Mock<IApiPostHistoryTypeServerRequestModelValidator>();

		public Mock<IApiPostLinkServerRequestModelValidator> PostLinkModelValidatorMock { get; set; } = new Mock<IApiPostLinkServerRequestModelValidator>();

		public Mock<IApiPostServerRequestModelValidator> PostModelValidatorMock { get; set; } = new Mock<IApiPostServerRequestModelValidator>();

		public Mock<IApiPostTypeServerRequestModelValidator> PostTypeModelValidatorMock { get; set; } = new Mock<IApiPostTypeServerRequestModelValidator>();

		public Mock<IApiTagServerRequestModelValidator> TagModelValidatorMock { get; set; } = new Mock<IApiTagServerRequestModelValidator>();

		public Mock<IApiUserServerRequestModelValidator> UserModelValidatorMock { get; set; } = new Mock<IApiUserServerRequestModelValidator>();

		public Mock<IApiVoteServerRequestModelValidator> VoteModelValidatorMock { get; set; } = new Mock<IApiVoteServerRequestModelValidator>();

		public Mock<IApiVoteTypeServerRequestModelValidator> VoteTypeModelValidatorMock { get; set; } = new Mock<IApiVoteTypeServerRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.BadgeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiBadgeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BadgeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBadgeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BadgeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CommentModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCommentServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CommentModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCommentServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CommentModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.LinkTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLinkTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PostHistoryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostHistoryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostHistoryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostHistoryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostHistoryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PostHistoryTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostHistoryTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostHistoryTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostHistoryTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PostLinkModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostLinkServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostLinkModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostLinkServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostLinkModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PostModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PostTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TagModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTagServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TagModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTagServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TagModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.UserModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiUserServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UserModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUserServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UserModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.VoteModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVoteServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VoteModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVoteServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VoteModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.VoteTypeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVoteTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VoteTypeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVoteTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VoteTypeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>187c113cc071d9ede5d645762f2d129e</Hash>
</Codenesium>*/