using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineStepStatusRequestModel: AbstractApiRequestModel
	{
		public ApiPipelineStepStatusRequestModel() : base()
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
    <Hash>a6f52f150f6696520727b7d830d76c08</Hash>
</Codenesium>*/