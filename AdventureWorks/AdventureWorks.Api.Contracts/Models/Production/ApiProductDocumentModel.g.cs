using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductDocumentModel: AbstractModel
	{
		public ApiProductDocumentModel() : base()
		{}

		public ApiProductDocumentModel(
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
    <Hash>8a270a2aacd918b85281f689ce174244</Hash>
</Codenesium>*/