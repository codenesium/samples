using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class LessonStatusModel
	{
		public LessonStatusModel()
		{}

		public LessonStatusModel(
			string name,
			int studioId)
		{
			this.Name = name.ToString();
			this.StudioId = studioId.ToInt();
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
    <Hash>5daac2877228aae87bbd66dc2aff5d3f</Hash>
</Codenesium>*/