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
			                                                nameof(ApiResponse.Chains));
			this.NextChainId = new ReferenceEntity<int>(nextChainId,
			                                            nameof(ApiResponse.Chains));
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
    <Hash>6d919eec645870e512acb3a0c2358145</Hash>
</Codenesium>*/