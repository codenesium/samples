using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PointOfSaleNS.Api.Client
{
	public partial class ApiSaleClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int customerId,
			DateTime date)
		{
			this.Id = id;
			this.CustomerId = customerId;
			this.Date = date;
		}

		[JsonProperty]
		public int CustomerId { get; private set; }

		[JsonProperty]
		public DateTime Date { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e3022b4688ab9e728077a5b27eaca96b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/