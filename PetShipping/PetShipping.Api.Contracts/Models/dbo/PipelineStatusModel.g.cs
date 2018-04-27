using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class PipelineStatusModel
	{
		public PipelineStatusModel()
		{}

		public PipelineStatusModel(
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
    <Hash>4d57b999040a758f4fd30159ec1ccc81</Hash>
</Codenesium>*/