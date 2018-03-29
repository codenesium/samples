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

		public ProductModelProductDescriptionCultureModel(POCOProductModelProductDescriptionCulture poco)
		{
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();

			this.ProductDescriptionID = poco.ProductDescriptionID.Value.ToInt();
			this.CultureID = poco.CultureID.Value.ToString();
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
    <Hash>339f783a250fed3acc83945e44a5eb42</Hash>
</Codenesium>*/