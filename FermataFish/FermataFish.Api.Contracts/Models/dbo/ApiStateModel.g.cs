using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiStateModel: AbstractModel
	{
		public ApiStateModel() : base()
		{}

		public ApiStateModel(
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
    <Hash>20e7f889d3154e15fd99d54c1bfb051c</Hash>
</Codenesium>*/