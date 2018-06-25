using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiBadgesRequestModel : AbstractApiRequestModel
        {
                public ApiBadgesRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTime date,
                        string name,
                        int userId)
                {
                        this.Date = date;
                        this.Name = name;
                        this.UserId = userId;
                }

                private DateTime date;

                [Required]
                public DateTime Date
                {
                        get
                        {
                                return this.date;
                        }

                        set
                        {
                                this.date = value;
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

                private int userId;

                [Required]
                public int UserId
                {
                        get
                        {
                                return this.userId;
                        }

                        set
                        {
                                this.userId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>f8d7a35a551297a070eace2d7f636b3f</Hash>
</Codenesium>*/