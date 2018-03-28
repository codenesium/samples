using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace ESPIOTNS.Api.Contracts
{
	public partial class POCODevice
	{
		public POCODevice()
		{}

		public POCODevice(int id,
		                  Guid publicId,
		                  string name)
		{
			this.Id = id.ToInt();
			this.PublicId = publicId;
			this.Name = name;
		}

		public int Id {get; set;}
		public Guid PublicId {get; set;}
		public string Name {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeIdValue {get; set;} = true;

		public bool ShouldSerializeId()
		{
			return ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePublicIdValue {get; set;} = true;

		public bool ShouldSerializePublicId()
		{
			return ShouldSerializePublicIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
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
    <Hash>92a1bc6521239ab69a92441a0d168ea7</Hash>
</Codenesium>*/