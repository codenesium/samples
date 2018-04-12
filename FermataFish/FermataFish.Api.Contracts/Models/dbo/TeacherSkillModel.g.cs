using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class TeacherSkillModel
	{
		public TeacherSkillModel()
		{}

		public TeacherSkillModel(
			string name,
			int studioId)
		{
			this.Name = name;
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
    <Hash>fd7317617c96c943015d080a1d8cc1ee</Hash>
</Codenesium>*/