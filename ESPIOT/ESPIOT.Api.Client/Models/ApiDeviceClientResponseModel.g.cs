using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Client
{
	public partial class ApiDeviceClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			DateTime dateOfLastPing,
			bool isActive,
			string name,
			Guid publicId)
		{
			this.Id = id;
			this.DateOfLastPing = dateOfLastPing;
			this.IsActive = isActive;
			this.Name = name;
			this.PublicId = publicId;
		}

		[JsonProperty]
		public DateTime DateOfLastPing { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public bool IsActive { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public Guid PublicId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f74adb5299b63dfb94f69414a5b2ad05</Hash>
</Codenesium>*/