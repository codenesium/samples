using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractBOUser : AbstractBusinessObject
	{
		public AbstractBOUser()
			: base()
		{
		}

		public virtual void SetProperties(int id,
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
			this.Id = id;
			this.LastAccessDate = lastAccessDate;
			this.Location = location;
			this.Reputation = reputation;
			this.UpVote = upVote;
			this.View = view;
			this.WebsiteUrl = websiteUrl;
		}

		public string AboutMe { get; private set; }

		public int? AccountId { get; private set; }

		public int? Age { get; private set; }

		public DateTime CreationDate { get; private set; }

		public string DisplayName { get; private set; }

		public int DownVote { get; private set; }

		public string EmailHash { get; private set; }

		public int Id { get; private set; }

		public DateTime LastAccessDate { get; private set; }

		public string Location { get; private set; }

		public int Reputation { get; private set; }

		public int UpVote { get; private set; }

		public int View { get; private set; }

		public string WebsiteUrl { get; private set; }
	}
}

/*<Codenesium>
    <Hash>05aeb12ed868d8de6a9f4a02ab094950</Hash>
</Codenesium>*/