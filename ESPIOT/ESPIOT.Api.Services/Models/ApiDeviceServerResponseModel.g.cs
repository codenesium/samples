using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Services
{
	public partial class ApiDeviceServerResponseModel : AbstractApiServerResponseModel
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
    <Hash>82a149f4f3f586439dca4ca734c9726d</Hash>
</Codenesium>*/