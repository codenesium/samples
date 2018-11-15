using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class ApiStudioServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			string address1,
			string address2,
			string city,
			string name,
			string province,
			string website,
			string zip)
		{
			this.Id = id;
			this.Address1 = address1;
			this.Address2 = address2;
			this.City = city;
			this.Name = name;
			this.Province = province;
			this.Website = website;
			this.Zip = zip;
		}

		[JsonProperty]
		public string Address1 { get; private set; }

		[JsonProperty]
		public string Address2 { get; private set; }

		[JsonProperty]
		public string City { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public string Province { get; private set; }

		[JsonProperty]
		public string Website { get; private set; }

		[Required]
		[JsonProperty]
		public string Zip { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5185f227280462d5f3742a279dc41ae0</Hash>
</Codenesium>*/