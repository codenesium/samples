using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiSpaceFeatureRequestModel : AbstractApiRequestModel
	{
		public ApiSpaceFeatureRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string name,
			bool isDeleted)
		{
			this.Name = name;
			this.IsDeleted = isDeleted;
		}

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public bool IsDeleted { get; private set; } = default(bool);
	}
}

/*<Codenesium>
    <Hash>0e68f150a9fb86692579e897ee12d52f</Hash>
</Codenesium>*/