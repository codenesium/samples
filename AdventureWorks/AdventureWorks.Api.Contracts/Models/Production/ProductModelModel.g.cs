using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ProductModelModel
	{
		public ProductModelModel()
		{}

		public ProductModelModel(
			string name,
			string catalogDescription,
			string instructions,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.Name = name.ToString();
			this.CatalogDescription = catalogDescription;
			this.Instructions = instructions;
			this.Rowguid = rowguid.ToGuid();
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

		private string catalogDescription;

		public string CatalogDescription
		{
			get
			{
				return this.catalogDescription.IsEmptyOrZeroOrNull() ? null : this.catalogDescription;
			}

			set
			{
				this.catalogDescription = value;
			}
		}

		private string instructions;

		public string Instructions
		{
			get
			{
				return this.instructions.IsEmptyOrZeroOrNull() ? null : this.instructions;
			}

			set
			{
				this.instructions = value;
			}
		}

		private Guid rowguid;

		[Required]
		public Guid Rowguid
		{
			get
			{
				return this.rowguid;
			}

			set
			{
				this.rowguid = value;
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
    <Hash>d41054982d0dd70eea4284c27afee0a1</Hash>
</Codenesium>*/