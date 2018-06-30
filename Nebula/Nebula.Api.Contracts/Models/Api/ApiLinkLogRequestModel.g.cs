using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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

                public virtual void SetProperties(
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
    <Hash>c4c6e46f6e88a9f79d1701c5136ed087</Hash>
</Codenesium>*/