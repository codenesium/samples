using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiCallPersonServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiCallPersonServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string note,
			int personId,
			int personTypeId)
		{
			this.Note = note;
			this.PersonId = personId;
			this.PersonTypeId = personTypeId;
		}

		[JsonProperty]
		public string Note { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int PersonId { get; private set; }

		[Required]
		[JsonProperty]
		public int PersonTypeId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a8ea0ff7d3063f6e5bbfdd94352ac680</Hash>
</Codenesium>*/