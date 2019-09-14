using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Client
{
	public partial class ApiPetClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiPetClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime acquiredDate,
			int breedId,
			string description,
			int penId,
			decimal price)
		{
			this.AcquiredDate = acquiredDate;
			this.BreedId = breedId;
			this.Description = description;
			this.PenId = penId;
			this.Price = price;
		}

		[JsonProperty]
		public DateTime AcquiredDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int BreedId { get; private set; }

		[JsonProperty]
		public string Description { get; private set; } = default(string);

		[JsonProperty]
		public int PenId { get; private set; }

		[JsonProperty]
		public decimal Price { get; private set; } = default(decimal);
	}
}

/*<Codenesium>
    <Hash>1dfe42fa9f206e1dbc149cf49a1c6929</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/