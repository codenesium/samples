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

		public ClaspModel(POCOClasp poco)
		{
			this.PreviousChainId = poco.PreviousChainId.Value.ToInt();
			this.NextChainId = poco.NextChainId.Value.ToInt();
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
    <Hash>2aabe65b38a18e62709301675d8bc74a</Hash>
</Codenesium>*/