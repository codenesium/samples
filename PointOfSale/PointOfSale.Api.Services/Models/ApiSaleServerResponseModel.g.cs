using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PointOfSaleNS.Api.Services
{
	public partial class ApiSaleServerResponseModel : AbstractApiServerResponseModel
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
    <Hash>fe0358de4fc3d070ac9c7e87a3e11709</Hash>
</Codenesium>*/