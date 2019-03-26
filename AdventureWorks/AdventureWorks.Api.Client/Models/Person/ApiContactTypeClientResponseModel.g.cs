using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiContactTypeClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int contactTypeID,
			DateTime modifiedDate,
			string name)
		{
			this.ContactTypeID = contactTypeID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		[JsonProperty]
		public int ContactTypeID { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e890f38dd4b8e915f68551da2bf9e3db</Hash>
</Codenesium>*/