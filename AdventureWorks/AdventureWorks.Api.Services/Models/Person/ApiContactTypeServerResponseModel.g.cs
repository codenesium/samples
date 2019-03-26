using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiContactTypeServerResponseModel : AbstractApiServerResponseModel
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
    <Hash>ee984566895c9fb34d7dfa151019b270</Hash>
</Codenesium>*/