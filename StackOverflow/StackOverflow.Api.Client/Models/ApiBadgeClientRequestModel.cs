using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiBadgeClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiBadgeClientRequestModel()
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
		public DateTime Date { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public int UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f44c293ce2f1996106333fac32e71b66</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/