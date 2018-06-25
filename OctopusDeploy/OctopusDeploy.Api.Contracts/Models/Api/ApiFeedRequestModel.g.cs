using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiFeedRequestModel : AbstractApiRequestModel
        {
                public ApiFeedRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string feedType,
                        string feedUri,
                        string jSON,
                        string name)
                {
                        this.FeedType = feedType;
                        this.FeedUri = feedUri;
                        this.JSON = jSON;
                        this.Name = name;
                }

                private string feedType;

                [Required]
                public string FeedType
                {
                        get
                        {
                                return this.feedType;
                        }

                        set
                        {
                                this.feedType = value;
                        }
                }

                private string feedUri;

                [Required]
                public string FeedUri
                {
                        get
                        {
                                return this.feedUri;
                        }

                        set
                        {
                                this.feedUri = value;
                        }
                }

                private string jSON;

                [Required]
                public string JSON
                {
                        get
                        {
                                return this.jSON;
                        }

                        set
                        {
                                this.jSON = value;
                        }
                }

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>e56b5450f7a7c911bcb77d6b9690517b</Hash>
</Codenesium>*/