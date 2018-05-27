using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class ApiClaspResponseModel: AbstractApiResponseModel
	{
		public ApiClaspResponseModel() : base()
		{}

		public void SetProperties(
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
    <Hash>d5e62e1523e9ef5d379328a9eb6b8c73</Hash>
</Codenesium>*/