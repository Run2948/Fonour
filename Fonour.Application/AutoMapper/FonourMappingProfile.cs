using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Fonour.Application.DepartmentApp.Dtos;
using Fonour.Application.MenuApp.Dtos;
using Fonour.Application.RoleApp.Dtos;
using Fonour.Application.UserApp.Dtos;
using Fonour.Domain.Entities;

namespace Fonour.Application.AutoMapper
{
    /// <summary>
    /// Entity与Dto映射
    /// </summary>
    public class FonourMappingProfile : Profile
    {
        public FonourMappingProfile()
        {
            CreateMap<Menu, MenuDto>();
            CreateMap<MenuDto, Menu>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDto, Department>();
            CreateMap<RoleDto, Role>();
            CreateMap<Role, RoleDto>();
            CreateMap<RoleMenuDto, RoleMenu>();
            CreateMap<RoleMenu, RoleMenuDto>();
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<UserRoleDto, UserRole>();
            CreateMap<UserRole, UserRoleDto>();
        }
    }
}
