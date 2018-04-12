using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class POCOClasp
	{
		public POCOClasp()
		{}

		public POCOClasp(
			int id,
			int previousChainId,
			int nextChainId)
		{
			this.Id = id.ToInt();

			this.PreviousChainId = new ReferenceEntity<int>(previousChainId,
			                                                "Chain");
			this.NextChainId = new ReferenceEntity<int>(nextChainId,
			                                            "Chain");
		}

		public int Id { get; set; }
		public ReferenceEntity<int> PreviousChainId { get; set; }
		public ReferenceEntity<int> NextChainId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePreviousChainIdValue { get; set; } = true;

		public bool ShouldSerializePreviousChainId()
		{
			return this.ShouldSerializePreviousChainIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNextChainIdValue { get; set; } = true;

		public bool ShouldSerializeNextChainId()
		{
			return this.ShouldSerializeNextChainIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializePreviousChainIdValue = false;
			this.ShouldSerializeNextChainIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>b4004dfb927f556e09671a40de464d40</Hash>
</Codenesium>*/