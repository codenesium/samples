using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NebulaNS.Api.Contracts
{
	public partial class POCOClasp
	{
		public POCOClasp()
		{}

		public POCOClasp(int id,
		                 int nextChainId,
		                 int previousChainId)
		{
			this.Id = id.ToInt();

			NextChainId = new ReferenceEntity<int>(nextChainId,
			                                       "Chain");
			PreviousChainId = new ReferenceEntity<int>(previousChainId,
			                                           "Chain");
		}

		public int Id {get; set;}
		public ReferenceEntity<int>NextChainId {get; set;}
		public ReferenceEntity<int>PreviousChainId {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeIdValue {get; set;} = true;

		public bool ShouldSerializeId()
		{
			return ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNextChainIdValue {get; set;} = true;

		public bool ShouldSerializeNextChainId()
		{
			return ShouldSerializeNextChainIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePreviousChainIdValue {get; set;} = true;

		public bool ShouldSerializePreviousChainId()
		{
			return ShouldSerializePreviousChainIdValue;
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
    <Hash>16b5516a4733cc7fc642d8a123e913b8</Hash>
</Codenesium>*/