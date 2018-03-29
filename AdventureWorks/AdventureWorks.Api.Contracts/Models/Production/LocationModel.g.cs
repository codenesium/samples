using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class LocationModel
	{
		public LocationModel()
		{}

		public LocationModel(string name,
		                     decimal costRate,
		                     decimal availability,
		                     DateTime modifiedDate)
		{
			this.Name = name;
			this.CostRate = costRate;
			this.Availability = availability.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public LocationModel(POCOLocation poco)
		{
			this.Name = poco.Name;
			this.CostRate = poco.CostRate;
			this.Availability = poco.Availability.ToDecimal();
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();
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

		private decimal _costRate;
		[Required]
		public decimal CostRate
		{
			get
			{
				return _costRate;
			}
			set
			{
				this._costRate = value;
			}
		}

		private decimal _availability;
		[Required]
		public decimal Availability
		{
			get
			{
				return _availability;
			}
			set
			{
				this._availability = value;
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
    <Hash>158841d074a972bd6e022b6e8588d95a</Hash>
</Codenesium>*/