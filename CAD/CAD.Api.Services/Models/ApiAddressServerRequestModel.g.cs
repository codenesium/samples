using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiAddressServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiAddressServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string address1,
			string address2,
			string city,
			string state,
			string zip)
		{
			this.Address1 = address1;
			this.Address2 = address2;
			this.City = city;
			this.State = state;
			this.Zip = zip;
		}

		[Required]
		[JsonProperty]
		public string Address1 { get; private set; } = default(string);

		[JsonProperty]
		public string Address2 { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string City { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string State { get; private set; } = default(string);

		[JsonProperty]
		public string Zip { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>f60f199b66091ccabf365f9489753abf</Hash>
</Codenesium>*/