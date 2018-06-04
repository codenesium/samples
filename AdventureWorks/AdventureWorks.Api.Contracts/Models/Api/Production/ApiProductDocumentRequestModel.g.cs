using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductDocumentRequestModel: AbstractApiRequestModel
	{
		public ApiProductDocumentRequestModel() : base()
		{}

		public void SetProperties(
			Guid documentNode,
			DateTime modifiedDate)
		{
			this.DocumentNode = documentNode.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private Guid documentNode;

		[Required]
		public Guid DocumentNode
		{
			get
			{
				return this.documentNode;
			}

			set
			{
				this.documentNode = value;
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
    <Hash>22f3afe04d7b8cf5e97a527037a0cbc0</Hash>
</Codenesium>*/