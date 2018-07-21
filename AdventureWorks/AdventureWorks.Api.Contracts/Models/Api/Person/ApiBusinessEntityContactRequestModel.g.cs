using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiBusinessEntityContactRequestModel : AbstractApiRequestModel
        {
                public ApiBusinessEntityContactRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int contactTypeID,
                        DateTime modifiedDate,
                        int personID,
                        Guid rowguid)
                {
                        this.ContactTypeID = contactTypeID;
                        this.ModifiedDate = modifiedDate;
                        this.PersonID = personID;
                        this.Rowguid = rowguid;
                }

                [Required]
                [JsonProperty]
                public int ContactTypeID { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [Required]
                [JsonProperty]
                public int PersonID { get; private set; }

                [Required]
                [JsonProperty]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>013dbae45fa4a8df113166dfaa6475cf</Hash>
</Codenesium>*/