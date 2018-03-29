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

		public JobCandidateModel(Nullable<int> businessEntityID,
		                         string resume,
		                         DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToNullableInt();
			this.Resume = resume;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public JobCandidateModel(POCOJobCandidate poco)
		{
			this.Resume = poco.Resume;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();

			this.BusinessEntityID = poco.BusinessEntityID.Value.ToInt();
		}

		private Nullable<int> _businessEntityID;
		public Nullable<int> BusinessEntityID
		{
			get
			{
				return _businessEntityID.IsEmptyOrZeroOrNull() ? null : _businessEntityID;
			}
			set
			{
				this._businessEntityID = value;
			}
		}

		private string _resume;
		public string Resume
		{
			get
			{
				return _resume.IsEmptyOrZeroOrNull() ? null : _resume;
			}
			set
			{
				this._resume = value;
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
    <Hash>824b65565b18cd324a7bf3b19d2a2729</Hash>
</Codenesium>*/