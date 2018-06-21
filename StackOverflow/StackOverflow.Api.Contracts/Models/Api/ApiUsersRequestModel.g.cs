using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiUsersRequestModel : AbstractApiRequestModel
        {
                public ApiUsersRequestModel()
                        : base()
                {
                }

                public void SetProperties(
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
                        this.LastAccessDate = lastAccessDate;
                        this.Location = location;
                        this.Reputation = reputation;
                        this.UpVotes = upVotes;
                        this.Views = views;
                        this.WebsiteUrl = websiteUrl;
                }

                private string aboutMe;

                public string AboutMe
                {
                        get
                        {
                                return this.aboutMe.IsEmptyOrZeroOrNull() ? null : this.aboutMe;
                        }

                        set
                        {
                                this.aboutMe = value;
                        }
                }

                private Nullable<int> accountId;

                public Nullable<int> AccountId
                {
                        get
                        {
                                return this.accountId.IsEmptyOrZeroOrNull() ? null : this.accountId;
                        }

                        set
                        {
                                this.accountId = value;
                        }
                }

                private Nullable<int> age;

                public Nullable<int> Age
                {
                        get
                        {
                                return this.age.IsEmptyOrZeroOrNull() ? null : this.age;
                        }

                        set
                        {
                                this.age = value;
                        }
                }

                private DateTime creationDate;

                [Required]
                public DateTime CreationDate
                {
                        get
                        {
                                return this.creationDate;
                        }

                        set
                        {
                                this.creationDate = value;
                        }
                }

                private string displayName;

                [Required]
                public string DisplayName
                {
                        get
                        {
                                return this.displayName;
                        }

                        set
                        {
                                this.displayName = value;
                        }
                }

                private int downVotes;

                [Required]
                public int DownVotes
                {
                        get
                        {
                                return this.downVotes;
                        }

                        set
                        {
                                this.downVotes = value;
                        }
                }

                private string emailHash;

                public string EmailHash
                {
                        get
                        {
                                return this.emailHash.IsEmptyOrZeroOrNull() ? null : this.emailHash;
                        }

                        set
                        {
                                this.emailHash = value;
                        }
                }

                private DateTime lastAccessDate;

                [Required]
                public DateTime LastAccessDate
                {
                        get
                        {
                                return this.lastAccessDate;
                        }

                        set
                        {
                                this.lastAccessDate = value;
                        }
                }

                private string location;

                public string Location
                {
                        get
                        {
                                return this.location.IsEmptyOrZeroOrNull() ? null : this.location;
                        }

                        set
                        {
                                this.location = value;
                        }
                }

                private int reputation;

                [Required]
                public int Reputation
                {
                        get
                        {
                                return this.reputation;
                        }

                        set
                        {
                                this.reputation = value;
                        }
                }

                private int upVotes;

                [Required]
                public int UpVotes
                {
                        get
                        {
                                return this.upVotes;
                        }

                        set
                        {
                                this.upVotes = value;
                        }
                }

                private int views;

                [Required]
                public int Views
                {
                        get
                        {
                                return this.views;
                        }

                        set
                        {
                                this.views = value;
                        }
                }

                private string websiteUrl;

                public string WebsiteUrl
                {
                        get
                        {
                                return this.websiteUrl.IsEmptyOrZeroOrNull() ? null : this.websiteUrl;
                        }

                        set
                        {
                                this.websiteUrl = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>e89ea4a586b40aab932a7e5d4cb9501d</Hash>
</Codenesium>*/