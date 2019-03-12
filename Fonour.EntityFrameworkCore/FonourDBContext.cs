/* ==============================================================================
* 命名空间：Fonour.EntityFrameworkCore 
* 类 名 称：FonourDBContext
* 创 建 者：Qing
* 创建时间：2019/03/11 15:58:01
* CLR 版本：4.0.30319.42000
* 保存的文件名：FonourDBContext
* 文件版本：V1.0.0.0
*
* 功能描述：N/A 
*
* 修改历史：
*
*
* ==============================================================================
*         CopyRight @ 班纳工作室 2019. All rights reserved
* ==============================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using Fonour.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fonour.EntityFrameworkCore
{
    public class FonourDbContext : DbContext
    {
        public FonourDbContext(DbContextOptions<FonourDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //UserRole关联配置
            builder.Entity<UserRole>()
              .HasKey(ur => new { ur.UserId, ur.RoleId });

            //RoleMenu关联配置
            builder.Entity<RoleMenu>()
              .HasKey(rm => new { rm.RoleId, rm.MenuId });

            base.OnModelCreating(builder);
        }
    }
}
