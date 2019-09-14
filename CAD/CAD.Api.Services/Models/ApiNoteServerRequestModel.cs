using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiNoteServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiNoteServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int callId,
			DateTime dateCreated,
			string noteText,
			int officerId)
		{
			this.CallId = callId;
			this.DateCreated = dateCreated;
			this.NoteText = noteText;
			this.OfficerId = officerId;
		}

		[Required]
		[JsonProperty]
		public int CallId { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime DateCreated { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string NoteText { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int OfficerId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>71c9a5b9388adb5a5d0fbb27039e70b6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/