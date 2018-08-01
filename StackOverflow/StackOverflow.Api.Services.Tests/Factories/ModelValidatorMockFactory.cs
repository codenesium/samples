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
		public Mock<IApiBadgesRequestModelValidator> BadgesModelValidatorMock { get; set; } = new Mock<IApiBadgesRequestModelValidator>();

		public Mock<IApiCommentsRequestModelValidator> CommentsModelValidatorMock { get; set; } = new Mock<IApiCommentsRequestModelValidator>();

		public Mock<IApiLinkTypesRequestModelValidator> LinkTypesModelValidatorMock { get; set; } = new Mock<IApiLinkTypesRequestModelValidator>();

		public Mock<IApiPostHistoryRequestModelValidator> PostHistoryModelValidatorMock { get; set; } = new Mock<IApiPostHistoryRequestModelValidator>();

		public Mock<IApiPostHistoryTypesRequestModelValidator> PostHistoryTypesModelValidatorMock { get; set; } = new Mock<IApiPostHistoryTypesRequestModelValidator>();

		public Mock<IApiPostLinksRequestModelValidator> PostLinksModelValidatorMock { get; set; } = new Mock<IApiPostLinksRequestModelValidator>();

		public Mock<IApiPostsRequestModelValidator> PostsModelValidatorMock { get; set; } = new Mock<IApiPostsRequestModelValidator>();

		public Mock<IApiPostTypesRequestModelValidator> PostTypesModelValidatorMock { get; set; } = new Mock<IApiPostTypesRequestModelValidator>();

		public Mock<IApiTagsRequestModelValidator> TagsModelValidatorMock { get; set; } = new Mock<IApiTagsRequestModelValidator>();

		public Mock<IApiUsersRequestModelValidator> UsersModelValidatorMock { get; set; } = new Mock<IApiUsersRequestModelValidator>();

		public Mock<IApiVotesRequestModelValidator> VotesModelValidatorMock { get; set; } = new Mock<IApiVotesRequestModelValidator>();

		public Mock<IApiVoteTypesRequestModelValidator> VoteTypesModelValidatorMock { get; set; } = new Mock<IApiVoteTypesRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.BadgesModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiBadgesRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BadgesModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBadgesRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.BadgesModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CommentsModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCommentsRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CommentsModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCommentsRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CommentsModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.LinkTypesModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLinkTypesRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkTypesModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkTypesRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkTypesModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PostHistoryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostHistoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostHistoryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostHistoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostHistoryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PostHistoryTypesModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostHistoryTypesRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostHistoryTypesModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypesRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostHistoryTypesModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PostLinksModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostLinksRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostLinksModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostLinksRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostLinksModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PostsModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostsRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostsModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostsRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostsModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.PostTypesModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostTypesRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostTypesModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostTypesRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.PostTypesModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TagsModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTagsRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TagsModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTagsRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TagsModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.UsersModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiUsersRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UsersModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUsersRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UsersModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.VotesModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVotesRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VotesModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVotesRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VotesModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.VoteTypesModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVoteTypesRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VoteTypesModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVoteTypesRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VoteTypesModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>cf854724e961acb4e35a259ae37703ab</Hash>
</Codenesium>*/