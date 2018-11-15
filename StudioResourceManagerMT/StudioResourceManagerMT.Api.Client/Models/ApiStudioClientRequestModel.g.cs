using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial class ApiStudioClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiStudioClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string address1,
			string address2,
			string city,
			string name,
			string province,
			string website,
			string zip)
		{
			this.Address1 = address1;
			this.Address2 = address2;
			this.City = city;
			this.Name = name;
			this.Province = province;
			this.Website = website;
			this.Zip = zip;
		}

		[JsonProperty]
		public string Address1 { get; private set; } = default(string);

		[JsonProperty]
		public string Address2 { get; private set; } = default(string);

		[JsonProperty]
		public string City { get; private set; } = default(string);

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public string Province { get; private set; } = default(string);

		[JsonProperty]
		public string Website { get; private set; } = default(string);

		[JsonProperty]
		public string Zip { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>63f14ab61ae68247eba2c08f3c0fec78</Hash>
</Codenesium>*/