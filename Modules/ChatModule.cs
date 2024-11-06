using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace DiscordBot.Modules
{
    [Group("chat")]
    public class ChatModule : BaseCommandModule
    {
        [Command("hello")]
        public async Task HelloCommand(CommandContext ctx)
        {
            await ctx.RespondAsync($"Hello {ctx.User.Username}");
        }
    }
}
