using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("UserRole", Schema="dbo")]
        public partial class UserRole : AbstractEntity
        {
                public UserRole()
                {
                }

                public void SetProperties(
                        string id,
                        string jSON,
                        string name)
                {
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                }

                [Key]
                [Column("Id")]
                public string Id { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e0ef678aef9ec2d714627dccda16b07e</Hash>
</Codenesium>*/