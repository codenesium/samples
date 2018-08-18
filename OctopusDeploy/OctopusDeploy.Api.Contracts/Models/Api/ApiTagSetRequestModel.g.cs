using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiTagSetRequestModel : AbstractApiRequestModel
	{
		public ApiTagSetRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			byte[] dataVersion,
			string jSON,
			string name,
			int sortOrder)
		{
			this.DataVersion = dataVersion;
			this.JSON = jSON;
			this.Name = name;
			this.SortOrder = sortOrder;
		}

		[JsonProperty]
		public byte[] DataVersion { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int SortOrder { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1bf92cc4b87cb33627096003d00f47db</Hash>
</Codenesium>*/