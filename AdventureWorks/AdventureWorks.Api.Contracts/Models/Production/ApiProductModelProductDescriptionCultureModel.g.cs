using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductModelProductDescriptionCultureModel
	{
		public ApiProductModelProductDescriptionCultureModel()
		{}

		public ApiProductModelProductDescriptionCultureModel(
			string cultureID,
			DateTime modifiedDate,
			int productDescriptionID)
		{
			this.CultureID = cultureID.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductDescriptionID = productDescriptionID.ToInt();
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
	}
}

/*<Codenesium>
    <Hash>58de4ec8bc7fbac9f902efb9944167ad</Hash>
</Codenesium>*/