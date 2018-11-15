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
		public int UserId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>b56e4ffcf10a568feca7adaaff5a57cf</Hash>
</Codenesium>*/