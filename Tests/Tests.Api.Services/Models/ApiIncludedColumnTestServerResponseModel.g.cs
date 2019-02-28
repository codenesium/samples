using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace TestsNS.Api.Services
{
    public partial class ApiIncludedColumnTestServerResponseModel : AbstractApiServerResponseModel
    {	

	    public virtual void SetProperties(
		int id,
		string name,
string name2)
        {
		this.Id = id;
		this.Name = name;
this.Name2 = name2;

				
		
		}



		        [JsonProperty]
        public int Id{ get; private set; }

        [JsonProperty]
        public string Name{ get; private set; }

        [JsonProperty]
        public string Name2{ get; private set; }

    }
}

/*<Codenesium>
    <Hash>eeb9a87d6ff7ce1c71aafd8294a4a4bb</Hash>
</Codenesium>*/