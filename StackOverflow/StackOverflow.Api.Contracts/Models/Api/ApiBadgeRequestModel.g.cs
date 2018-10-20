using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
	public partial class ApiBadgeRequestModel : AbstractApiRequestModel
	{
		public ApiBadgeRequestModel()
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
		public DateTime Date { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int UserId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>e4af53a4897bf493b070d071f633dc16</Hash>
</Codenesium>*/