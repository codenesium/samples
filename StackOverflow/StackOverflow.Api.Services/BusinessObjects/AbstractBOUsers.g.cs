using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
        public abstract class AbstractBOUsers : AbstractBusinessObject
        {
                public AbstractBOUsers()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  string aboutMe,
                                                  Nullable<int> accountId,
                                                  Nullable<int> age,
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

                public string AboutMe { get; private set; }

                public Nullable<int> AccountId { get; private set; }

                public Nullable<int> Age { get; private set; }

                public DateTime CreationDate { get; private set; }

                public string DisplayName { get; private set; }

                public int DownVotes { get; private set; }

                public string EmailHash { get; private set; }

                public int Id { get; private set; }

                public DateTime LastAccessDate { get; private set; }

                public string Location { get; private set; }

                public int Reputation { get; private set; }

                public int UpVotes { get; private set; }

                public int Views { get; private set; }

                public string WebsiteUrl { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1868e41c95bd4f9c132bb909e0410d71</Hash>
</Codenesium>*/