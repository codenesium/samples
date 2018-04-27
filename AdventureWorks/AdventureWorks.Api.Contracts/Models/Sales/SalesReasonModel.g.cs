using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class SalesReasonModel
	{
		public SalesReasonModel()
		{}

		public SalesReasonModel(
			DateTime modifiedDate,
			string name,
			string reasonType)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.ReasonType = reasonType.ToString();
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
    <Hash>3d47e2c6dbfbad97c459b7f071166e1d</Hash>
</Codenesium>*/