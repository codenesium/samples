using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class ClaspModel
	{
		public ClaspModel()
		{}

		public ClaspModel(
			int previousChainId,
			int nextChainId)
		{
			this.PreviousChainId = previousChainId.ToInt();
			this.NextChainId = nextChainId.ToInt();
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
	}
}

/*<Codenesium>
    <Hash>fe6ba6e1d59668f9d74573dd74bdf1bc</Hash>
</Codenesium>*/