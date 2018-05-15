using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace ESPIOTNS.Api.Contracts
{
	public partial class POCODevice
	{
		public POCODevice()
		{}

		public POCODevice(
			int id,
			string name,
			Guid publicId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.PublicId = publicId.ToGuid();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public Guid PublicId { get; set; }

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
    <Hash>486ee0f5ef702454c79a0a09e9a8544d</Hash>
</Codenesium>*/