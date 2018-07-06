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

                public string AboutMe { get; private set; }

                public int? AccountId { get; private set; }

                public int? Age { get; private set; }

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
    <Hash>894fffa2a451c03f8b4ffebe651b6e33</Hash>
</Codenesium>*/