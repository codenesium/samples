using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiNoteServerResponseModel : AbstractApiServerResponseModel
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
		}

		[JsonProperty]
		public int CallId { get; private set; }

		[JsonProperty]
		public string CallIdEntity { get; private set; } = RouteConstants.Calls;

		[JsonProperty]
		public ApiCallServerResponseModel CallIdNavigation { get; private set; }

		public void SetCallIdNavigation(ApiCallServerResponseModel value)
		{
			this.CallIdNavigation = value;
		}

		[JsonProperty]
		public DateTime DateCreated { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string NoteText { get; private set; }

		[JsonProperty]
		public int OfficerId { get; private set; }

		[JsonProperty]
		public string OfficerIdEntity { get; private set; } = RouteConstants.Officers;

		[JsonProperty]
		public ApiOfficerServerResponseModel OfficerIdNavigation { get; private set; }

		public void SetOfficerIdNavigation(ApiOfficerServerResponseModel value)
		{
			this.OfficerIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>baad895cfcf00f23f5f3dbcf2d54fd5f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/