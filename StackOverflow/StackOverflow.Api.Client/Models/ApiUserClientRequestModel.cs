using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiUserClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiUserClientRequestModel()
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

		[JsonProperty]
		public DateTime CreationDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string DisplayName { get; private set; } = default(string);

		[JsonProperty]
		public int DownVote { get; private set; } = default(int);

		[JsonProperty]
		public string EmailHash { get; private set; } = default(string);

		[JsonProperty]
		public DateTime LastAccessDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Location { get; private set; } = default(string);

		[JsonProperty]
		public int Reputation { get; private set; } = default(int);

		[JsonProperty]
		public int UpVote { get; private set; } = default(int);

		[JsonProperty]
		public int View { get; private set; } = default(int);

		[JsonProperty]
		public string WebsiteUrl { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>9bae127e4bea63e9537e596cb0ccfe5d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/