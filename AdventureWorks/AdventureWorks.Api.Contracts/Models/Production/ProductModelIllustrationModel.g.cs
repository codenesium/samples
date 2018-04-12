using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ProductModelIllustrationModel
	{
		public ProductModelIllustrationModel()
		{}

		public ProductModelIllustrationModel(
			int illustrationID,
			DateTime modifiedDate)
		{
			this.IllustrationID = illustrationID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private int illustrationID;

		[Required]
		public int IllustrationID
		{
			get
			{
				return this.illustrationID;
			}

			set
			{
				this.illustrationID = value;
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
    <Hash>e1910109f2f92b4f1bf4d3d14505eaf9</Hash>
</Codenesium>*/