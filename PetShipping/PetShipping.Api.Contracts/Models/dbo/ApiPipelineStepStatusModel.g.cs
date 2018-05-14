using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineStepStatusModel
	{
		public ApiPipelineStepStatusModel()
		{}

		public ApiPipelineStepStatusModel(
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
    <Hash>62f00f055c0be79b083380254b63d9bd</Hash>
</Codenesium>*/