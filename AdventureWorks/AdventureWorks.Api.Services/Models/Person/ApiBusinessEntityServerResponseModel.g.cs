using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiBusinessEntityServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int businessEntityID,
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.BusinessEntityID = businessEntityID;
			this.ModifiedDate = modifiedDate;
			this.Rowguid = rowguid;
		}

		[JsonProperty]
		public int BusinessEntityID { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0020155abe8a8bef6fbd5269ec882eb5</Hash>
</Codenesium>*/