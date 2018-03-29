using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class SalesTerritoryHistoryModel
	{
		public SalesTerritoryHistoryModel()
		{}

		public SalesTerritoryHistoryModel(int territoryID,
		                                  DateTime startDate,
		                                  Nullable<DateTime> endDate,
		                                  Guid rowguid,
		                                  DateTime modifiedDate)
		{
			this.TerritoryID = territoryID.ToInt();
			this.StartDate = startDate.ToDateTime();
			this.EndDate = endDate.ToNullableDateTime();
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public SalesTerritoryHistoryModel(POCOSalesTerritoryHistory poco)
		{
			this.StartDate = poco.StartDate.ToDateTime();
			this.EndDate = poco.EndDate.ToNullableDateTime();
			this.Rowguid = poco.Rowguid;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();

			this.TerritoryID = poco.TerritoryID.Value.ToInt();
		}

		private int _territoryID;
		[Required]
		public int TerritoryID
		{
			get
			{
				return _territoryID;
			}
			set
			{
				this._territoryID = value;
			}
		}

		private DateTime _startDate;
		[Required]
		public DateTime StartDate
		{
			get
			{
				return _startDate;
			}
			set
			{
				this._startDate = value;
			}
		}

		private Nullable<DateTime> _endDate;
		public Nullable<DateTime> EndDate
		{
			get
			{
				return _endDate.IsEmptyOrZeroOrNull() ? null : _endDate;
			}
			set
			{
				this._endDate = value;
			}
		}

		private Guid _rowguid;
		[Required]
		public Guid Rowguid
		{
			get
			{
				return _rowguid;
			}
			set
			{
				this._rowguid = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>7bbc82174fdba26f782835a543a6c69b</Hash>
</Codenesium>*/