#nullable enable
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBPUnion.ProjectLighthouse.Pages.Layouts;
using LBPUnion.ProjectLighthouse.Types;
using LBPUnion.ProjectLighthouse.Types.Levels;
using LBPUnion.ProjectLighthouse.Types.Profiles;
using LBPUnion.ProjectLighthouse.Types.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LBPUnion.ProjectLighthouse.Pages;

public class UserPage : BaseLayout
{
    public List<Comment>? Comments;

    public bool CommentsEnabled = ServerSettings.Instance.ProfileCommentsEnabled;

    public bool IsProfileUserHearted;

    public List<Photo>? Photos;

    public User? ProfileUser;
    public UserPage(Database database) : base(database)
    {}

    public async Task<IActionResult> OnGet([FromRoute] int userId)
    {
        this.ProfileUser = await this.Database.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        if (this.ProfileUser == null) return this.NotFound();

        this.Photos = await this.Database.Photos.OrderByDescending(p => p.Timestamp).Where(p => p.CreatorId == userId).Take(6).ToListAsync();
        if (this.CommentsEnabled)
        {
            this.Comments = await this.Database.Comments.Include(c => c.Poster)
                .OrderByDescending(c => c.Timestamp)
                .Where(c => c.TargetId == userId && c.Type == CommentType.Profile && c.SlotType == SlotType.User)
                .Take(50)
                .ToListAsync();
        }
        else
        {
            this.Comments = new List<Comment>();
        }

        if (this.User == null) return this.Page();
        
        foreach (Comment c in this.Comments)
        {
           Reaction? reaction = await this.Database.Reactions.FirstOrDefaultAsync(r => r.UserId == this.User.UserId && r.TargetId == c.CommentId);
           if (reaction != null) c.YourThumb = reaction.Rating;
        }
        this.IsProfileUserHearted = await this.Database.HeartedProfiles.FirstOrDefaultAsync
            (u => u.UserId == this.User.UserId && u.HeartedUserId == this.ProfileUser.UserId) != null;        

        return this.Page();
    }
}
