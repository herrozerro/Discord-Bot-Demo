using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity;

namespace Beep_Bot
{
    [Group("admin")]
    class BeepCommands
    {
        [Group("secrets")]
        class SubBeeps
        {
            [Command("Beep")]
            [Description("Boops when you Beep")]
            [Aliases("beep", "bep")]
            public async Task BeepMessage(CommandContext ctx)
            {
                InteractivityModule interact = ctx.Client.GetInteractivityModule();

                await ctx.RespondAsync("What kinds of Boops would you like?");
                await ctx.RespondAsync("1: Boop");
                await ctx.RespondAsync("2: Bop");

                var response = await interact.WaitForMessageAsync(x => x.Author == ctx.Message.Author, TimeSpan.FromMinutes(1));

                if (response == null)
                {
                    await ctx.RespondAsync("No Boops for u!");
                }

                switch (response.Message.Content)
                {
                    case "1":
                        await ctx.RespondAsync("Boop");
                        break;
                    case "2":
                        await ctx.RespondAsync("Bop");
                        break;
                    default:
                        await ctx.RespondAsync("No");
                        break;

                }

                //await ctx.RespondAsync("Boop");
            }
        }


    }
}
