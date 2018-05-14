using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class ApiOrganizationModel
	{
		public ApiOrganizationModel()
		{}

		public ApiOrganizationModel(
			string name)
		{
			this.Name = name.ToString();
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
    <Hash>27be3354a098421b0d992c3eef4848f3</Hash>
</Codenesium>*/