using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class OrganizationModel
	{
		public OrganizationModel()
		{}

		public OrganizationModel(
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
    <Hash>5e02ac7c787f82926fe4088517bdeb6b</Hash>
</Codenesium>*/