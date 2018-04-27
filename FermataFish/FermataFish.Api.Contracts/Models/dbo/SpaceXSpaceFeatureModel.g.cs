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
			int spaceFeatureId,
			int spaceId)
		{
			this.SpaceFeatureId = spaceFeatureId.ToInt();
			this.SpaceId = spaceId.ToInt();
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
	}
}

/*<Codenesium>
    <Hash>8fa79915f28a934c343e4f70f0851da7</Hash>
</Codenesium>*/