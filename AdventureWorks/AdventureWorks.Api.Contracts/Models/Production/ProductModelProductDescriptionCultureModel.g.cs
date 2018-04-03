using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ProductModelProductDescriptionCultureModel
	{
		public ProductModelProductDescriptionCultureModel()
		{}
		public ProductModelProductDescriptionCultureModel(int productDescriptionID,
		                                                  string cultureID,
		                                                  DateTime modifiedDate)
		{
			this.ProductDescriptionID = productDescriptionID.ToInt();
			this.CultureID = cultureID;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private int _productDescriptionID;
		[Required]
		public int ProductDescriptionID
		{
			get
			{
				return _productDescriptionID;
			}
			set
			{
				this._productDescriptionID = value;
			}
		}

		private string _cultureID;
		[Required]
		public string CultureID
		{
			get
			{
				return _cultureID;
			}
			set
			{
				this._cultureID = value;
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
    <Hash>953145ec7b6b92db7f9d1708fcf46974</Hash>
</Codenesium>*/