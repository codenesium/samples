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
		public virtual string AboutMe { get; private set; }

		[Column("AccountId")]
		public virtual int? AccountId { get; private set; }

		[Column("Age")]
		public virtual int? Age { get; private set; }

		[Column("CreationDate")]
		public virtual DateTime CreationDate { get; private set; }

		[MaxLength(40)]
		[Column("DisplayName")]
		public virtual string DisplayName { get; private set; }

		[Column("DownVotes")]
		public virtual int DownVote { get; private set; }

		[MaxLength(40)]
		[Column("EmailHash")]
		public virtual string EmailHash { get; private set; }

		[Key]
		[Column("Id")]
		public virtual int Id { get; private set; }

		[Column("LastAccessDate")]
		public virtual DateTime LastAccessDate { get; private set; }

		[MaxLength(100)]
		[Column("Location")]
		public virtual string Location { get; private set; }

		[Column("Reputation")]
		public virtual int Reputation { get; private set; }

		[Column("UpVotes")]
		public virtual int UpVote { get; private set; }

		[Column("Views")]
		public virtual int View { get; private set; }

		[MaxLength(200)]
		[Column("WebsiteUrl")]
		public virtual string WebsiteUrl { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e2afd139102a332513d64812c170e1a6</Hash>
</Codenesium>*/