using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace ESPIOTNS.Api.Contracts
{
	public partial class ApiDeviceResponseModel: AbstractApiResponseModel
	{
		public ApiDeviceResponseModel() : base()
		{}

		public void SetProperties(
			int id,
			string name,
			Guid publicId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.PublicId = publicId.ToGuid();
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public Guid PublicId { get; private set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePublicIdValue { get; set; } = true;

		public bool ShouldSerializePublicId()
		{
			return this.ShouldSerializePublicIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializePublicIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>30196c2c412516ecb13894391bd6d760</Hash>
</Codenesium>*/