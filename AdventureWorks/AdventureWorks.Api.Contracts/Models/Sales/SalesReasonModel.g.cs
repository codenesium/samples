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
			string name,
			string reasonType,
			DateTime modifiedDate)
		{
			this.Name = name.ToString();
			this.ReasonType = reasonType.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
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
    <Hash>a69087ea5f59437662317eea3999cfd8</Hash>
</Codenesium>*/