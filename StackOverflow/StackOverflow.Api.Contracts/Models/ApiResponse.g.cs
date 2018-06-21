using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiResponse
        {
                public ApiResponse()
                {
                }

                public void Merge(ApiResponse from)
                {
                        from.Badges.ForEach(x => this.AddBadges(x));
                        from.Comments.ForEach(x => this.AddComments(x));
                        from.LinkTypes.ForEach(x => this.AddLinkTypes(x));
                        from.PostHistories.ForEach(x => this.AddPostHistory(x));
                        from.PostHistoryTypes.ForEach(x => this.AddPostHistoryTypes(x));
                        from.PostLinks.ForEach(x => this.AddPostLinks(x));
                        from.Posts.ForEach(x => this.AddPosts(x));
                        from.PostTypes.ForEach(x => this.AddPostTypes(x));
                        from.Tags.ForEach(x => this.AddTags(x));
                        from.Users.ForEach(x => this.AddUsers(x));
                        from.Votes.ForEach(x => this.AddVotes(x));
                        from.VoteTypes.ForEach(x => this.AddVoteTypes(x));
                }

                public List<ApiBadgesResponseModel> Badges { get; private set; } = new List<ApiBadgesResponseModel>();

                public List<ApiCommentsResponseModel> Comments { get; private set; } = new List<ApiCommentsResponseModel>();

                public List<ApiLinkTypesResponseModel> LinkTypes { get; private set; } = new List<ApiLinkTypesResponseModel>();

                public List<ApiPostHistoryResponseModel> PostHistories { get; private set; } = new List<ApiPostHistoryResponseModel>();

                public List<ApiPostHistoryTypesResponseModel> PostHistoryTypes { get; private set; } = new List<ApiPostHistoryTypesResponseModel>();

                public List<ApiPostLinksResponseModel> PostLinks { get; private set; } = new List<ApiPostLinksResponseModel>();

                public List<ApiPostsResponseModel> Posts { get; private set; } = new List<ApiPostsResponseModel>();

                public List<ApiPostTypesResponseModel> PostTypes { get; private set; } = new List<ApiPostTypesResponseModel>();

                public List<ApiTagsResponseModel> Tags { get; private set; } = new List<ApiTagsResponseModel>();

                public List<ApiUsersResponseModel> Users { get; private set; } = new List<ApiUsersResponseModel>();

                public List<ApiVotesResponseModel> Votes { get; private set; } = new List<ApiVotesResponseModel>();

                public List<ApiVoteTypesResponseModel> VoteTypes { get; private set; } = new List<ApiVoteTypesResponseModel>();

                [JsonIgnore]
                public bool ShouldSerializeBadgesValue { get; private set; } = true;

                public bool ShouldSerializeBadges()
                {
                        return this.ShouldSerializeBadgesValue;
                }

                public void AddBadges(ApiBadgesResponseModel item)
                {
                        if (!this.Badges.Any(x => x.Id == item.Id))
                        {
                                this.Badges.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeCommentsValue { get; private set; } = true;

                public bool ShouldSerializeComments()
                {
                        return this.ShouldSerializeCommentsValue;
                }

                public void AddComments(ApiCommentsResponseModel item)
                {
                        if (!this.Comments.Any(x => x.Id == item.Id))
                        {
                                this.Comments.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeLinkTypesValue { get; private set; } = true;

                public bool ShouldSerializeLinkTypes()
                {
                        return this.ShouldSerializeLinkTypesValue;
                }

                public void AddLinkTypes(ApiLinkTypesResponseModel item)
                {
                        if (!this.LinkTypes.Any(x => x.Id == item.Id))
                        {
                                this.LinkTypes.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializePostHistoriesValue { get; private set; } = true;

                public bool ShouldSerializePostHistories()
                {
                        return this.ShouldSerializePostHistoriesValue;
                }

                public void AddPostHistory(ApiPostHistoryResponseModel item)
                {
                        if (!this.PostHistories.Any(x => x.Id == item.Id))
                        {
                                this.PostHistories.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializePostHistoryTypesValue { get; private set; } = true;

                public bool ShouldSerializePostHistoryTypes()
                {
                        return this.ShouldSerializePostHistoryTypesValue;
                }

                public void AddPostHistoryTypes(ApiPostHistoryTypesResponseModel item)
                {
                        if (!this.PostHistoryTypes.Any(x => x.Id == item.Id))
                        {
                                this.PostHistoryTypes.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializePostLinksValue { get; private set; } = true;

                public bool ShouldSerializePostLinks()
                {
                        return this.ShouldSerializePostLinksValue;
                }

                public void AddPostLinks(ApiPostLinksResponseModel item)
                {
                        if (!this.PostLinks.Any(x => x.Id == item.Id))
                        {
                                this.PostLinks.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializePostsValue { get; private set; } = true;

                public bool ShouldSerializePosts()
                {
                        return this.ShouldSerializePostsValue;
                }

                public void AddPosts(ApiPostsResponseModel item)
                {
                        if (!this.Posts.Any(x => x.Id == item.Id))
                        {
                                this.Posts.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializePostTypesValue { get; private set; } = true;

                public bool ShouldSerializePostTypes()
                {
                        return this.ShouldSerializePostTypesValue;
                }

                public void AddPostTypes(ApiPostTypesResponseModel item)
                {
                        if (!this.PostTypes.Any(x => x.Id == item.Id))
                        {
                                this.PostTypes.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeTagsValue { get; private set; } = true;

                public bool ShouldSerializeTags()
                {
                        return this.ShouldSerializeTagsValue;
                }

                public void AddTags(ApiTagsResponseModel item)
                {
                        if (!this.Tags.Any(x => x.Id == item.Id))
                        {
                                this.Tags.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeUsersValue { get; private set; } = true;

                public bool ShouldSerializeUsers()
                {
                        return this.ShouldSerializeUsersValue;
                }

                public void AddUsers(ApiUsersResponseModel item)
                {
                        if (!this.Users.Any(x => x.Id == item.Id))
                        {
                                this.Users.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeVotesValue { get; private set; } = true;

                public bool ShouldSerializeVotes()
                {
                        return this.ShouldSerializeVotesValue;
                }

                public void AddVotes(ApiVotesResponseModel item)
                {
                        if (!this.Votes.Any(x => x.Id == item.Id))
                        {
                                this.Votes.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeVoteTypesValue { get; private set; } = true;

                public bool ShouldSerializeVoteTypes()
                {
                        return this.ShouldSerializeVoteTypesValue;
                }

                public void AddVoteTypes(ApiVoteTypesResponseModel item)
                {
                        if (!this.VoteTypes.Any(x => x.Id == item.Id))
                        {
                                this.VoteTypes.Add(item);
                        }
                }

                public void DisableSerializationOfEmptyFields()
                {
                        if (this.Badges.Count == 0)
                        {
                                this.ShouldSerializeBadgesValue = false;
                        }

                        if (this.Comments.Count == 0)
                        {
                                this.ShouldSerializeCommentsValue = false;
                        }

                        if (this.LinkTypes.Count == 0)
                        {
                                this.ShouldSerializeLinkTypesValue = false;
                        }

                        if (this.PostHistories.Count == 0)
                        {
                                this.ShouldSerializePostHistoriesValue = false;
                        }

                        if (this.PostHistoryTypes.Count == 0)
                        {
                                this.ShouldSerializePostHistoryTypesValue = false;
                        }

                        if (this.PostLinks.Count == 0)
                        {
                                this.ShouldSerializePostLinksValue = false;
                        }

                        if (this.Posts.Count == 0)
                        {
                                this.ShouldSerializePostsValue = false;
                        }

                        if (this.PostTypes.Count == 0)
                        {
                                this.ShouldSerializePostTypesValue = false;
                        }

                        if (this.Tags.Count == 0)
                        {
                                this.ShouldSerializeTagsValue = false;
                        }

                        if (this.Users.Count == 0)
                        {
                                this.ShouldSerializeUsersValue = false;
                        }

                        if (this.Votes.Count == 0)
                        {
                                this.ShouldSerializeVotesValue = false;
                        }

                        if (this.VoteTypes.Count == 0)
                        {
                                this.ShouldSerializeVoteTypesValue = false;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>4bfe59767fd75e282858a05733e9462b</Hash>
</Codenesium>*/