using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
	public partial class ApiLinkLogServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			DateTime dateEntered,
			int linkId,
			string log)
		{
			this.Id = id;
			this.DateEntered = dateEntered;
			this.LinkId = linkId;
			this.Log = log;
		}

		[JsonProperty]
		public DateTime DateEntered { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int LinkId { get; private set; }

		[JsonProperty]
		public string LinkIdEntity { get; private set; } = RouteConstants.Links;

		[JsonProperty]
		public ApiLinkServerResponseModel LinkIdNavigation { get; private set; }

		public void SetLinkIdNavigation(ApiLinkServerResponseModel value)
		{
			this.LinkIdNavigation = value;
		}

		[JsonProperty]
		public string Log { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3d2bfec062b2333715485797332f0df9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/