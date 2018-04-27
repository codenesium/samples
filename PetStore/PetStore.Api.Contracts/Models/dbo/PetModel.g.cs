using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetStoreNS.Api.Contracts
{
	public partial class PetModel
	{
		public PetModel()
		{}

		public PetModel(
			DateTime acquiredDate,
			int breedId,
			string description,
			int penId,
			decimal price,
			int speciesId)
		{
			this.AcquiredDate = acquiredDate.ToDateTime();
			this.BreedId = breedId.ToInt();
			this.Description = description.ToString();
			this.PenId = penId.ToInt();
			this.Price = price.ToDecimal();
			this.SpeciesId = speciesId.ToInt();
		}

		private DateTime acquiredDate;

		[Required]
		public DateTime AcquiredDate
		{
			get
			{
				return this.acquiredDate;
			}

			set
			{
				this.acquiredDate = value;
			}
		}

		private int breedId;

		[Required]
		public int BreedId
		{
			get
			{
				return this.breedId;
			}

			set
			{
				this.breedId = value;
			}
		}

		private string description;

		[Required]
		public string Description
		{
			get
			{
				return this.description;
			}

			set
			{
				this.description = value;
			}
		}

		private int penId;

		[Required]
		public int PenId
		{
			get
			{
				return this.penId;
			}

			set
			{
				this.penId = value;
			}
		}

		private decimal price;

		[Required]
		public decimal Price
		{
			get
			{
				return this.price;
			}

			set
			{
				this.price = value;
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
    <Hash>28000b71d577b3e5f0e5e4bbf63fe7e0</Hash>
</Codenesium>*/