using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiSpeciesRequestModel: AbstractApiRequestModel
	{
		public ApiSpeciesRequestModel() : base()
		{}

		public void SetProperties(
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
    <Hash>d7cffe02a9a76f76afe4bea54c13b19a</Hash>
</Codenesium>*/