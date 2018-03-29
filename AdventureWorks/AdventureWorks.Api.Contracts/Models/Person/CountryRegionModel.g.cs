using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class CountryRegionModel
	{
		public CountryRegionModel()
		{}

		public CountryRegionModel(string name,
		                          DateTime modifiedDate)
		{
			this.Name = name;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public CountryRegionModel(POCOCountryRegion poco)
		{
			this.Name = poco.Name;
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
    <Hash>e0de9fa2ba6e17f15f2ba09e83f03513</Hash>
</Codenesium>*/