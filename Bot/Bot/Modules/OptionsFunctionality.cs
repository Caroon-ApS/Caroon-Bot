using Discord;
using Discord.Commands;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Modules
{
    public class OptionsFunctionality : ModuleBase<SocketCommandContext>
    {
        private readonly Servers _servers;

        public OptionsFunctionality(Servers servers)
        {
            _servers = servers;
        }

        [Command("prefix")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Prefix(string prefix = null)
        {
            if (prefix == null)
            {
                await ReplyAsync($"The current prefix is `{await _servers.GetGuildPrefix(Context.Guild.Id) ?? ";"}`");
                return;
            }

            if(prefix.Length > 30)
            {
                await ReplyAsync("The length of the new prefix is too long!");
                return;
            }

            await _servers.SetGuildPrefix(Context.Guild.Id, prefix);
            await ReplyAsync($"The prefix is now `{prefix}`");
        }
    }
}
