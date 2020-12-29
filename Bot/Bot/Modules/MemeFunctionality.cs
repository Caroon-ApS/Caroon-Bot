using Discord;
using Discord.Commands;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Modules
{
    public class MemeFunctionality : ModuleBase<SocketCommandContext>
    {
        [Command("meme")]
        [Alias("reddit")]
        public async Task Meme(string subreddit = null)
        {
            var client = new HttpClient();
            string result = await client.GetStringAsync($"https://reddit.com/r/{subreddit ?? "memes"}/random.json?limit=1");
            if (!result.StartsWith("["))
            {
                await Context.Channel.SendMessageAsync("This subreddit doesn't work");
                return;
            }
            JArray arr = JArray.Parse(result);
            JObject post = JObject.Parse(arr[0]["data"]["children"][0]["data"].ToString());


            var builder = new EmbedBuilder()
                .WithImageUrl(post["url"].ToString())
                .WithColor(new Color(255, 0, 170))
                .WithTitle(post["title"].ToString())
                .WithUrl("https://reddit.com" + post["permalink"].ToString())
                .WithFooter($"💬 {post["num_comments"]} 🔼 {post["ups"]}");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        
    }
}
