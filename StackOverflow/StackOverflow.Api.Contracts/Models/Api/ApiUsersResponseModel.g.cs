using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
	public partial class ApiUsersResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			string aboutMe,
			int? accountId,
			int? age,
			DateTime creationDate,
			string displayName,
			int downVotes,
			string emailHash,
			DateTime lastAccessDate,
			string location,
			int reputation,
			int upVotes,
			int views,
			string websiteUrl)
		{
			this.Id = id;
			this.AboutMe = aboutMe;
			this.AccountId = accountId;
			this.Age = age;
			this.CreationDate = creationDate;
			this.DisplayName = displayName;
			this.DownVotes = downVotes;
			this.EmailHash = emailHash;
			this.LastAccessDate = lastAccessDate;
			this.Location = location;
			this.Reputation = reputation;
			this.UpVotes = upVotes;
			this.Views = views;
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

		[Required]
		[JsonProperty]
		public DateTime CreationDate { get; private set; }

		[Required]
		[JsonProperty]
		public string DisplayName { get; private set; }

		[Required]
		[JsonProperty]
		public int DownVotes { get; private set; }

		[Required]
		[JsonProperty]
		public string EmailHash { get; private set; }

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime LastAccessDate { get; private set; }

		[Required]
		[JsonProperty]
		public string Location { get; private set; }

		[Required]
		[JsonProperty]
		public int Reputation { get; private set; }

		[Required]
		[JsonProperty]
		public int UpVotes { get; private set; }

		[Required]
		[JsonProperty]
		public int Views { get; private set; }

		[Required]
		[JsonProperty]
		public string WebsiteUrl { get; private set; }
	}
}

/*<Codenesium>
    <Hash>035fa5cda4cbca602f12e918da3cd9ba</Hash>
</Codenesium>*/