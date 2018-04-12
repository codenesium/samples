using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class SpaceXSpaceFeatureModel
	{
		public SpaceXSpaceFeatureModel()
		{}

		public SpaceXSpaceFeatureModel(
			int spaceId,
			int spaceFeatureId)
		{
			this.SpaceId = spaceId.ToInt();
			this.SpaceFeatureId = spaceFeatureId.ToInt();
		}

		private int spaceId;

		[Required]
		public int SpaceId
		{
			get
			{
				return this.spaceId;
			}

			set
			{
				this.spaceId = value;
			}
		}

		private int spaceFeatureId;

		[Required]
		public int SpaceFeatureId
		{
			get
			{
				return this.spaceFeatureId;
			}

			set
			{
				this.spaceFeatureId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>06e17ecbcd4696c7918ab7e8f65e29c7</Hash>
</Codenesium>*/