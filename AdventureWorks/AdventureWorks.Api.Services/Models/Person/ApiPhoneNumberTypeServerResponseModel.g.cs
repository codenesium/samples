using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiPhoneNumberTypeServerResponseModel : AbstractApiServerResponseModel
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
    <Hash>82b06f2dc8fe85587640fccc96125251</Hash>
</Codenesium>*/