using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductModelIllustrationRequestModel: AbstractApiRequestModel
	{
		public ApiProductModelIllustrationRequestModel() : base()
		{}

		public void SetProperties(
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
    <Hash>07066ea21da86dbb3876671c7521cbbc</Hash>
</Codenesium>*/