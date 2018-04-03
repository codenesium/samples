using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ProductProductPhotoModel
	{
		public ProductProductPhotoModel()
		{}
		public ProductProductPhotoModel(int productPhotoID,
		                                bool primary,
		                                DateTime modifiedDate)
		{
			this.ProductPhotoID = productPhotoID.ToInt();
			this.Primary = primary;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private int _productPhotoID;
		[Required]
		public int ProductPhotoID
		{
			get
			{
				return _productPhotoID;
			}
			set
			{
				this._productPhotoID = value;
			}
		}

		private bool _primary;
		[Required]
		public bool Primary
		{
			get
			{
				return _primary;
			}
			set
			{
				this._primary = value;
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
    <Hash>c5af49c233459107e2118234a98237a2</Hash>
</Codenesium>*/