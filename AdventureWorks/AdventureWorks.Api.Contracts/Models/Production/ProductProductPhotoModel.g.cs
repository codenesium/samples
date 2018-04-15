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

		public ProductProductPhotoModel(
			int productPhotoID,
			bool primary,
			DateTime modifiedDate)
		{
			this.ProductPhotoID = productPhotoID.ToInt();
			this.Primary = primary.ToBoolean();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private int productPhotoID;

		[Required]
		public int ProductPhotoID
		{
			get
			{
				return this.productPhotoID;
			}

			set
			{
				this.productPhotoID = value;
			}
		}

		private bool primary;

		[Required]
		public bool Primary
		{
			get
			{
				return this.primary;
			}

			set
			{
				this.primary = value;
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
    <Hash>2b57bb4ab5ab41465795cb44a0503615</Hash>
</Codenesium>*/