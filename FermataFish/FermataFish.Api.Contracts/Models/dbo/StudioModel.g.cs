using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class StudioModel
	{
		public StudioModel()
		{}

		public StudioModel(
			string name,
			string website,
			string address1,
			string address2,
			string city,
			int stateId,
			string zip)
		{
			this.Name = name.ToString();
			this.Website = website.ToString();
			this.Address1 = address1.ToString();
			this.Address2 = address2.ToString();
			this.City = city.ToString();
			this.StateId = stateId.ToInt();
			this.Zip = zip.ToString();
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

		private string website;

		[Required]
		public string Website
		{
			get
			{
				return this.website;
			}

			set
			{
				this.website = value;
			}
		}

		private string address1;

		[Required]
		public string Address1
		{
			get
			{
				return this.address1;
			}

			set
			{
				this.address1 = value;
			}
		}

		private string address2;

		[Required]
		public string Address2
		{
			get
			{
				return this.address2;
			}

			set
			{
				this.address2 = value;
			}
		}

		private string city;

		[Required]
		public string City
		{
			get
			{
				return this.city;
			}

			set
			{
				this.city = value;
			}
		}

		private int stateId;

		[Required]
		public int StateId
		{
			get
			{
				return this.stateId;
			}

			set
			{
				this.stateId = value;
			}
		}

		private string zip;

		[Required]
		public string Zip
		{
			get
			{
				return this.zip;
			}

			set
			{
				this.zip = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>dec608828d5e28b5ae00fc53e893144d</Hash>
</Codenesium>*/