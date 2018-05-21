using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiCultureModel: AbstractModel
	{
		public ApiCultureModel() : base()
		{}

		public ApiCultureModel(
			DateTime modifiedDate,
			string name)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
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
	}
}

/*<Codenesium>
    <Hash>576b70944e6c636bf117c6ef59f372ef</Hash>
</Codenesium>*/