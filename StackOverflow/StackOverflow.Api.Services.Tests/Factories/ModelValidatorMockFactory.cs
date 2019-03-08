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
		public Mock<IApiBadgesServerRequestModelValidator> BadgesModelValidatorMock { get; set; } = new Mock<IApiBadgesServerRequestModelValidator>();

		public Mock<IApiCommentsServerRequestModelValidator> CommentsModelValidatorMock { get; set; } = new Mock<IApiCommentsServerRequestModelValidator>();

		public Mock<IApiLinkTypesServerRequestModelValidator> LinkTypesModelValidatorMock { get; set; } = new Mock<IApiLinkTypesServerRequestModelValidator>();

		public Mock<IApiPostHistoryServerRequestModelValidator> PostHistoryModelValidatorMock { get; set; } = new Mock<IApiPostHistoryServerRequestModelValidator>();

		public Mock<IApiPostHistoryTypesServerRequestModelValidator> PostHistoryTypesModelValidatorMock { get; set; } = new Mock<IApiPostHistoryTypesServerRequestModelValidator>();

		public Mock<IApiPostLinksServerRequestModelValidator> PostLinksModelValidatorMock { get; set; } = new Mock<IApiPostLinksServerRequestModelValidator>();

		public Mock<IApiPostsServerRequestModelValidator> PostsModelValidatorMock { get; set; } = new Mock<IApiPostsServerRequestModelValidator>();

		public Mock<IApiPostTypesServerRequestModelValidator> PostTypesModelValidatorMock { get; set; } = new Mock<IApiPostTypesServerRequestModelValidator>();

		public Mock<IApiTagsServerRequestModelValidator> TagsModelValidatorMock { get; set; } = new Mock<IApiTagsServerRequestModelValidator>();

		public Mock<IApiUsersServerRequestModelValidator> UsersModelValidatorMock { get; set; } = new Mock<IApiUsersServerRequestModelValidator>();

		public Mock<IApiVotesServerRequestModelValidator> VotesModelValidatorMock { get; set; } = new Mock<IApiVotesServerRequestModelValidator>();

		public Mock<IApiVoteTypesServerRequestModelValidator> VoteTypesModelValidatorMock { get; set; } = new Mock<IApiVoteTypesServerRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.BadgesModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiBadgesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BadgesModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBadgesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BadgesModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CommentsModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCommentsServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CommentsModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCommentsServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CommentsModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.LinkTypesModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLinkTypesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkTypesModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkTypesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkTypesModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PostHistoryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostHistoryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostHistoryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostHistoryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostHistoryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PostHistoryTypesModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostHistoryTypesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostHistoryTypesModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostHistoryTypesModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PostLinksModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostLinksServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostLinksModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostLinksServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostLinksModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PostsModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostsServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostsModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostsServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostsModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PostTypesModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostTypesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostTypesModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostTypesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostTypesModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TagsModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTagsServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TagsModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTagsServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TagsModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.UsersModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiUsersServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UsersModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUsersServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UsersModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.VotesModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVotesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VotesModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVotesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VotesModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.VoteTypesModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVoteTypesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VoteTypesModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVoteTypesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VoteTypesModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>eda60f8c5b99e644967f4d6b1ca56bdf</Hash>
</Codenesium>*/