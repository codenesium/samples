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
		public ProductModelIllustrationModel(int illustrationID,
		                                     DateTime modifiedDate)
		{
			this.IllustrationID = illustrationID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private int _illustrationID;
		[Required]
		public int IllustrationID
		{
			get
			{
				return _illustrationID;
			}
			set
			{
				this._illustrationID = value;
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
    <Hash>23a1b8b0b17ef8ea9a21de2be1359183</Hash>
</Codenesium>*/