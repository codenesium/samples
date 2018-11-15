using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiDepartmentServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiDepartmentServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string groupName,
			DateTime modifiedDate,
			string name)
		{
			this.GroupName = groupName;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		[Required]
		[JsonProperty]
		public string GroupName { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>4c1de2cd46d506bebea4987044862847</Hash>
</Codenesium>*/