using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
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
			string zip,
			bool isDeleted)
		{
			this.Address1 = address1;
			this.Address2 = address2;
			this.City = city;
			this.Name = name;
			this.Province = province;
			this.Website = website;
			this.Zip = zip;
			this.IsDeleted = isDeleted;
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

		[Required]
		[JsonProperty]
		public bool IsDeleted { get; private set; } = default(bool);
	}
}

/*<Codenesium>
    <Hash>1851537780f9bcd85c452b31b81d75fe</Hash>
</Codenesium>*/