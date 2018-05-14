using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class ApiLinkStatusModel
	{
		public ApiLinkStatusModel()
		{}

		public ApiLinkStatusModel(
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
    <Hash>40d7a965eca6b4d08e4290b522f660da</Hash>
</Codenesium>*/