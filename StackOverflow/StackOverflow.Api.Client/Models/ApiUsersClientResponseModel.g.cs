using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiUsersClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string aboutMe,
			int? accountId,
			int? age,
			DateTime creationDate,
			string displayName,
			int downVote,
			string emailHash,
			DateTime lastAccessDate,
			string location,
			int reputation,
			int upVote,
			int view,
			string websiteUrl)
		{
			this.Id = id;
			this.AboutMe = aboutMe;
			this.AccountId = accountId;
			this.Age = age;
			this.CreationDate = creationDate;
			this.DisplayName = displayName;
			this.DownVote = downVote;
			this.EmailHash = emailHash;
			this.LastAccessDate = lastAccessDate;
			this.Location = location;
			this.Reputation = reputation;
			this.UpVote = upVote;
			this.View = view;
			this.WebsiteUrl = websiteUrl;
		}

		[JsonProperty]
		public string AboutMe { get; private set; }

		[JsonProperty]
		public int? AccountId { get; private set; }

		[JsonProperty]
		public int? Age { get; private set; }

		[JsonProperty]
		public DateTime CreationDate { get; private set; }

		[JsonProperty]
		public string DisplayName { get; private set; }

		[JsonProperty]
		public int DownVote { get; private set; }

		[JsonProperty]
		public string EmailHash { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public DateTime LastAccessDate { get; private set; }

		[JsonProperty]
		public string Location { get; private set; }

		[JsonProperty]
		public int Reputation { get; private set; }

		[JsonProperty]
		public int UpVote { get; private set; }

		[JsonProperty]
		public int View { get; private set; }

		[JsonProperty]
		public string WebsiteUrl { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3a36d130ce8bf63ac5a6043f8911ad94</Hash>
</Codenesium>*/