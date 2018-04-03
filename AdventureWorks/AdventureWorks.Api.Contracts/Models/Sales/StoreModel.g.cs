using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class StoreModel
	{
		public StoreModel()
		{}
		public StoreModel(string name,
		                  Nullable<int> salesPersonID,
		                  string demographics,
		                  Guid rowguid,
		                  DateTime modifiedDate)
		{
			this.Name = name;
			this.SalesPersonID = salesPersonID.ToNullableInt();
			this.Demographics = demographics;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
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

		private Nullable<int> _salesPersonID;
		public Nullable<int> SalesPersonID
		{
			get
			{
				return _salesPersonID.IsEmptyOrZeroOrNull() ? null : _salesPersonID;
			}
			set
			{
				this._salesPersonID = value;
			}
		}

		private string _demographics;
		public string Demographics
		{
			get
			{
				return _demographics.IsEmptyOrZeroOrNull() ? null : _demographics;
			}
			set
			{
				this._demographics = value;
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
    <Hash>1c9a720a76d1e352ff0003604eaa4ad9</Hash>
</Codenesium>*/