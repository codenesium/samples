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

		public ClaspModel(int nextChainId,
		                  int previousChainId)
		{
			this.NextChainId = nextChainId.ToInt();
			this.PreviousChainId = previousChainId.ToInt();
		}

		public ClaspModel(POCOClasp poco)
		{
			this.NextChainId = poco.NextChainId.Value.ToInt();
			this.PreviousChainId = poco.PreviousChainId.Value.ToInt();
		}

		private int _nextChainId;
		[Required]
		public int NextChainId
		{
			get
			{
				return _nextChainId;
			}
			set
			{
				this._nextChainId = value;
			}
		}

		private int _previousChainId;
		[Required]
		public int PreviousChainId
		{
			get
			{
				return _previousChainId;
			}
			set
			{
				this._previousChainId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>e1f533df5f3df3fa3392505e055e1df6</Hash>
</Codenesium>*/