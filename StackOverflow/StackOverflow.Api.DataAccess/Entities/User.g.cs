using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("Users", Schema="dbo")]
	public partial class User : AbstractEntity
	{
		public User()
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
			int id,
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
			this.Id = id;
			this.LastAccessDate = lastAccessDate;
			this.Location = location;
			this.Reputation = reputation;
			this.UpVote = upVote;
			this.View = view;
			this.WebsiteUrl = websiteUrl;
		}

		[Column("AboutMe")]
		public string AboutMe { get; private set; }

		[Column("AccountId")]
		public int? AccountId { get; private set; }

		[Column("Age")]
		public int? Age { get; private set; }

		[Column("CreationDate")]
		public DateTime CreationDate { get; private set; }

		[MaxLength(40)]
		[Column("DisplayName")]
		public string DisplayName { get; private set; }

		[Column("DownVotes")]
		public int DownVote { get; private set; }

		[MaxLength(40)]
		[Column("EmailHash")]
		public string EmailHash { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("Id")]
		public int Id { get; private set; }

		[Column("LastAccessDate")]
		public DateTime LastAccessDate { get; private set; }

		[MaxLength(100)]
		[Column("Location")]
		public string Location { get; private set; }

		[Column("Reputation")]
		public int Reputation { get; private set; }

		[Column("UpVotes")]
		public int UpVote { get; private set; }

		[Column("Views")]
		public int View { get; private set; }

		[MaxLength(200)]
		[Column("WebsiteUrl")]
		public string WebsiteUrl { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fb262cc4bf592ca33cda9adec9e8ee35</Hash>
</Codenesium>*/