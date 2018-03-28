using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class POCOClasp
	{
		public POCOClasp()
		{}

		public POCOClasp(int id,
		                 int previousChainId,
		                 int nextChainId)
		{
			this.Id = id.ToInt();

			PreviousChainId = new ReferenceEntity<int>(previousChainId,
			                                           "Chain");
			NextChainId = new ReferenceEntity<int>(nextChainId,
			                                       "Chain");
		}

		public int Id {get; set;}
		public ReferenceEntity<int>PreviousChainId {get; set;}
		public ReferenceEntity<int>NextChainId {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeIdValue {get; set;} = true;

		public bool ShouldSerializeId()
		{
			return ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePreviousChainIdValue {get; set;} = true;

		public bool ShouldSerializePreviousChainId()
		{
			return ShouldSerializePreviousChainIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNextChainIdValue {get; set;} = true;

		public bool ShouldSerializeNextChainId()
		{
			return ShouldSerializeNextChainIdValue;
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
    <Hash>9c69c3ff9286b35d8adf0d6d253dc6c8</Hash>
</Codenesium>*/