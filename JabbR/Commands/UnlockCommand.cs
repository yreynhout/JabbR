using System;
using JabbR.Models;
using Microsoft.AspNet.SignalR;

namespace JabbR.Commands
{
    [Command("unlock", "Unlock_CommandInfo", "[room]", "room")]
    public class UnlockCommand : UserCommand
    {
        public override void Execute(CommandContext context, CallerContext callerContext, ChatUser callingUser, string[] args)
        {
            string roomName = args.Length > 0 ? args[0] : callerContext.RoomName;

            if (String.IsNullOrEmpty(roomName))
            {
                throw new HubException(LanguageResources.Lock_RoomRequired);
            }

            ChatRoom room = context.Repository.VerifyRoom(roomName, mustBeOpen: false);

            context.Service.UnlockRoom(callingUser, room);

            context.NotificationService.UnlockRoom(callingUser, room);
        }
    }
}