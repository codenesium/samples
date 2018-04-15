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

		public ProductModelProductDescriptionCultureModel(
			int productDescriptionID,
			string cultureID,
			DateTime modifiedDate)
		{
			this.ProductDescriptionID = productDescriptionID.ToInt();
			this.CultureID = cultureID.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private int productDescriptionID;

		[Required]
		public int ProductDescriptionID
		{
			get
			{
				return this.productDescriptionID;
			}

			set
			{
				this.productDescriptionID = value;
			}
		}

		private string cultureID;

		[Required]
		public string CultureID
		{
			get
			{
				return this.cultureID;
			}

			set
			{
				this.cultureID = value;
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
    <Hash>b0e7728f8d26d3d4b68d6cd083fe23a9</Hash>
</Codenesium>*/