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

		public StateProvinceModel(
			string stateProvinceCode,
			string countryRegionCode,
			bool isOnlyStateProvinceFlag,
			string name,
			int territoryID,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.StateProvinceCode = stateProvinceCode.ToString();
			this.CountryRegionCode = countryRegionCode.ToString();
			this.IsOnlyStateProvinceFlag = isOnlyStateProvinceFlag.ToBoolean();
			this.Name = name.ToString();
			this.TerritoryID = territoryID.ToInt();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string stateProvinceCode;

		[Required]
		public string StateProvinceCode
		{
			get
			{
				return this.stateProvinceCode;
			}

			set
			{
				this.stateProvinceCode = value;
			}
		}

		private string countryRegionCode;

		[Required]
		public string CountryRegionCode
		{
			get
			{
				return this.countryRegionCode;
			}

			set
			{
				this.countryRegionCode = value;
			}
		}

		private bool isOnlyStateProvinceFlag;

		[Required]
		public bool IsOnlyStateProvinceFlag
		{
			get
			{
				return this.isOnlyStateProvinceFlag;
			}

			set
			{
				this.isOnlyStateProvinceFlag = value;
			}
		}

		private string name;

		[Required]
		public string Name
		{
			get
			{
				return this.name;
			}

			set
			{
				this.name = value;
			}
		}

		private int territoryID;

		[Required]
		public int TerritoryID
		{
			get
			{
				return this.territoryID;
			}

			set
			{
				this.territoryID = value;
			}
		}

		private Guid rowguid;

		[Required]
		public Guid Rowguid
		{
			get
			{
				return this.rowguid;
			}

			set
			{
				this.rowguid = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>0195bc6d2838b684d3ae48cdf2c30232</Hash>
</Codenesium>*/