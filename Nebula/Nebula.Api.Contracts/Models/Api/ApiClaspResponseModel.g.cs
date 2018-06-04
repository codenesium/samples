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
			this.NextChainId = nextChainId.ToInt();
			this.PreviousChainId = previousChainId.ToInt();

			this.NextChainIdEntity = nameof(ApiResponse.Chains);
			this.PreviousChainIdEntity = nameof(ApiResponse.Chains);
		}

		public int Id { get; private set; }
		public int NextChainId { get; private set; }
		public string NextChainIdEntity { get; set; }
		public int PreviousChainId { get; private set; }
		public string PreviousChainIdEntity { get; set; }

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
    <Hash>9599c26b2501a7a993a539f4334e3152</Hash>
</Codenesium>*/