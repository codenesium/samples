using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class ApiClaspModel: AbstractModel
	{
		public ApiClaspModel() : base()
		{}

		public ApiClaspModel(
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
    <Hash>c5637ccde2564c68a642b4d91f76d96a</Hash>
</Codenesium>*/