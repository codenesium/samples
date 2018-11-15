using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiSalesReasonServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiSalesReasonServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			string name,
			string reasonType)
		{
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.ReasonType = reasonType;
		}

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string ReasonType { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>97c5974617b06d8c729504c817496ce1</Hash>
</Codenesium>*/