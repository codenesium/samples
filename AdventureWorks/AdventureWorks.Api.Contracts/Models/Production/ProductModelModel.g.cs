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

		public ProductModelModel(string name,
		                         string catalogDescription,
		                         string instructions,
		                         Guid rowguid,
		                         DateTime modifiedDate)
		{
			this.Name = name;
			this.CatalogDescription = catalogDescription;
			this.Instructions = instructions;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public ProductModelModel(POCOProductModel poco)
		{
			this.Name = poco.Name;
			this.CatalogDescription = poco.CatalogDescription;
			this.Instructions = poco.Instructions;
			this.Rowguid = poco.Rowguid;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();
		}

		private string _name;
		[Required]
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				this._name = value;
			}
		}

		private string _catalogDescription;
		public string CatalogDescription
		{
			get
			{
				return _catalogDescription.IsEmptyOrZeroOrNull() ? null : _catalogDescription;
			}
			set
			{
				this._catalogDescription = value;
			}
		}

		private string _instructions;
		public string Instructions
		{
			get
			{
				return _instructions.IsEmptyOrZeroOrNull() ? null : _instructions;
			}
			set
			{
				this._instructions = value;
			}
		}

		private Guid _rowguid;
		[Required]
		public Guid Rowguid
		{
			get
			{
				return _rowguid;
			}
			set
			{
				this._rowguid = value;
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
    <Hash>d5c1c23dfe43f0e21fac313b1cb8405c</Hash>
</Codenesium>*/