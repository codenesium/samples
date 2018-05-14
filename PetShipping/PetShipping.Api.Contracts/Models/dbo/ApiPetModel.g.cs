using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPetModel
	{
		public ApiPetModel()
		{}

		public ApiPetModel(
			int breedId,
			int clientId,
			string name,
			int weight)
		{
			this.BreedId = breedId.ToInt();
			this.ClientId = clientId.ToInt();
			this.Name = name.ToString();
			this.Weight = weight.ToInt();
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

		private int clientId;

		[Required]
		public int ClientId
		{
			get
			{
				return this.clientId;
			}

			set
			{
				this.clientId = value;
			}
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

		private int weight;

		[Required]
		public int Weight
		{
			get
			{
				return this.weight;
			}

			set
			{
				this.weight = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>5990c1c5ed676c987129710445bbbce4</Hash>
</Codenesium>*/