using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiDepartmentRequestModel : AbstractApiRequestModel
	{
		public ApiDepartmentRequestModel()
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
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>c26f4fd438e311e88c441815e1be14a1</Hash>
</Codenesium>*/