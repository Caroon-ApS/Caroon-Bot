using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Bot.Services;
using Discord;

namespace Bot.Modules
{
    public class EmoteFunctionality : ModuleBase<SocketCommandContext>
    {
        [Command("wpH")]
        public async Task WpH()
        {
            Emote[] emotes = { Emote.Parse("<:wp1:746364170106306560>"), Emote.Parse("<:wpH2:746364170123083816>"), Emote.Parse("<:wpH3:746364170089398292>"), Emote.Parse("<:wpH4:746364170005643315>") };

            await Context.Message.DeleteAsync();
            await ReplyAsync($"{Context.User.Username}:");
            await ReplyAsync($"{emotes[0]}{emotes[1]}{emotes[2]}{emotes[3]}");
        }


        [Command("wpS")]
        public async Task WpS()
        {
            Emote[] emotes = { Emote.Parse("<:wp1:746364170106306560>"), Emote.Parse("<:wpS2:746364170068426763>"), Emote.Parse("<:wpS3:746364170118627410>"), Emote.Parse("<:wpS4:746364169665642639>") };

            await Context.Message.DeleteAsync();
            await ReplyAsync($"{Context.User.Username}:");
            await ReplyAsync($"{emotes[0]}{emotes[1]}{emotes[2]}{emotes[3]}");
        }

        [Command("Daniel")]
        public async Task Daniel()
        {
            Emote[] emotes = { Emote.Parse("<:daniel11:746387421012426842>"), Emote.Parse("<:daniel12:746387422333501602>"), Emote.Parse("<:daniel13:746387421540778034>") };

            await Context.Message.DeleteAsync();
            await ReplyAsync($"{Context.User.Username}:");
            await ReplyAsync($"{emotes[0]}{emotes[1]}{emotes[2]}");
        }
    }
}
