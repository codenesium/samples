using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class UnitMeasureModel
	{
		public UnitMeasureModel()
		{}

		public UnitMeasureModel(string name,
		                        DateTime modifiedDate)
		{
			this.Name = name;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public UnitMeasureModel(POCOUnitMeasure poco)
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
    <Hash>6465019a48b36d7c1d0ffba53d5b7665</Hash>
</Codenesium>*/