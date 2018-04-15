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
			Guid publicId,
			string name)
		{
			this.Id = id.ToInt();
			this.PublicId = publicId.ToGuid();
			this.Name = name.ToString();
		}

		public int Id { get; set; }
		public Guid PublicId { get; set; }
		public string Name { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePublicIdValue { get; set; } = true;

		public bool ShouldSerializePublicId()
		{
			return this.ShouldSerializePublicIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializePublicIdValue = false;
			this.ShouldSerializeNameValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>cd7fd9c70017b6ab0da82c51986a6614</Hash>
</Codenesium>*/