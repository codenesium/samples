using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiBadgeServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			DateTime date,
			string name,
			int userId)
		{
			this.Id = id;
			this.Date = date;
			this.Name = name;
			this.UserId = userId;
		}

		[JsonProperty]
		public DateTime Date { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2d7c48d0b0d5910127916cd21111496a</Hash>
</Codenesium>*/