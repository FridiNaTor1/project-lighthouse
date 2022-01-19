#nullable enable
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBPUnion.ProjectLighthouse.Pages.Layouts;
using LBPUnion.ProjectLighthouse.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LBPUnion.ProjectLighthouse.Pages;

public class UsersPage : BaseLayout
{

    public int UserCount;

    public List<User> Users;
    public UsersPage(Database database) : base(database)
    {}

    public async Task<IActionResult> OnGet()
    {
        User? user = this.Database.UserFromWebRequest(this.Request);

        this.Users = await this.Database.Users.OrderByDescending(u => u.UserId).ToListAsync();
        this.UserCount = this.Users.Count;

        return this.Page();
    }
}