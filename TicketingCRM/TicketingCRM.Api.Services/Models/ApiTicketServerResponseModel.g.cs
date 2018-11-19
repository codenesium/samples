using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace TicketingCRMNS.Api.Services
{
    public partial class ApiTicketServerResponseModel : AbstractApiServerResponseModel
    {	

	    public virtual void SetProperties(
		int id,
		string publicId,
int ticketStatusId)
        {
		this.Id = id;
		this.PublicId = publicId;
this.TicketStatusId = ticketStatusId;

				
		
		}



		        [JsonProperty]
        public int Id{ get; private set; }

        [JsonProperty]
        public string PublicId{ get; private set; }

        [JsonProperty]
        public int TicketStatusId{ get; private set; }

        [JsonProperty]
        public string TicketStatusIdEntity { get;set; }

    }
}

/*<Codenesium>
    <Hash>57eb85fe60aed4b919a51a4dd6524b22</Hash>
</Codenesium>*/