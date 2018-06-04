using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class ApiClaspRequestModel: AbstractApiRequestModel
	{
		public ApiClaspRequestModel() : base()
		{}

		public void SetProperties(
			int nextChainId,
			int previousChainId)
		{
			this.NextChainId = nextChainId.ToInt();
			this.PreviousChainId = previousChainId.ToInt();
		}

		private int nextChainId;

		[Required]
		public int NextChainId
		{
			get
			{
				return this.nextChainId;
			}

			set
			{
				this.nextChainId = value;
			}
		}

		private int previousChainId;

		[Required]
		public int PreviousChainId
		{
			get
			{
				return this.previousChainId;
			}

			set
			{
				this.previousChainId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>9840f948d0071f669307b04ceac24823</Hash>
</Codenesium>*/