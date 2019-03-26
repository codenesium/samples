using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiContactTypeServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiContactTypeServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			string name)
		{
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>1b84ffabb078e0c0edf58c9820eb963f</Hash>
</Codenesium>*/