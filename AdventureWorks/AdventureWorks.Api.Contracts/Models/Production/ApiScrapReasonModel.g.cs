using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiScrapReasonModel: AbstractModel
	{
		public ApiScrapReasonModel() : base()
		{}

		public ApiScrapReasonModel(
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
    <Hash>2852adf8eaca8c296f3b240454056c05</Hash>
</Codenesium>*/