using GigHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GigHub.Persistence.EntityConfigurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(100);

            HasMany(g => g.Followers).WithRequired(g => g.Followee).WillCascadeOnDelete(false);
            HasMany(g => g.Followees).WithRequired(g => g.Follower).WillCascadeOnDelete(false);
            HasMany(g => g.UserNotifications).WithRequired(g => g.User).WillCascadeOnDelete(false);
        }
    }
}