using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductModelIllustrationModel: AbstractModel
	{
		public ApiProductModelIllustrationModel() : base()
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
    <Hash>403a300011dbb0ae4fc8485559837b8a</Hash>
</Codenesium>*/