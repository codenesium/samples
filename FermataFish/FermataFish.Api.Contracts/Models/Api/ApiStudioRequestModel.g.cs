using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiStudioRequestModel : AbstractApiRequestModel
	{
		public ApiStudioRequestModel()
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
		public string Address1 { get; private set; }

		[Required]
		[JsonProperty]
		public string Address2 { get; private set; }

		[Required]
		[JsonProperty]
		public string City { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public string Province { get; private set; }

		[Required]
		[JsonProperty]
		public string Website { get; private set; }

		[Required]
		[JsonProperty]
		public string Zip { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1c2af8008e5fd8b3f154eb8dec993c72</Hash>
</Codenesium>*/