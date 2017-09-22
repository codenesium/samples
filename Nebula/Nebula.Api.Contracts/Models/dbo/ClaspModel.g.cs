using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data.Entity.Spatial;
namespace NebulaNS.Api.Contracts
{
	public partial class ClaspModel
	{
		public ClaspModel()
		{}

		public ClaspModel(int id,
		                  int nextChainId,
		                  int previousChainId)
		{
			this.Id = id.ToInt();
			this.NextChainId = nextChainId.ToInt();
			this.PreviousChainId = previousChainId.ToInt();
		}

		public ClaspModel(POCOClasp poco)
		{
			this.Id = poco.Id.ToInt();

			NextChainId = poco.NextChainId.Value.ToInt();
			PreviousChainId = poco.PreviousChainId.Value.ToInt();
		}

		private int _id;
		public int Id
		{
			get
			{
				return _id;
			}
			set
			{
				this._id = value;
			}
		}

		private int _nextChainId;
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
    <Hash>35b6265bf8f6c73d34aa06d80ce19ef0</Hash>
</Codenesium>*/