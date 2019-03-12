/* ==============================================================================
* 命名空间：Fonour.Application 
* 类 名 称：FonourMapper
* 创 建 者：Qing
* 创建时间：2019/03/11 16:04:54
* CLR 版本：4.0.30319.42000
* 保存的文件名：FonourMapper
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
using AutoMapper;
using Fonour.Application.DepartmentApp.Dtos;
using Fonour.Application.MenuApp.Dtos;
using Fonour.Application.RoleApp.Dtos;
using Fonour.Application.UserApp.Dtos;
using Fonour.Domain.Entities;

namespace Fonour.Application
{
    /// <summary>
    /// Entity与Dto映射
    /// </summary>
    public class FonourMapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Menu, MenuDto>();
                cfg.CreateMap<MenuDto, Menu>();
                cfg.CreateMap<Department, DepartmentDto>();
                cfg.CreateMap<DepartmentDto, Department>();
                cfg.CreateMap<RoleDto, Role>();
                cfg.CreateMap<Role, RoleDto>();
                cfg.CreateMap<RoleMenuDto, RoleMenu>();
                cfg.CreateMap<RoleMenu, RoleMenuDto>();
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserRoleDto, UserRole>();
                cfg.CreateMap<UserRole, UserRoleDto>();
            });
        }
    }
}
