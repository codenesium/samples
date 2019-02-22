using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiNoteClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiNoteClientRequestModel()
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

		[JsonProperty]
		public int CallId { get; private set; }

		[JsonProperty]
		public DateTime DateCreated { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string NoteText { get; private set; } = default(string);

		[JsonProperty]
		public int OfficerId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fb65bb29c74d8eeb71c6f64156ae00a9</Hash>
</Codenesium>*/