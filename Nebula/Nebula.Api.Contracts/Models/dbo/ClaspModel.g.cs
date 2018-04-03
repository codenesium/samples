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
		public ClaspModel(int previousChainId,
		                  int nextChainId)
		{
			this.PreviousChainId = previousChainId.ToInt();
			this.NextChainId = nextChainId.ToInt();
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
	}
}

/*<Codenesium>
    <Hash>c753e4c1e1ffd2589cdb15226edd7899</Hash>
</Codenesium>*/