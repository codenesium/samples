using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductProductPhotoModel
	{
		public ApiProductProductPhotoModel()
		{}

		public ApiProductProductPhotoModel(
			DateTime modifiedDate,
			bool primary,
			int productPhotoID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Primary = primary.ToBoolean();
			this.ProductPhotoID = productPhotoID.ToInt();
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
	}
}

/*<Codenesium>
    <Hash>251d896f2e697a06e42ed34d3f87060e</Hash>
</Codenesium>*/