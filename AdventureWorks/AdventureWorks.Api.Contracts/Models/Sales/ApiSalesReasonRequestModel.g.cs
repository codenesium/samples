using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesReasonRequestModel: AbstractApiRequestModel
	{
		public ApiSalesReasonRequestModel() : base()
		{}

		public void SetProperties(
			DateTime modifiedDate,
			string name,
			string reasonType)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.ReasonType = reasonType;
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

		private string name;

		[Required]
		public string Name
		{
			get
			{
				return this.name;
			}

			set
			{
				this.name = value;
			}
		}

		private string reasonType;

		[Required]
		public string ReasonType
		{
			get
			{
				return this.reasonType;
			}

			set
			{
				this.reasonType = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>739448b61c2c539bd337a6c4040212ff</Hash>
</Codenesium>*/