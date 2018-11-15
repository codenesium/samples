using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Client
{
	public partial class ApiFileTypeClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiFileTypeClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string name)
		{
			this.Name = name;
		}

		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>bd5fc3dd8f11bd2dcf4c32d38881bf0e</Hash>
</Codenesium>*/