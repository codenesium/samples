using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiPhoneNumberTypeClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int phoneNumberTypeID,
			DateTime modifiedDate,
			string name)
		{
			this.PhoneNumberTypeID = phoneNumberTypeID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int PhoneNumberTypeID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>537775392f78900b2acb9e740b01ec21</Hash>
</Codenesium>*/