using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class StateProvinceModel
	{
		public StateProvinceModel()
		{}
		public StateProvinceModel(string stateProvinceCode,
		                          string countryRegionCode,
		                          bool isOnlyStateProvinceFlag,
		                          string name,
		                          int territoryID,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			this.StateProvinceCode = stateProvinceCode;
			this.CountryRegionCode = countryRegionCode;
			this.IsOnlyStateProvinceFlag = isOnlyStateProvinceFlag;
			this.Name = name;
			this.TerritoryID = territoryID.ToInt();
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string _stateProvinceCode;
		[Required]
		public string StateProvinceCode
		{
			get
			{
				return _stateProvinceCode;
			}
			set
			{
				this._stateProvinceCode = value;
			}
		}

		private string _countryRegionCode;
		[Required]
		public string CountryRegionCode
		{
			get
			{
				return _countryRegionCode;
			}
			set
			{
				this._countryRegionCode = value;
			}
		}

		private bool _isOnlyStateProvinceFlag;
		[Required]
		public bool IsOnlyStateProvinceFlag
		{
			get
			{
				return _isOnlyStateProvinceFlag;
			}
			set
			{
				this._isOnlyStateProvinceFlag = value;
			}
		}

		private string _name;
		[Required]
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				this._name = value;
			}
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
    <Hash>85cffc197cbda6bc0633133d507b011f</Hash>
</Codenesium>*/