using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiPersonPhoneRequestModel : AbstractApiRequestModel
	{
		public ApiPersonPhoneRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			string phoneNumber,
			int phoneNumberTypeID)
		{
			this.ModifiedDate = modifiedDate;
			this.PhoneNumber = phoneNumber;
			this.PhoneNumberTypeID = phoneNumberTypeID;
		}

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public string PhoneNumber { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int PhoneNumberTypeID { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>a8f5d96b5bf796d523833c0ed41b0bac</Hash>
</Codenesium>*/