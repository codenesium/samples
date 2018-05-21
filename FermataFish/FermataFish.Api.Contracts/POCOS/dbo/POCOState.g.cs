using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class POCOState: AbstractPOCO
	{
		public POCOState() : base()
		{}

		public POCOState(
			int id,
			string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		public int Id { get; set; }
		public string Name { get; set; }

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

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>c054feeacbd6d8c1aa372dfe4add18d1</Hash>
</Codenesium>*/