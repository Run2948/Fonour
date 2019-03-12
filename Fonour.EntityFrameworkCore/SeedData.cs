using Fonour.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fonour.EntityFrameworkCore
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope()) //手动高亮
            {
                using (var context = serviceScope.ServiceProvider.GetService<FonourDbContext>()) //手动高亮
                {
                    Guid departmentId = Guid.NewGuid();
                    
                    //增加一个部门
                    if (!context.Departments.Any())
                    {
                        context.Departments.Add(
                            new Department
                            {
                                Id = departmentId,
                                Name = "Fonour集团总部",
                                ParentId = Guid.Empty
                            }
                         );
                    }
                    
                    //增加一个超级管理员用户
                    if (!context.Users.Any())
                    {
                        context.Users.Add(
                             new User
                             {
                                 UserName = "admin",
                                 Password = "123456", //暂不进行加密
                                 Name = "超级管理员",
                                 DepartmentId = departmentId
                             }
                        );
                    }

                    //增加四个基本功能菜单
                    if (!context.Menus.Any())
                    {
                        context.Menus.AddRange(
                          new Menu
                          {
                              Name = "组织机构管理",
                              Code = "Department",
                              SerialNumber = 0,
                              ParentId = Guid.Empty,
                              Url = "/Department/Index",
                              Icon = "fa fa-link"
                          },
                          new Menu
                          {
                              Name = "角色管理",
                              Code = "Role",
                              SerialNumber = 1,
                              ParentId = Guid.Empty,
                              Url = "/Role/Index",
                              Icon = "fa fa-link"
                          },
                          new Menu
                          {
                              Name = "用户管理",
                              Code = "User",
                              SerialNumber = 2,
                              ParentId = Guid.Empty,
                              Url = "/User/Index",
                              Icon = "fa fa-link"
                          },
                          new Menu
                          {
                              Name = "功能管理",
                              Code = "Menu",
                              SerialNumber = 3,
                              ParentId = Guid.Empty,
                              Url = "/Menu/Index",
                              Icon = "fa fa-link"
                          }
                       );
                    }

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
