using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ProductSubcategoryModel
	{
		public ProductSubcategoryModel()
		{}

		public ProductSubcategoryModel(int productCategoryID,
		                               string name,
		                               Guid rowguid,
		                               DateTime modifiedDate)
		{
			this.ProductCategoryID = productCategoryID.ToInt();
			this.Name = name;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public ProductSubcategoryModel(POCOProductSubcategory poco)
		{
			this.Name = poco.Name;
			this.Rowguid = poco.Rowguid;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();

			this.ProductCategoryID = poco.ProductCategoryID.Value.ToInt();
		}

		private int _productCategoryID;
		[Required]
		public int ProductCategoryID
		{
			get
			{
				return _productCategoryID;
			}
			set
			{
				this._productCategoryID = value;
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
    <Hash>9dfafe8ee25898f52beb09d5ba5c0e28</Hash>
</Codenesium>*/