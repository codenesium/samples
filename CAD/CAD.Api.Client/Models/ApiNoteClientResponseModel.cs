using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiNoteClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int callId,
			DateTime dateCreated,
			string noteText,
			int officerId)
		{
			this.Id = id;
			this.CallId = callId;
			this.DateCreated = dateCreated;
			this.NoteText = noteText;
			this.OfficerId = officerId;

			this.CallIdEntity = nameof(ApiResponse.Calls);

			this.OfficerIdEntity = nameof(ApiResponse.Officers);
		}

		[JsonProperty]
		public ApiCallClientResponseModel CallIdNavigation { get; private set; }

		public void SetCallIdNavigation(ApiCallClientResponseModel value)
		{
			this.CallIdNavigation = value;
		}

		[JsonProperty]
		public ApiOfficerClientResponseModel OfficerIdNavigation { get; private set; }

		public void SetOfficerIdNavigation(ApiOfficerClientResponseModel value)
		{
			this.OfficerIdNavigation = value;
		}

		[JsonProperty]
		public int CallId { get; private set; }

		[JsonProperty]
		public string CallIdEntity { get; set; }

		[JsonProperty]
		public DateTime DateCreated { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string NoteText { get; private set; }

		[JsonProperty]
		public int OfficerId { get; private set; }

		[JsonProperty]
		public string OfficerIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>98391198a42d64e75944a60ce0702c98</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/