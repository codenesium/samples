using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiBadgeServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiBadgeServerRequestModel()
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

		[Required]
		[JsonProperty]
		public DateTime Date { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int UserId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>6be56af635b0956378d8ddc19ea98966</Hash>
</Codenesium>*/