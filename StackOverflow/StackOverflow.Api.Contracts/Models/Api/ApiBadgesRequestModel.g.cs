using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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
    <Hash>4d117fc761f943842a5335f12816f220</Hash>
</Codenesium>*/