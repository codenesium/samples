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
			int stateId,
			string website,
			string zip)
		{
			this.Address1 = address1;
			this.Address2 = address2;
			this.City = city;
			this.Name = name;
			this.StateId = stateId;
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
		public string Name { get; private set; }

		[JsonProperty]
		public int StateId { get; private set; }

		[JsonProperty]
		public string Website { get; private set; }

		[JsonProperty]
		public string Zip { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e9f665a43b14286b8552bea9646f70e7</Hash>
</Codenesium>*/