using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class BreedModel
	{
		public BreedModel()
		{}

		public BreedModel(
			string name,
			int speciesId)
		{
			this.Name = name.ToString();
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
    <Hash>2a9b0e30cc5b5fd885c5a40d8349e663</Hash>
</Codenesium>*/