using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiUserServerResponseModel : AbstractApiServerResponseModel
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

		[Required]
		[JsonProperty]
		public string AboutMe { get; private set; }

		[Required]
		[JsonProperty]
		public int? AccountId { get; private set; }

		[Required]
		[JsonProperty]
		public int? Age { get; private set; }

		[JsonProperty]
		public DateTime CreationDate { get; private set; }

		[JsonProperty]
		public string DisplayName { get; private set; }

		[JsonProperty]
		public int DownVote { get; private set; }

		[Required]
		[JsonProperty]
		public string EmailHash { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public DateTime LastAccessDate { get; private set; }

		[Required]
		[JsonProperty]
		public string Location { get; private set; }

		[JsonProperty]
		public int Reputation { get; private set; }

		[JsonProperty]
		public int UpVote { get; private set; }

		[JsonProperty]
		public int View { get; private set; }

		[Required]
		[JsonProperty]
		public string WebsiteUrl { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b68677d7ad83d0eadef230ab68d519bc</Hash>
</Codenesium>*/