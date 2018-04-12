using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class JobCandidateModel
	{
		public JobCandidateModel()
		{}

		public JobCandidateModel(
			Nullable<int> businessEntityID,
			string resume,
			DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToNullableInt();
			this.Resume = resume;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private Nullable<int> businessEntityID;

		public Nullable<int> BusinessEntityID
		{
			get
			{
				return this.businessEntityID.IsEmptyOrZeroOrNull() ? null : this.businessEntityID;
			}

			set
			{
				this.businessEntityID = value;
			}
		}

		private string resume;

		public string Resume
		{
			get
			{
				return this.resume.IsEmptyOrZeroOrNull() ? null : this.resume;
			}

			set
			{
				this.resume = value;
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
    <Hash>73c9566d9a7c21ecee1b30918c5468b2</Hash>
</Codenesium>*/