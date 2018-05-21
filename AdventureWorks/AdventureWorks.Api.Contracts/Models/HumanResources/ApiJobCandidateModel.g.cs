using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiJobCandidateModel: AbstractModel
	{
		public ApiJobCandidateModel() : base()
		{}

		public ApiJobCandidateModel(
			Nullable<int> businessEntityID,
			DateTime modifiedDate,
			string resume)
		{
			this.BusinessEntityID = businessEntityID.ToNullableInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Resume = resume;
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
	}
}

/*<Codenesium>
    <Hash>1ad0d025d1e37a5b0d43487e1d0f5447</Hash>
</Codenesium>*/