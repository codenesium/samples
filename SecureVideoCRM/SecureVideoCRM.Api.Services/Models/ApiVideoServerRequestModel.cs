using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace SecureVideoCRMNS.Api.Services
{
	public partial class ApiVideoServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiVideoServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string description,
			string title,
			string url)
		{
			this.Description = description;
			this.Title = title;
			this.Url = url;
		}

		[Required]
		[JsonProperty]
		public string Description { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Title { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Url { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>a39bd1f5a7d438d09f0d717cb3c48d86</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/