using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ProductDescriptionModel
	{
		public ProductDescriptionModel()
		{}

		public ProductDescriptionModel(string description,
		                               Guid rowguid,
		                               DateTime modifiedDate)
		{
			this.Description = description;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public ProductDescriptionModel(POCOProductDescription poco)
		{
			this.Description = poco.Description;
			this.Rowguid = poco.Rowguid;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();
		}

		private string _description;
		[Required]
		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				this._description = value;
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
    <Hash>a1f477be7fa828e3a8cdbfa04e8ed414</Hash>
</Codenesium>*/