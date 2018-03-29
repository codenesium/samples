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

		public ProductDocumentModel(POCOProductDocument poco)
		{
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();

			this.DocumentNode = poco.DocumentNode.Value.ToGuid();
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
    <Hash>c0fccae415ad643edf9fa272beb6a5db</Hash>
</Codenesium>*/