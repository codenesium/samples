using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("Users", Schema="dbo")]
	public partial class Users : AbstractEntity
	{
		public Users()
		{
		}

		public virtual void SetProperties(
			string aboutMe,
			int? accountId,
			int? age,
			DateTime creationDate,
			string displayName,
			int downVotes,
			string emailHash,
			int id,
			DateTime lastAccessDate,
			string location,
			int reputation,
			int upVotes,
			int views,
			string websiteUrl)
		{
			this.AboutMe = aboutMe;
			this.AccountId = accountId;
			this.Age = age;
			this.CreationDate = creationDate;
			this.DisplayName = displayName;
			this.DownVotes = downVotes;
			this.EmailHash = emailHash;
			this.Id = id;
			this.LastAccessDate = lastAccessDate;
			this.Location = location;
			this.Reputation = reputation;
			this.UpVotes = upVotes;
			this.Views = views;
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
		public int DownVotes { get; private set; }

		[MaxLength(40)]
		[Column("EmailHash")]
		public string EmailHash { get; private set; }

		[Key]
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
		public int UpVotes { get; private set; }

		[Column("Views")]
		public int Views { get; private set; }

		[MaxLength(200)]
		[Column("WebsiteUrl")]
		public string WebsiteUrl { get; private set; }
	}
}

/*<Codenesium>
    <Hash>492fa5bb5c8b3a6b8a9b43156ebd3bcc</Hash>
</Codenesium>*/