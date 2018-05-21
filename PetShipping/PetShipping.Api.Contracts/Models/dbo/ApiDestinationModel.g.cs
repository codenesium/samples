using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiDestinationModel: AbstractModel
	{
		public ApiDestinationModel() : base()
		{}

		public ApiDestinationModel(
			int countryId,
			string name,
			int order)
		{
			this.CountryId = countryId.ToInt();
			this.Name = name;
			this.Order = order.ToInt();
		}

		private int countryId;

		[Required]
		public int CountryId
		{
			get
			{
				return this.countryId;
			}

			set
			{
				this.countryId = value;
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

		private int order;

		[Required]
		public int Order
		{
			get
			{
				return this.order;
			}

			set
			{
				this.order = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>09eff65d705dbeef7a550788adcf8b61</Hash>
</Codenesium>*/