using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data.SqlTypes;

namespace CADNS.Api.Client
{
    public partial class ApiPersonTypeClientRequestModel : AbstractApiClientRequestModel
    {
        public ApiPersonTypeClientRequestModel() 
			: base()
        {
        }

						public virtual void SetProperties( 
			string name)
        {
		this.Name = name;

        }
		
		        [JsonProperty]
        public string Name{ get; private set; } = default(string);

    }
}

/*<Codenesium>
    <Hash>5458316f46b1fa5eccc1f2fac07daadd</Hash>
</Codenesium>*/