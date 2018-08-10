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

		[Column("DisplayName")]
		public string DisplayName { get; private set; }

		[Column("DownVotes")]
		public int DownVotes { get; private set; }

		[Column("EmailHash")]
		public string EmailHash { get; private set; }

		[Key]
		[Column("Id")]
		public int Id { get; private set; }

		[Column("LastAccessDate")]
		public DateTime LastAccessDate { get; private set; }

		[Column("Location")]
		public string Location { get; private set; }

		[Column("Reputation")]
		public int Reputation { get; private set; }

		[Column("UpVotes")]
		public int UpVotes { get; private set; }

		[Column("Views")]
		public int Views { get; private set; }

		[Column("WebsiteUrl")]
		public string WebsiteUrl { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8d8d51a7cd9b2b64724da4ca7706f37c</Hash>
</Codenesium>*/