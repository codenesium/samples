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
		public ProductDocumentModel(Guid documentNode,
		                            DateTime modifiedDate)
		{
			this.DocumentNode = documentNode;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private Guid _documentNode;
		[Required]
		public Guid DocumentNode
		{
			get
			{
				return _documentNode;
			}
			set
			{
				this._documentNode = value;
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
    <Hash>a885d55b2a5cb156c1a48e50648c3ed3</Hash>
</Codenesium>*/