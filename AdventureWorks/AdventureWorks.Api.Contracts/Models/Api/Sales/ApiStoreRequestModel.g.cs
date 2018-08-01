using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiStoreRequestModel : AbstractApiRequestModel
	{
		public ApiStoreRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string demographic,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			int? salesPersonID)
		{
			this.Demographic = demographic;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.SalesPersonID = salesPersonID;
		}

		[JsonProperty]
		public string Demographic { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[JsonProperty]
		public int? SalesPersonID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2f87ceee8924a13fc7ca67628292ab67</Hash>
</Codenesium>*/