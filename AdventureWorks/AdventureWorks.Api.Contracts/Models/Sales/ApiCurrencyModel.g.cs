using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiCurrencyModel: AbstractModel
	{
		public ApiCurrencyModel() : base()
		{}

		public ApiCurrencyModel(
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
    <Hash>12822fc4bb735308b7e3190a67f251e3</Hash>
</Codenesium>*/