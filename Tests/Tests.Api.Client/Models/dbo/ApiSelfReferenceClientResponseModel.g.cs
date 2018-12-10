using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestsNS.Api.Client
{
    public partial class ApiSelfReferenceClientResponseModel : AbstractApiClientResponseModel
    {	

	    public virtual void SetProperties(
		int id,
		int? selfReferenceId,
int? selfReferenceId2)
        {
		this.Id = id;
		this.SelfReferenceId = selfReferenceId;
this.SelfReferenceId2 = selfReferenceId2;

				
		
		}



		        [JsonProperty]
        public int Id{ get; private set; }

        [JsonProperty]
        public int? SelfReferenceId{ get; private set; }

        [JsonProperty]
        public int? SelfReferenceId2{ get; private set; }

    }
}

/*<Codenesium>
    <Hash>9c049321e19e433ad8d8ee2f750356b7</Hash>
</Codenesium>*/