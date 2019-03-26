using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiScrapReasonServerResponseModel : AbstractApiServerResponseModel
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

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public short ScrapReasonID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>761416252dedc40c637beb72e4b3b9cf</Hash>
</Codenesium>*/