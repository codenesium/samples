using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ProductDocumentModel
	{
		public ProductDocumentModel()
		{}

		public ProductDocumentModel(
			Guid documentNode,
			DateTime modifiedDate)
		{
			this.DocumentNode = documentNode;
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
    <Hash>728098a4dc0e3430b418d3b36ca7b99c</Hash>
</Codenesium>*/