using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
	public partial class ApiBadgesRequestModel : AbstractApiRequestModel
	{
		public ApiBadgesRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime date,
			string name,
			int userId)
		{
			this.Date = date;
			this.Name = name;
			this.UserId = userId;
		}

		[JsonProperty]
		public DateTime Date { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d72b0eb1cff6a9f4b8372bc90621443c</Hash>
</Codenesium>*/