using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace NebulaNS.Api.Client
{
	public partial class ApiLinkLogClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiLinkLogClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime dateEntered,
			int linkId,
			string log)
		{
			this.DateEntered = dateEntered;
			this.LinkId = linkId;
			this.Log = log;
		}

		[JsonProperty]
		public DateTime DateEntered { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int LinkId { get; private set; }

		[JsonProperty]
		public string Log { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>7fa50478737c95f3d5e3160b5e0a168e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/