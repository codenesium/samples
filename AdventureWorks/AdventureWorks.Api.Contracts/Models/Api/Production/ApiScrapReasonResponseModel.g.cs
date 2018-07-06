using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiScrapReasonResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        short scrapReasonID,
                        DateTime modifiedDate,
                        string name)
                {
                        this.ScrapReasonID = scrapReasonID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public short ScrapReasonID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8a5b5b9968a5fab51a37b4673f39189e</Hash>
</Codenesium>*/