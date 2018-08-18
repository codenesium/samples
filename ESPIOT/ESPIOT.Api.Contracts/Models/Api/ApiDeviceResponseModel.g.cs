using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Contracts
{
	public partial class ApiDeviceResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			string name,
			Guid publicId)
		{
			this.Id = id;
			this.Name = name;
			this.PublicId = publicId;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public Guid PublicId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>afe751c663c207b8581c52ff15c1f965</Hash>
</Codenesium>*/