using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductModelModel: AbstractModel
	{
		public ApiProductModelModel() : base()
		{}

		public ApiProductModelModel(
			string catalogDescription,
			string instructions,
			DateTime modifiedDate,
			string name,
			Guid rowguid)
		{
			this.CatalogDescription = catalogDescription;
			this.Instructions = instructions;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.Rowguid = rowguid.ToGuid();
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
	}
}

/*<Codenesium>
    <Hash>2e62ee579987a425c7be500d93b929da</Hash>
</Codenesium>*/