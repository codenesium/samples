using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class SpaceModel
	{
		public SpaceModel()
		{}

		public SpaceModel(
			string description,
			string name,
			int studioId)
		{
			this.Description = description.ToString();
			this.Name = name.ToString();
			this.StudioId = studioId.ToInt();
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

		private int studioId;

		[Required]
		public int StudioId
		{
			get
			{
				return this.studioId;
			}

			set
			{
				this.studioId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>39b5b493544ba337fa8c4099bed9c0ed</Hash>
</Codenesium>*/