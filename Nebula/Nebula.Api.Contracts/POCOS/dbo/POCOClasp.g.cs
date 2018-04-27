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
			int nextChainId,
			int previousChainId)
		{
			this.Id = id.ToInt();

			this.NextChainId = new ReferenceEntity<int>(nextChainId,
			                                            nameof(ApiResponse.Chains));
			this.PreviousChainId = new ReferenceEntity<int>(previousChainId,
			                                                nameof(ApiResponse.Chains));
		}

		public int Id { get; set; }
		public ReferenceEntity<int> NextChainId { get; set; }
		public ReferenceEntity<int> PreviousChainId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNextChainIdValue { get; set; } = true;

		public bool ShouldSerializeNextChainId()
		{
			return this.ShouldSerializeNextChainIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePreviousChainIdValue { get; set; } = true;

		public bool ShouldSerializePreviousChainId()
		{
			return this.ShouldSerializePreviousChainIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNextChainIdValue = false;
			this.ShouldSerializePreviousChainIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>a3bcce6e11f3f7c0428f0e3d28142dce</Hash>
</Codenesium>*/