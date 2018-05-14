using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductModelIllustrationModel
	{
		public ApiProductModelIllustrationModel()
		{}

		public ApiProductModelIllustrationModel(
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
    <Hash>23619071cd01e13ca2444c631711d002</Hash>
</Codenesium>*/