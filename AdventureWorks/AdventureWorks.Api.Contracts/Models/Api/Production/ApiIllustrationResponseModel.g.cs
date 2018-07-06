using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiIllustrationResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int illustrationID,
                        string diagram,
                        DateTime modifiedDate)
                {
                        this.IllustrationID = illustrationID;
                        this.Diagram = diagram;
                        this.ModifiedDate = modifiedDate;
                }

                public string Diagram { get; private set; }

                public int IllustrationID { get; private set; }

                public DateTime ModifiedDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e947433d229fbe429f7bc72db4a6f7aa</Hash>
</Codenesium>*/