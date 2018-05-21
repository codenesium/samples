using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class ApiChainStatusModel: AbstractModel
	{
		public ApiChainStatusModel() : base()
		{}

		public ApiChainStatusModel(
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
    <Hash>10b3e13f3d87c752a324f115806dd205</Hash>
</Codenesium>*/