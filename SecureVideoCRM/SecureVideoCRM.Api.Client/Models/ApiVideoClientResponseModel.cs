using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SecureVideoCRMNS.Api.Client
{
	public partial class ApiVideoClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string description,
			string title,
			string url)
		{
			this.Id = id;
			this.Description = description;
			this.Title = title;
			this.Url = url;
		}

		[JsonProperty]
		public string Description { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Title { get; private set; }

		[JsonProperty]
		public string Url { get; private set; }
	}
}

/*<Codenesium>
    <Hash>15b2465146400b292082a158564afd70</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/