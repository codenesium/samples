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

		public StateProvinceModel(POCOStateProvince poco)
		{
			this.StateProvinceCode = poco.StateProvinceCode;
			this.IsOnlyStateProvinceFlag = poco.IsOnlyStateProvinceFlag;
			this.Name = poco.Name;
			this.Rowguid = poco.Rowguid;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();

			this.CountryRegionCode = poco.CountryRegionCode.Value.ToString();
			this.TerritoryID = poco.TerritoryID.Value.ToInt();
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
    <Hash>18fdf7e3ad09e82f8862741d12a3f668</Hash>
</Codenesium>*/