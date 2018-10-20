using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
	public partial class ApiUserRequestModel : AbstractApiRequestModel
	{
		public ApiUserRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
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
		public string AboutMe { get; private set; } = default(string);

		[JsonProperty]
		public int? AccountId { get; private set; } = default(int);

		[JsonProperty]
		public int? Age { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public DateTime CreationDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public string DisplayName { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int DownVote { get; private set; } = default(int);

		[JsonProperty]
		public string EmailHash { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime LastAccessDate { get; private set; } = default(DateTime);

		[JsonProperty]
		public string Location { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int Reputation { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int UpVote { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int View { get; private set; } = default(int);

		[JsonProperty]
		public string WebsiteUrl { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>d2762cc8694689e90bd4fb712137665e</Hash>
</Codenesium>*/