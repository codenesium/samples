using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace ESPIOTNS.Api.Contracts
{
	public partial class POCODevice: AbstractPOCO
	{
		public POCODevice() : base()
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
    <Hash>f09af2ecac6aaac9d1e6810e0e42b904</Hash>
</Codenesium>*/