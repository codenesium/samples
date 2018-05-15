using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductDocumentModel
	{
		public ApiProductDocumentModel()
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
    <Hash>8a4b18ce81ab5c5af1c46b18ae5aa6a7</Hash>
</Codenesium>*/