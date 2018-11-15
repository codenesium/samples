using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
	public partial class ApiLinkLogServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiLinkLogServerRequestModel()
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

		[Required]
		[JsonProperty]
		public DateTime DateEntered { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public int LinkId { get; private set; }

		[Required]
		[JsonProperty]
		public string Log { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>d0cfe37f74835f1770c83eb153852fa7</Hash>
</Codenesium>*/