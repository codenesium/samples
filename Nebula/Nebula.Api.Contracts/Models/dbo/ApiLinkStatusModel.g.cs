using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class ApiLinkStatusModel: AbstractModel
	{
		public ApiLinkStatusModel() : base()
		{}

		public ApiLinkStatusModel(
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
    <Hash>f1c6ee11cce7626dfbecbb2f5e6de652</Hash>
</Codenesium>*/