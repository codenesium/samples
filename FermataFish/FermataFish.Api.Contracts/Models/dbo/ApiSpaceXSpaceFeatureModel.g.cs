using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiSpaceXSpaceFeatureModel: AbstractModel
	{
		public ApiSpaceXSpaceFeatureModel() : base()
		{}

		public ApiSpaceXSpaceFeatureModel(
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
    <Hash>f626f8affeae169d4f3b70fd888fdd1e</Hash>
</Codenesium>*/