using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiBreedModel: AbstractModel
	{
		public ApiBreedModel() : base()
		{}

		public ApiBreedModel(
			string name,
			int speciesId)
		{
			this.Name = name;
			this.SpeciesId = speciesId.ToInt();
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

		private int speciesId;

		[Required]
		public int SpeciesId
		{
			get
			{
				return this.speciesId;
			}

			set
			{
				this.speciesId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>ac968f8bf412c4fe8549dc16d4d8a445</Hash>
</Codenesium>*/