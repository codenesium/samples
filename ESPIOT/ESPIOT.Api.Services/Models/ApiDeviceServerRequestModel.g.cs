using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Services
{
	public partial class ApiDeviceServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiDeviceServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime dateOfLastPing,
			bool isActive,
			string name,
			Guid publicId)
		{
			this.DateOfLastPing = dateOfLastPing;
			this.IsActive = isActive;
			this.Name = name;
			this.PublicId = publicId;
		}

		[Required]
		[JsonProperty]
		public DateTime DateOfLastPing { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public bool IsActive { get; private set; } = default(bool);

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public Guid PublicId { get; private set; } = default(Guid);
	}
}

/*<Codenesium>
    <Hash>38951712b07ad59406fadf505b58e68e</Hash>
</Codenesium>*/