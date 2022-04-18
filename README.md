# Asp.Net Core 权限管理系统
> Sql Server 版本不得低于 2012，否则会出现分页方法出错

**[0 Asp.Net Core 项目实战之权限管理系统（0） 无中生有](http://www.cnblogs.com/fonour/p/5848933.html)**

**[1 Asp.Net Core 项目实战之权限管理系统（1） 使用AdminLTE搭建前端](http://www.cnblogs.com/fonour/p/5862369.html)**

**[2 Asp.Net Core 项目实战之权限管理系统（2） 功能及实体设计](http://www.cnblogs.com/fonour/p/5879622.html)**

**[3 Asp.Net Core 项目实战之权限管理系统（3） 通过EntityFramework Core使用PostgreSQL](http://www.cnblogs.com/fonour/p/5886292.html)**

**[4 Asp.Net Core 项目实战之权限管理系统（4） 依赖注入、仓储、服务的多项目分层实现](http://www.cnblogs.com/fonour/p/5904530.html)**

**[5 Asp.Net Core 项目实战之权限管理系统（5） 用户登录](http://www.cnblogs.com/fonour/p/5943401.html)**

**[6 Asp.Net Core 项目实战之权限管理系统（6） 功能管理](http://www.cnblogs.com/fonour/p/5988538.html)**

**[7 Asp.Net Core 项目实战之权限管理系统（7） 组织机构、角色、用户权限](http://www.cnblogs.com/fonour/p/6223376.html)**

**[8 Asp.Net Core 项目实战之权限管理系统（8） 功能菜单的动态加载](http://www.cnblogs.com/fonour/p/6425635.html)**

**[Github源码地址](https://github.com/Run2948/Fonour)**

## Code First 操作步骤
* 使用程序包管理器控制台(前提安装 Microsoft.EntityFrameworkCore、Microsoft.EntityFrameworkCore.Tools )
  * `Add-Migration Init`
  * `Update-DataBase`
  * `Remove-Migration `
* 使用 .NET Core CLI 命令
  * `dotnet ef migrations add init`
  * `dotnet ef database update`*

## 项目展示
* 登录界面
    ![登录界面](docs/1.png)
* 欢迎界面
    ![欢迎界面](docs/2.png)
* 组织管理界面
    ![组织管理界面](docs/3.png)
* 角色管理界面
    ![角色管理界面](docs/4.png)
* 用户管理界面
    ![用户管理界面](docs/5.png)
* 菜单管理界面
    ![菜单管理界面](docs/6.png)

## 常见问题
### 1.[在 Visual Studio 2017 中使用 Bower 管理前端框架](https://blog.csdn.net/qq_33303204/article/details/81323512)
### 2.[Asp.net Core 读取配置文件 - appsettings.json](https://www.cnblogs.com/yuangang/p/5736892.html)
### 3.[EF Core 迁移过程遇到EF Core tools version版本不相符的解决方案](https://www.cnblogs.com/duanyong/p/10018025.html)
### 4.[关于Cannot resolve scoped service from root provi...](https://www.jianshu.com/p/8e928947d833)