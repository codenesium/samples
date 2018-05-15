using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetStoreNS.Api.Contracts
{
	public partial class ApiPaymentTypeModel
	{
		public ApiPaymentTypeModel()
		{}

		public ApiPaymentTypeModel(
			string name)
		{
			this.Name = name;
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
    <Hash>2efefe7cd41bfb7d57c5dcffca1b8ce5</Hash>
</Codenesium>*/