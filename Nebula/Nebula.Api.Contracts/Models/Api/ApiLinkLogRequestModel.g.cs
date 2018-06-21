using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiLinkLogRequestModel : AbstractApiRequestModel
        {
                public ApiLinkLogRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        DateTime dateEntered,
                        int linkId,
                        string log)
                {
                        this.DateEntered = dateEntered;
                        this.LinkId = linkId;
                        this.Log = log;
                }

                private DateTime dateEntered;

                [Required]
                public DateTime DateEntered
                {
                        get
                        {
                                return this.dateEntered;
                        }

                        set
                        {
                                this.dateEntered = value;
                        }
                }

                private int linkId;

                [Required]
                public int LinkId
                {
                        get
                        {
                                return this.linkId;
                        }

                        set
                        {
                                this.linkId = value;
                        }
                }

                private string log;

                [Required]
                public string Log
                {
                        get
                        {
                                return this.log;
                        }

                        set
                        {
                                this.log = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>368e37592bcea672315a4810d747d4e0</Hash>
</Codenesium>*/