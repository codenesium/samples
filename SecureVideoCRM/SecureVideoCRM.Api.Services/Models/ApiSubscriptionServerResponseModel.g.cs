using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace SecureVideoCRMNS.Api.Services
{
	public partial class ApiSubscriptionServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			string name,
			string stripePlanName)
		{
			this.Id = id;
			this.Name = name;
			this.StripePlanName = stripePlanName;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public string StripePlanName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9f8837ef228578c95c46e602b79ca3fc</Hash>
</Codenesium>*/