using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DiscordBot.Modules;
using DSharpPlus;
using DSharpPlus.CommandsNext;

namespace DiscordBot
{
    public class Program
    {
        private static DiscordClient _client;
        private static EventModule _guildMemberEventModule;

        public static async Task Main(string[] args)
        {
            var token = "MTA3Nzg1NTM2MDcyNTA0MTIxMg.GOBomL.FgJ4kWzuKHV0lj9DxISgSbLVgjMZ-TBMCZaw9g";
            ulong welbyeChannelID = 1033682410933583962;

            _client = new DiscordClient(new DiscordConfiguration()
            {
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents | DiscordIntents.GuildMembers,
                Token = token,
                TokenType = TokenType.Bot
            });

            var commands = _client.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { "!" }
            });

            commands.RegisterCommands<ChatModule>();
            _guildMemberEventModule = new EventModule(_client, welbyeChannelID);

            await _client.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
