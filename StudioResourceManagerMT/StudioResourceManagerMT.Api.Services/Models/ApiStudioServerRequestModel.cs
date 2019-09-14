using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class ApiStudioServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiStudioServerRequestModel()
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

		[Required]
		[JsonProperty]
		public string Address1 { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Address2 { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string City { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Province { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Website { get; private set; } = default(string);

		[JsonProperty]
		public string Zip { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>99f1d7a17f0847ad2152a1e553ecb453</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/